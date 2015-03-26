﻿using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using SimpleToggle.Examples.MVC.Controllers;
using SimpleToggle.Http;

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
                RegisterFeatureToggles(c);
                c.Register(FeatureToggledService).As<IUseToggles>()
                    .InstancePerRequest();
            });
        }

        private IUseToggles FeatureToggledService(IComponentContext context)
        {
            if (Toggle.Enabled("Toggle1"))
                return new ToggleOnVersion();
            
            return new NoOpVersion();
        }

        private static void RegisterFeatureToggles(ContainerBuilder c)
        {
            var toggles = new CookieToggles(() => new HttpContextWrapper(HttpContext.Current));
            c.RegisterInstance(toggles).As<IToggler>();

            // Register all the toggles
            //Toggle.Register("name", writeable);

            Toggle.Config.Default();
            Toggle.Config.NoToggleBehaviour = s => false;
            Toggle.Config.Providers.Add(toggles);
        }
    }
}