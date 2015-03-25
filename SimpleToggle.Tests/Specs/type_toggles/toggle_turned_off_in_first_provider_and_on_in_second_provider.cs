using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.type_toggles
{
    public class toggle_turned_off_in_first_provider_and_on_in_second_provider : toggle_context
    {
        public toggle_turned_off_in_first_provider_and_on_in_second_provider()
        {
            toggle_off<MyToggle>();
            toggle_on_in<MyToggle>(new InMemoryToggleStateProvider());
        }
        
        [Fact]
        public void uses_first_provider_so_is_disabled()
        {
            is_toggle_enabled<MyToggle>().ShouldBe(false);
        }
    }
}