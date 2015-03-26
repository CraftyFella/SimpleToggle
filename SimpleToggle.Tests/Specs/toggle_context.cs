using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace SimpleToggle.Tests.Specs
{
    public class toggle_context
    {
        private readonly InMemoryToggles _inMemoryToggles;

        public toggle_context()
        {
            Toggle.Providers.Clear();
            Toggle.Registry.Clear();
            _inMemoryToggles = new InMemoryToggles();
            Toggle.Providers.Add(_inMemoryToggles);
        }

        protected void toggle_on<T>()
        {    
            toggle_on(Toggle.NameFor<T>());
        }

        protected void toggle_on(string toggle)
        {
            Toggle.Registry.Add(toggle);
            _inMemoryToggles.ToggleOn(toggle);
        }

        protected void toggle_off<T>()
        {
            Toggle.Registry.Add<T>();
            _inMemoryToggles.ToggleOff<T>();
        }

        protected void toggle_on_in<T>(InMemoryToggles toggles)
        {
            Toggle.Providers.Add(toggles);
            Toggle.Registry.Add<T>();
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