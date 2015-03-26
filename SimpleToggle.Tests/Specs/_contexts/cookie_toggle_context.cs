using SimpleToggle.Http;
using SimpleToggle.Tests.Specs.cookie_toggles;

namespace SimpleToggle.Tests.Specs._contexts
{
    public class cookie_toggle_context
    {
        protected InMemoryHttpContext http_context;
        private CookieToggles _cookieToggles;

        public cookie_toggle_context()
        {
            Toggle.Providers.Clear();
            Toggle.Registry.Clear();
            http_running();
        }

        protected void toggle_on<T>()
        {
            Toggle.Registry.Add<T>();
            _cookieToggles.ToggleOn<T>();
        }

        protected void toggle_off<T>()
        {
            Toggle.Registry.Add<T>();
            _cookieToggles.ToggleOff<T>();
        }
        
        protected bool is_toggle_enabled<T>()
        {
            return Toggle.Enabled<T>();
        }

        private void http_running()
        {
            http_context = new InMemoryHttpContext();
            _cookieToggles = new CookieToggles(() => http_context);
            Toggle.Providers.Add(_cookieToggles);
        }
    }
}