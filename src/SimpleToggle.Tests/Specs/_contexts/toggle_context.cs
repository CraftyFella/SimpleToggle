using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace SimpleToggle.Tests.Specs._contexts
{
    public class toggle_context
    {
        private readonly InMemoryProvider _inMemoryProvider;

        public toggle_context()
        {
            Toggle.ResetAll();
            _inMemoryProvider = new InMemoryProvider();
            Toggle.Providers.Add(_inMemoryProvider);
        }

        protected void toggle_on<T>()
        {    
            toggle_on(Toggle.NameFor<T>());
        }

        protected void toggle_on(string toggle)
        {
            Toggle.Register(toggle);
            _inMemoryProvider.ToggleOn(toggle);
        }

        protected void toggle_off<T>()
        {
            Toggle.Register<T>();
            _inMemoryProvider.ToggleOff<T>();
        }

        protected void toggle_on_in<T>(InMemoryProvider provider)
        {
            Toggle.Providers.Add(provider);
            Toggle.Register<T>();
            provider.ToggleOn<T>();
        }

        protected bool is_toggle_enabled<T>()
        {
            return Toggle.IsEnabled<T>();
        }

        protected bool is_toggle_enabled(string toggle)
        {
            return Toggle.IsEnabled(toggle);
        }
    }
}