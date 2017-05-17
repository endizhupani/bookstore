using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Abstract;
using BookStore.Domain.Concrete;
using BookStore.Domain.Entities;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Nancy.Conventions;
using Ninject;

namespace BookStore.UI
{
    public class Bootstrapper : NinjectNancyBootstrapper
    {
        
        protected override void ConfigureRequestContainer(IKernel container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Bind<IBookStoreRepository>().To<BookStoreRepository>();
            container.Bind<ApplicationDbContext>().ToSelf();
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.ViewLocationConventions.Add((viewName, model, context) => string.Concat("Client/Views/", viewName));
            nancyConventions.ViewLocationConventions.Add((viewName, model, context) => string.Concat("Client/Views/",context.ModuleName, viewName));
            nancyConventions.ViewLocationConventions.Add((viewName, model, context) => string.Concat("Views/", context.ModuleName, viewName));
            nancyConventions.ViewLocationConventions.Add((viewName, model, context) => string.Concat("Views/Shared/", viewName));
            //nancyConventions.StaticContentsConventions.Add((context, rootPath) => {
            //    // Return your response here or null
            //});
        }
    }
}
