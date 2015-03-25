using System.Web;

namespace SimpleToggle.Tests.Specs.cookie_toggles
{
    internal class InMemoryResponse : HttpResponseBase
    {
        private readonly HttpCookieCollection _cookies = new HttpCookieCollection();

        public override HttpCookieCollection Cookies
        {
            get { return _cookies; }
        }
    }
}