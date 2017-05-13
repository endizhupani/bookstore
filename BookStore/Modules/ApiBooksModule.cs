using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using BookStore.Domain.Helpers;
using BookStore.Domain.ViewModels;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;

namespace BookStore.UI.Modules
{
    public class ApiBooksModule : NancyModule
    {
        private readonly IBookStoreRepository _repository;

        public ApiBooksModule(IBookStoreRepository repository) : base("/api/books")
        {
            _repository = repository;

            Get["/",true] = async (p, ct) =>
            {
                var model = await _repository.GetBooksAsync(includeTags: true);
                return new JsonResponse(model, new DefaultJsonSerializer());
            };
            Get["/{id}", true] = async (p, ct) =>
            {
                return new JsonResponse(await _repository.GetBookByIdAsync(p.id, true), new DefaultJsonSerializer());
            };
            Post["/", true] = async (p, ct) =>
            {
                return await UpdateBook();
            };

            //This is used for updates
            Put["/", true] = async (p, ct) =>
            {
                return await UpdateBook();
            };

            Delete["/{id}", true] = async (p, ct) =>
            {
                _repository.DeleteBookById(p.id);
                await _repository.SaveChangesAsync();
                return new JsonResponse(new {success = true}, new DefaultJsonSerializer());
            };
        }

        private async Task<Response> UpdateBook()
        {
            BookViewModel model = this.Bind<BookViewModel>();
            await _repository.AddOrUpdateBookAsync(model);
            await _repository.SaveChangesAsync();
            return new Response()
            {
                StatusCode = HttpStatusCode.Accepted
            };
        }
    }
}
