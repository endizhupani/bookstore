using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Abstract;
using BookStore.Domain.Concrete;
using BookStore.Domain.Entities;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Ninject;

namespace BookStore.UI
{
    //public class Bootstrapper : NinjectNancyBootstrapper
    //{

    //    protected override void ConfigureRequestContainer(IKernel container, NancyContext context)
    //    {
    //        base.ConfigureRequestContainer(container, context);
    //        container.Bind<IBookStoreRepository>().To<BookStoreRepository>();
    //        container.Bind<ApplicationDbContext>().ToSelf();
    //    }
        
    //}
}
