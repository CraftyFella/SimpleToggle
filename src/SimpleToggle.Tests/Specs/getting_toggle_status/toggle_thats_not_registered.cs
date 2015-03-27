using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.getting_toggle_status
{
    public class toggle_thats_not_registered : toggle_context
    {
        [Fact]
        public void will_cause_exception()
        {
            Should.Throw<UnRegisteredToggleException>(() => is_toggle_enabled<NotInConfigToggle>());
        }
    }
}