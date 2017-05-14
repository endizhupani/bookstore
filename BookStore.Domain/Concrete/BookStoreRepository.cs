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

        public async Task<List<BookViewModel>> GetBooksAsync(int skip = 0, int take = -1, SortOrder sortOrder = SortOrder.Ascending, string orderBy = "BookId",
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
                _context.Books.Add(book.ToBook());
            }
            return book;
        }

        public async void DeleteBookById(int id)
        {
            if (id <= 0)
                return;
            Book toDelete = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (toDelete != null)
            {
                _context.Books.Remove(toDelete);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<List<TagViewModel>> GetTagsAsync(int skip = 0, int take = -1, SortOrder sortOrder = SortOrder.Ascending, string orderBy = "TagId", 
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
                    Description = t.Description,
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
                    Description = t.Description,
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

        public async void DeleteTagById(int id)
        {
            if (id <= 0)
                return;
            Tag tagToDelete = await _context.Tags.FirstOrDefaultAsync(t => t.TagId == id);
            if (tagToDelete != null)
            {
                _context.Tags.Remove(tagToDelete);
            }
        }
    }
}
