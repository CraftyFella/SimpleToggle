using System;
using System.Web;

namespace SimpleToggle.Http
{
    public class CookieProvider : IProvider, IToggler
    {
        private readonly Func<HttpContextBase> _httpContext;
        
        public CookieProvider(Func<HttpContextBase> httpContext)
        {
            _httpContext = httpContext;
        }

        public bool Contains(string toggle)
        {
            return Request.Cookies[toggle] != null;
        }

        private HttpRequestBase Request
        {
            get { return _httpContext().Request; }
        }

        private HttpResponseBase Response
        {
            get { return _httpContext().Response; }
        }

        public bool IsEnabled(string toggle)
        {
            var result = false;
            var httpCookie = Request.Cookies[toggle];
            if (httpCookie != null)
                bool.TryParse(httpCookie.Value, out result);
            return result;
        }

        public void Toggle(string toggle, bool on)
        {
            SetCookie(Request.Cookies, toggle, on);
            SetCookie(Response.Cookies, toggle, on);
        }

        private void SetCookie(HttpCookieCollection cookies, string toggle, bool state)
        {
            var cookie = cookies[toggle];
            if (cookie == null)
                cookies.Add(new HttpCookie(toggle, state.ToString()));
            else
                cookie.Value = state.ToString();
        }
    }
}