using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace SimpleToggle.Tests.Specs._contexts
{
    public class toggle_context
    {
        private readonly InMemoryFeatures _inMemoryFeatures;

        public toggle_context()
        {
            Feature.ResetAll();
            _inMemoryFeatures = new InMemoryFeatures();
            Feature.Providers.Add(_inMemoryFeatures);
        }

        protected void toggle_on<T>()
        {    
            toggle_on(Feature.NameFor<T>());
        }

        protected void toggle_on(string toggle)
        {
            Feature.Register(toggle);
            _inMemoryFeatures.ToggleOn(toggle);
        }

        protected void toggle_off<T>()
        {
            Feature.Register<T>();
            _inMemoryFeatures.ToggleOff<T>();
        }

        protected void toggle_on_in<T>(InMemoryFeatures features)
        {
            Feature.Providers.Add(features);
            Feature.Register<T>();
            features.ToggleOn<T>();
        }

        protected bool is_toggle_enabled<T>()
        {
            return Feature.IsEnabled<T>();
        }

        protected bool is_toggle_enabled(string toggle)
        {
            return Feature.IsEnabled(toggle);
        }
    }
}