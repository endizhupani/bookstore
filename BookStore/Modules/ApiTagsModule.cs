using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Abstract;
using BookStore.Domain.ViewModels;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;

namespace BookStore.UI.Modules
{
    public class ApiTagsModule : NancyModule
    {
        private readonly IBookStoreRepository _repository;

        public ApiTagsModule(IBookStoreRepository repository) : base("/api/tags")
        {
            _repository = repository;

            Get["/", true] =
                async (p, ct) => new JsonResponse(await _repository.GetTagsAsync(), new DefaultJsonSerializer());

            Get["/{id}", true] = 
                async (p, ct) => new JsonResponse(await _repository.GetTagByIdAsync(p.id), new DefaultJsonSerializer());

            Post["/", true] = async (p, ct) => await AddOrUpdateTag();

            Put["/", true] = async (p, ct) => await AddOrUpdateTag();

            Delete["/{id}", true] = async (p, ct) =>
            {
                _repository.DeleteTagById(p.id);
                await _repository.SaveChangesAsync();
                return new JsonResponse(new {success = true}, new DefaultJsonSerializer());
            };

        }

        private async Task<Response> AddOrUpdateTag()
        {
            TagViewModel tag = this.Bind<TagViewModel>();
            await _repository.AddOrUpdateTagAsync(tag);
            await _repository.SaveChangesAsync();
            return new Response()
            {
                StatusCode = HttpStatusCode.Accepted
            };
        }
    }
}
