using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.type_toggles
{
    public class toggle_turned_off : toggle_context
    {
        public toggle_turned_off()
        {
            toggle_off<MyToggle>();
        }
        
        [Fact]
        public void is_disabled()
        {
            is_toggle_enabled<MyToggle>().ShouldBe(false);
        }
    }
}