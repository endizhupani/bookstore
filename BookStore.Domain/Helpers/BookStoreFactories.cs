using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.Domain.ViewModels;

namespace BookStore.Domain.Helpers
{
    public static class BookFactory
    {
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
}
