using FileLoader;
using SqlServerLoader;
using System;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Injection;
using Unity.Lifetime;

namespace VendorsWebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterUnity();
        }

        private void RegisterUnity()
        {
            var container = new UnityContainer();

            //Registering dependencies for Loader
            container.RegisterType<Loader>(new HierarchicalLifetimeManager(),
               new InjectionConstructor("suppliers.txt"));

            //Registering dependencies for DataLoader
            container.RegisterType<DataLoader>(new HierarchicalLifetimeManager(), new InjectionConstructor("server", "userid", "password"));

            string loaderType = System.Configuration.ConfigurationManager.AppSettings["LoaderType"];

            if (loaderType=="Supplier")
            {
                container.RegisterType<IVendorLoader, SupplierLoaderAdapter>(new HierarchicalLifetimeManager());
            }
            else if (loaderType=="Trader")
            {
                container.RegisterType<IVendorLoader, TraderLoaderAdapter>(new HierarchicalLifetimeManager());
            }

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}
