using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace SimpleToggle.Tests.Specs
{
    public class toggle_context
    {
        private readonly InMemoryToggleStateProvider _inMemoryToggleStateProvider;

        public toggle_context()
        {
            Toggle.Config.Default();
            _inMemoryToggleStateProvider = new InMemoryToggleStateProvider();
            Toggle.Config.Providers.Add(_inMemoryToggleStateProvider);
        }

        protected void toggle_on<T>()
        {    
            _inMemoryToggleStateProvider.ToggleOn<T>();
        }

        protected void toggle_on(string toggle)
        {
            _inMemoryToggleStateProvider.ToggleOn(toggle);
        }

        protected void toggle_off<T>()
        {
            _inMemoryToggleStateProvider.ToggleOff<T>();
        }

        protected void toggle_on_in<T>(InMemoryToggleStateProvider toggleStateProvider)
        {
            Toggle.Config.Providers.Add(toggleStateProvider);
            toggleStateProvider.ToggleOn<T>();
        }

        protected bool is_toggle_enabled<T>()
        {
            return Toggle.Enabled<T>();
        }

        protected bool is_toggle_enabled(string toggle)
        {
            return Toggle.Enabled(toggle);
        }
    }
}