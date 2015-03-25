using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace SimpleToggle.Tests.Specs
{
    public class toggle_context
    {
        private readonly InMemoryToggles _inMemoryToggles;

        public toggle_context()
        {
            Toggle.Config.Default();
            _inMemoryToggles = new InMemoryToggles();
            Toggle.Config.Providers.Add(_inMemoryToggles);
        }

        protected void toggle_on<T>()
        {    
            _inMemoryToggles.ToggleOn<T>();
        }

        protected void toggle_on(string toggle)
        {
            _inMemoryToggles.ToggleOn(toggle);
        }

        protected void toggle_off<T>()
        {
            _inMemoryToggles.ToggleOff<T>();
        }

        protected void toggle_on_in<T>(InMemoryToggles toggles)
        {
            Toggle.Config.Providers.Add(toggles);
            toggles.ToggleOn<T>();
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