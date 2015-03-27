using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.getting_toggle_status
{
    public class toggle_turned_off_in_first_provider_and_on_in_second_provider : toggle_context
    {
        public toggle_turned_off_in_first_provider_and_on_in_second_provider()
        {
            toggle_off<MyToggle>();
            toggle_on_in<MyToggle>(new InMemoryProvider());
        }
        
        [Fact]
        public void uses_first_provider_so_is_disabled()
        {
            is_toggle_enabled<MyToggle>().ShouldBe(false);
        }
    }
}