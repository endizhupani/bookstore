using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.Domain.ViewModels;

namespace BookStore.Domain.Helpers
{
    /// <summary>
    /// Class with methods that create Book and BookViewModel objects
    /// </summary>
    public static class BookFactory
    {
        /// <summary>
        /// Transforms a BookViewModel to a Book object
        /// </summary>
        /// <param name="input">The view model to be copied</param>
        /// <returns>The new Book object</returns>
        public static Book ToBook(this BookViewModel input)
        {
            return new Book()
            {
                BookId = input.BookId,
                Title = input.Title,
                Author = input.Author,
                Description = input.Description,
                NumberOfPages = input.NumberOfPages,
                PublicationDate = input.PublicationDate,
                Created = input.Created,
                Modified = input.Modified,
                Tags = input.Tags
            };
        }


        /// <summary>
        /// Transforms a Book object to a BookViewModel object.
        /// </summary>
        /// <param name="input">The book to be copied.</param>
        /// <returns>The new BookViewModel object.</returns>
        public static BookViewModel ToBookViewModel(this Book input)
        {
            return new BookViewModel()
            {
                BookId = input.BookId,
                Title = input.Title,
                Author = input.Author,
                Description = input.Description,
                NumberOfPages = input.NumberOfPages,
                PublicationDate = input.PublicationDate,
                Created = input.Created,
                Modified = input.Modified,
                Tags = input.Tags
            };
        }
    }

    /// <summary>
    /// Class with methods that create Tag and TagViewModel objects
    /// </summary>
    public static class TagFactory
    {
        /// <summary>
        /// Transforms a TagViewModel to a Tag object.
        /// </summary>
        /// <param name="input">The view model to be copied</param>
        /// <returns>The new tag object</returns>
        public static Tag ToTag(this TagViewModel input)
        {
            return new Tag()
            {
                TagId = input.TagId,
                Name = input.Name,
                Description = input.Description,
                Books = input.Books
            };
        }


        /// <summary>
        /// Transforms a Tag object into a TagViewModel object
        /// </summary>
        /// <param name="input">The tag to be copied</param>
        /// <returns>The new TagViewModel object</returns>
        public static TagViewModel ToTagViewModel(Tag input)
        {
            return new TagViewModel()
            {
                TagId = input.TagId,
                Name = input.Name,
                Description = input.Description,
                Books = input.Books
            };
        }

    }
}
