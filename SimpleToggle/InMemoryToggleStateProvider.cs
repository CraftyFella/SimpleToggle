using System.Collections.Concurrent;

namespace SimpleToggle
{

    public static class InMemoryProviderExtensions
    {
        public static void ToggleOn<T>(this InMemoryToggleStateProvider toggleStateProvider)
        {
            toggleStateProvider.ToggleOn(Toggle.NameFor<T>());
        }

        public static void ToggleOff<T>(this InMemoryToggleStateProvider toggleStateProvider)
        {
            toggleStateProvider.ToggleOff(Toggle.NameFor<T>());
        }
    }

    public class InMemoryToggleStateProvider : IToggleStateProvider
    {
        private readonly ConcurrentDictionary<string, bool> _state = new ConcurrentDictionary<string, bool>(); 

        public bool HasValue(string toggle)
        {
            return _state.ContainsKey(toggle);
        }

        public bool IsEnabled(string toggle)
        {
            return _state[toggle];
        }

        public void ToggleOn(string toggle)
        {
            _state.AddOrUpdate(toggle, type => true, (type, b) => true);
        }

        public void ToggleOff(string toggle)
        {
            _state.AddOrUpdate(toggle, type => false, (type, b) => false);
        }
    }
}