using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.getting_toggle_status
{
    public class toggle_not_in_any_providers : toggle_context
    {
        public toggle_not_in_any_providers()
        {
            Toggle.Registry.Add<NotInConfigToggle>();
        }

        [Fact]
        public void is_disabled()
        {
            is_toggle_enabled<NotInConfigToggle>().ShouldBe(false);
        }
    }
}