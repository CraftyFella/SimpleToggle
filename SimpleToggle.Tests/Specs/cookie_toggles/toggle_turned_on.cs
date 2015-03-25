using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.cookie_toggles
{
    public class toggle_turned_on : cookie_toggle_context
    {
        public toggle_turned_on()
        {
            toggle_on<MyToggle>();
        }

        [Fact]
        public void is_enabled()
        {
            is_toggle_enabled<MyToggle>().ShouldBe(true);
        }
    }

    public class toggle_turned_on_then_off_then_on : cookie_toggle_context
    {
        public toggle_turned_on_then_off_then_on()
        {
            toggle_on<MyToggle>();
            toggle_off<MyToggle>();
            toggle_on<MyToggle>();
        }

        [Fact]
        public void is_enabled()
        {
            is_toggle_enabled<MyToggle>().ShouldBe(true);
        }

        [Fact]
        public void cookie_collection_only_has_one_value()
        {
            http_context.Request.Cookies.Count.ShouldBe(1);
            http_context.Response.Cookies.Count.ShouldBe(1);
        }
    }

}
