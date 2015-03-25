using SimpleToggle.Http;

namespace SimpleToggle.Tests.Specs.cookie_toggles
{
    public class cookie_toggle_context
    {
        protected InMemoryHttpContext http_context;
        private CookieToggles _cookieToggles;

        public cookie_toggle_context()
        {
            Toggle.Config.Default();
            http_running();
        }

        protected void toggle_on<T>()
        {
            _cookieToggles.ToggleOn<T>();
        }

        protected void toggle_off<T>()
        {
            _cookieToggles.ToggleOff<T>();
        }
        
        protected bool is_toggle_enabled<T>()
        {
            return Toggle.Enabled<T>();
        }

        private void http_running()
        {
            http_context = new InMemoryHttpContext();
            _cookieToggles = new CookieToggles(http_context);
            Toggle.Config.Providers.Add(_cookieToggles);
        }
    }
}