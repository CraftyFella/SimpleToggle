using Autofac;
using SimpleToggle.Http;

namespace SimpleToggle.Examples.MVC
{
    public class ToggleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var toggles = new CookieProvider();
            builder.RegisterInstance(toggles).As<IToggler>();

            Toggle.Providers.Add(toggles);
            Toggle.Register("Toggle1");
            Toggle.Register("Toggle2");
            Toggle.Register("Toggle3");
            Toggle.Register<TypedToggle>();

        }

    }
}