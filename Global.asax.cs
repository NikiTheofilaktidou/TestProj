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
        }

        private void RegisterUnity()
        {
            var container = new UnityContainer();

            //Registering dependencies for Loader
            container.RegisterType<Loader>(new HierarchicalLifetimeManager(),
               new InjectionConstructor("suppliers.txt"));

            //Registering dependencies for DataLoader
            container.RegisterType<DataLoader>(new HierarchicalLifetimeManager(), new InjectionConstructor("server", "userid", "password"));

            string loaderTypes = System.Configuration.ConfigurationManager.AppSettings["LoaderTypes"];

            if (loaderTypes.IndexOf("Supplier", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                container.RegisterType<IVendorLoader, SupplierLoaderAdapter>(new HierarchicalLifetimeManager());
            }
            else if (loaderTypes.IndexOf("Trader", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                container.RegisterType<IVendorLoader, TraderLoaderAdapter>(new HierarchicalLifetimeManager());
            }

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}
