using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
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
}
