using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.getting_toggle_status
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