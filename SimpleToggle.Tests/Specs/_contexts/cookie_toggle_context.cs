using SimpleToggle.Http;
using SimpleToggle.Tests.Specs.cookie_toggles;

namespace SimpleToggle.Tests.Specs._contexts
{
    public class cookie_toggle_context
    {
        protected InMemoryHttpContext http_context;
        private CookieFeatures _cookieFeatures;

        public cookie_toggle_context()
        {
            Feature.ResetAll();
            http_running();
        }

        protected void toggle_on<T>()
        {
            Feature.Register<T>();
            _cookieFeatures.ToggleOn<T>();
        }

        protected void toggle_off<T>()
        {
            Feature.Register<T>();
            _cookieFeatures.ToggleOff<T>();
        }
        
        protected bool is_toggle_enabled<T>()
        {
            return Feature.IsEnabled<T>();
        }

        private void http_running()
        {
            http_context = new InMemoryHttpContext();
            _cookieFeatures = new CookieFeatures(() => http_context);
            Feature.Providers.Add(_cookieFeatures);
        }
    }
}