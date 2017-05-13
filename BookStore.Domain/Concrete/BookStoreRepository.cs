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

        //public void AddTagsToBook(int bookId, List<TagViewModel> tags)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<List<TagViewModel>> GetTagsAsync(int skip = 0, int take = -1, SortOrder sortOrder = SortOrder.Ascending, string orderBy = "TagId",
            List<PropertyFilter> propertyFilters = null)
        {
            throw new NotImplementedException();
        }

        public Task<TagViewModel> GetTagById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdateTag(TagViewModel tag)
        {
            throw new NotImplementedException();
        }

        public void DeleteTagById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
