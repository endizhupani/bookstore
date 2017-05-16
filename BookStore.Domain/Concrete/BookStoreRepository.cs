using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using BookStore.Domain.Helpers;
using BookStore.Domain.ViewModels;

namespace BookStore.Domain.Concrete
{
    public class BookStoreRepository : IBookStoreRepository
    {
        private readonly ApplicationDbContext _context;

        public BookStoreRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<List<BookViewModel>> GetBooksAsync(int skip = 0, int take = -1, SortOrder sortOrder = SortOrder.Ascending, string orderBy = "Title",
            List<PropertyFilter> propertyFilters = null, bool includeTags = false)
        {
            IQueryable<Book> query = _context.Books;
            if (includeTags)
            {
                query = query.Include(b => b.Tags);
            }

            var deleg = QueryHelpers.GetExpression<Book>(propertyFilters);
            if (deleg != null)
            {
                query = query.Where(deleg);
            }
            return await query.OrderBy(orderBy, sortOrder).Select(b => new BookViewModel()
            {
                BookId = b.BookId,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                NumberOfPages = b.NumberOfPages,
                PublicationDate = b.PublicationDate,
                Created = b.Created,
                Modified = b.Modified,
                Tags = b.Tags
            }).ToListAsync();
        }

        public async Task<BookViewModel> GetBookByIdAsync(int id, bool includeTags = false)
        {
            IQueryable<Book> query = _context.Books;
            if (includeTags)
            {
                query = query.Include(b => b.Tags);
            }
            return await query
                .Where(b => b.BookId == id)
                .Select(b => new BookViewModel()
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    NumberOfPages = b.NumberOfPages,
                    PublicationDate = b.PublicationDate,
                    Created = b.Created,
                    Modified = b.Modified,
                    Tags = b.Tags
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BookViewModel> AddOrUpdateBookAsync(BookViewModel book)
        {
            if (book.BookId > 0)
            {
                Book input = book.ToBook();
                Book dbBook = await _context.Books.Include(b => b.Tags)
                    .FirstOrDefaultAsync(b => b.BookId == book.BookId);
                _context.Entry(dbBook).CurrentValues.SetValues(book);
                _context.Entry(dbBook).State = EntityState.Modified;
                List<int> inputTagIds = input.Tags.Select(t => t.TagId).ToList();
                var deletedTags = dbBook.Tags.Where(t => !inputTagIds.Contains(t.TagId)).ToList();

                List<int> dbTagIds = dbBook.Tags.Select(t => t.TagId).ToList();
                var addedTags = input.Tags.Where(t => !dbTagIds.Contains(t.TagId));

                deletedTags.ForEach(t => dbBook.Tags.Remove(t));
                foreach (Tag addedTag in addedTags)
                {
                    if (_context.Entry(addedTag).State == EntityState.Detached)
                        _context.Tags.Attach(addedTag);

                    dbBook.Tags.Add(addedTag);
                }
            }
            else
            {
                
                Book newBook = book.ToBook();
                List<Tag> bookDbTags = newBook.Tags.Where(t => t.TagId > 0).ToList();
                List<int> bookdbTagIds = newBook.Tags.Where(t => t.TagId > 0).Select(x => x.TagId).ToList();
                foreach (var tag in bookDbTags)
                {
                    newBook.Tags.Remove(tag);
                }
                List<Tag> dbTags = await _context.Tags.Where(t => bookdbTagIds.Contains(t.TagId)).ToListAsync();
                
                _context.Books.Add(newBook);
                foreach (var tag in dbTags)
                {
                    newBook.Tags.Add(tag);
                }
            }
            return book;
        }

        public void DeleteBookById(int id)
        {
            if (id <= 0)
                return;
            Book toDelete =  _context.Books.FirstOrDefault(b => b.BookId == id);
            if (toDelete != null)
            {
                _context.Books.Remove(toDelete);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<List<TagViewModel>> GetTagsAsync(int skip = 0, int take = -1, SortOrder sortOrder = SortOrder.Ascending, string orderBy = "Name", 
            List<PropertyFilter> propertyFilters = null, bool includeTags = false)
        {
            IQueryable<Tag> query = _context.Tags;
            if (includeTags)
            {
                query = query.Include(t => t.Books);
            }
            var deleg = QueryHelpers.GetExpression<Tag>(propertyFilters);
            if (deleg != null)
            {
                query = query.Where(deleg);
            }

            return query.OrderBy(orderBy, sortOrder)
                .Select(t => new TagViewModel()
                {
                    TagId = t.TagId,
                    Name = t.Name,
                    
                    Books = t.Books
                })
                .ToListAsync();
        }

        public Task<TagViewModel> GetTagByIdAsync(int id, bool includeBooks = false)
        {
            IQueryable<Tag> query = _context.Tags;
            if (includeBooks)
            {
                query = query.Include(t => t.Books);
            }
            return query.Where(t => t.TagId == id)
                .Select(t => new TagViewModel()
                {
                    TagId = t.TagId,
                    Name = t.Name,
                    
                    Books = t.Books
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TagViewModel> AddOrUpdateTagAsync(TagViewModel tag)
        {
            Tag newOrUpdatedTag = tag.ToTag();
            if (tag.TagId > 0)
            {
                Tag dbTag = await _context.Tags.FirstOrDefaultAsync(t => t.TagId == tag.TagId);
                if (dbTag != null)
                {
                    _context.Entry(dbTag).CurrentValues.SetValues(newOrUpdatedTag);
                    _context.Entry(dbTag).State = EntityState.Modified;
                }
            }
            else
            {
                _context.Tags.Add(newOrUpdatedTag);
            }
            return tag;
        }

        public void DeleteTagByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;
            Tag tagToDelete = _context.Tags.FirstOrDefault(t => t.Name.Equals(name));
            if (tagToDelete != null)
            {
                _context.Tags.Remove(tagToDelete);
            }
        }
    }
}
