using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using SimpleToggle.Examples.MVC.Controllers;

namespace SimpleToggle.Examples.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoFacConfig.Register(c =>
            {
                c.RegisterModule<ToggleModule>();
                c.Register(ToggledService).As<IUseToggles>()
                    .InstancePerRequest();
            });
        }

        private IUseToggles ToggledService(IComponentContext context)
        {
            if (Toggle.IsEnabled("Toggle1"))
                return new ToggleOnVersion();
            
            return new NoOpVersion();
        }
    }

    internal class TypedToggle
    {
    }
}
