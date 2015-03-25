using System.Web;

namespace SimpleToggle.Tests.Specs.cookie_toggles
{
    public class InMemoryHttpContext : HttpContextBase
    {
        private readonly HttpRequestBase _request = new InMemoryRequest();
        private readonly HttpResponseBase _response = new InMemoryResponse();

        public override HttpRequestBase Request
        {
            get { return _request; }
        }

        public override HttpResponseBase Response
        {
            get { return _response; }
        }
    }
}