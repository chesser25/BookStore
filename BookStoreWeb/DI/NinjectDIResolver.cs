using System;
using Ninject;
using System.Web.Mvc;
using System.Collections.Generic;
using BookStoreDomainModel.Concrete;
using BookStoreDomainModel.Abstract;
using System.Configuration;

namespace BookStoreWeb.DI
{
    public class NinjectDIResolver : IDependencyResolver
    {
        // The kernel of DI mechanizm
        IKernel kernel = null;
        public NinjectDIResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        // Return a required object if di is resolved
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        // Bind interface to a class to be dynamically created
        public void AddBindings()
        {
            kernel.Bind<IBookRepository>().To<BookRepository>();
            EmailSettings emailSettings = new EmailSettings
            {
                writeAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcess>().To<OrderProcessor>().WithConstructorArgument("emailSettings", emailSettings);
        }
    }
}