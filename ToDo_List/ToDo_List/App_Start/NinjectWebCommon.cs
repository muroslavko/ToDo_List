using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using ToDo_List.App_Start;
using ToDo_List.DataAccess.Entities;
using ToDo_List.DataAccess.Infrastructure;
using ToDo_List.Infrastructure.Concrete;
using ToDo_List.Services.Concrete;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace ToDo_List.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();


        public static void Start()
        {
            bootstrapper.Initialize(CreateKernel);
        }
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }


        private static void RegisterServices(IKernel kernel)
        {
            MvcApplication.Container = kernel;
            kernel.Load(new DataAccessModule(), new ProviderModule());
        }  
    }
}