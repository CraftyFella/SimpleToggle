using System.Web;
using Autofac;
using SimpleToggle.Http;

namespace SimpleToggle.Examples.MVC
{
    public class FeatureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var toggles = new CookieFeatures(() => new HttpContextWrapper(HttpContext.Current));
            builder.RegisterInstance(toggles).As<IToggler>();

            Feature.Providers.Add(toggles);
            Feature.Register("Toggle1");
            Feature.Register("Toggle2");
            Feature.Register("Toggle3");
            Feature.Register<TypedToggle>();

        }

    }
}