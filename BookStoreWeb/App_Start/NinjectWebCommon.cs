using Ninject;
using Ninject.Web.Common;
using System;
using BookStoreWeb.DI;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BookStoreWeb.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(BookStoreWeb.App_Start.NinjectWebCommon), "Stop")]

namespace BookStoreWeb.App_Start
{
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        // Initializer to create a kernel
        public static void Start()
        {
            bootstrapper.Initialize(CreateKernel);
        }

        // Stop initializer
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        // Register custom services
        private static void RegisterServices(IKernel kernel)
        {
            DependencyResolver.SetResolver(new NinjectDIResolver(kernel));
        }
    }
}