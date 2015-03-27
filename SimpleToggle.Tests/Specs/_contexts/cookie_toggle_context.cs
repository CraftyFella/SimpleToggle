using SimpleToggle.Http;
using SimpleToggle.Tests.Specs.cookie_toggles;

namespace SimpleToggle.Tests.Specs._contexts
{
    public class cookie_toggle_context
    {
        protected InMemoryHttpContext http_context;
        private CookieProvider _cookieProvider;

        public cookie_toggle_context()
        {
            Toggle.ResetAll();
            http_running();
        }

        protected void toggle_on<T>()
        {
            Toggle.Register<T>();
            _cookieProvider.ToggleOn<T>();
        }

        protected void toggle_off<T>()
        {
            Toggle.Register<T>();
            _cookieProvider.ToggleOff<T>();
        }
        
        protected bool is_toggle_enabled<T>()
        {
            return Toggle.IsEnabled<T>();
        }

        private void http_running()
        {
            http_context = new InMemoryHttpContext();
            _cookieProvider = new CookieProvider(() => http_context);
            Toggle.Providers.Add(_cookieProvider);
        }
    }
}