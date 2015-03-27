using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.getting_toggle_status
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
