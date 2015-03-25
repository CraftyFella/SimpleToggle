using System.Web;

namespace SimpleToggle.Http
{
    public class CookieToggles : IProvider, IToggler
    {
        private readonly HttpRequestBase Request;
        private readonly HttpResponseBase Response;
        
        public CookieToggles(HttpContextBase httpContext)
        {
            Request = httpContext.Request;
            Response = httpContext.Response;
        }

        public bool HasValue(string toggle)
        {
            return Request.Cookies[toggle] != null;
        }

        public bool IsEnabled(string toggle)
        {
            var result = false;
            var httpCookie = Request.Cookies[toggle];
            if (httpCookie != null)
                bool.TryParse(httpCookie.Value, out result);
            return result;
        }

        public void ToggleOn(string toggle)
        {
            Toggle(toggle, true);
        }

        public void ToggleOff(string toggle)
        {
            Toggle(toggle, false);
        }

        private void Toggle(string toggle, bool on)
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