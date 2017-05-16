using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.Domain.Helpers;
using BookStore.Domain.ViewModels;

namespace BookStore.Domain.Abstract
{
    /// <summary>
    /// repository interface to be used to communicate with the database.
    /// </summary>
    public interface IBookStoreRepository
    {
        #region Books

        /// <summary>
        /// Gets a list of books from the database
        /// </summary>
        /// <param name="skip">Number of records to skip</param>
        /// <param name="take">Number of records to retreive. If -1, all records will be retreived</param>
        /// <param name="sortOrder">Direction of the sort</param>
        /// <param name="orderBy">Property to sort by</param>
        /// <param name="propertyFilters">A list of filters</param>
        /// <param name="includeTags">include tags for each object</param>
        /// <returns>A list of books</returns>
        Task<List<BookViewModel>> GetBooksAsync(int skip = 0, int take = -1, SortOrder sortOrder = SortOrder.Ascending,
            string orderBy = "Title", List<PropertyFilter> propertyFilters = null, bool includeTags = false);

        /// <summary>
        /// Gets a book with the specified id
        /// </summary>
        /// <param name="id">id of the book to be retrieved</param>
        /// <param name="includeTags">If true, get this book's tags</param>
        /// <returns>the retrieved book</returns>
        Task<BookViewModel> GetBookByIdAsync(int id, bool includeTags = false);

        /// <summary>
        /// Adds a book to the context or updates an existing book
        /// </summary>
        /// <param name="book">The book to be added or updated</param>
        /// <returns>the updated book</returns>
        Task<BookViewModel> AddOrUpdateBookAsync(BookViewModel book);

        /// <summary>
        /// Removes a book from the context
        /// </summary>
        /// <param name="id">id of the book to be removed</param>
        void DeleteBookById(int id);
        #endregion

        #region Tags

        /// <summary>
        /// Gets a list of tags from the database
        /// </summary>
        /// <param name="skip">Number of records to skip</param>
        /// <param name="take">Number of records to retreive. If -1, all records will be retreived</param>
        /// <param name="sortOrder">Direction of the sort</param>
        /// <param name="orderBy">Property to sort by</param>
        /// <param name="propertyFilters">A list of filters</param>
        /// <param name="includeTags">If true, the list of tags for each book will be retrieved from the database</param>
        /// <returns>A list of tags</returns>
        Task<List<TagViewModel>> GetTagsAsync(int skip = 0, int take = -1, SortOrder sortOrder = SortOrder.Ascending,
            string orderBy = "Name", List<PropertyFilter> propertyFilters = null, bool includeTags = false);

        /// <summary>
        /// Gets a tag with the specified id
        /// </summary>
        /// <param name="id">id of the tag to be retrieved</param>
        /// <param name="includeBooks">if true, the books associated with this tag will be retrieved too.</param>
        /// <returns>the retireved tag</returns>
        Task<TagViewModel> GetTagByIdAsync(int id, bool includeBooks = false);

        /// <summary>
        /// Adds a tag to the context or updates an existing tag
        /// </summary>
        /// <param name="tag">The tag to be added or updated</param>
        /// <returns>The new or updated tag.</returns>
        Task<TagViewModel> AddOrUpdateTagAsync(TagViewModel tag);

        /// <summary>
        /// Removes a tag from the context
        /// </summary>
        /// <param name="name">name of the tag to be removed</param>
        void DeleteTagByName(string name);
        #endregion


        /// <summary>
        /// Saves changes to the database
        /// </summary>
        /// <returns>Number of records affected</returns>
        Task<int> SaveChangesAsync();

    }
}
