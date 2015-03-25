using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.type_toggles
{
    public class toggle_turned_on : toggle_context
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
