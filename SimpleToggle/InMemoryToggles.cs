using System.Collections.Concurrent;

namespace SimpleToggle
{
    public class InMemoryToggles : IProvider, IToggler
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
        
        public void Toggle(string toggle, bool @on)
        {
            _state.AddOrUpdate(toggle, type => @on, (type, b) => @on);
        }
    }
}