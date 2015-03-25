using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.string_toggles
{
    public class string_toggle_turned_on : toggle_context
    {
        public string_toggle_turned_on()
        {
            toggle_on("LookNoTypes");
        }

        [Fact]
        public void is_enabled()
        {
            is_toggle_enabled("LookNoTypes").ShouldBe(true);
        }
    }
}