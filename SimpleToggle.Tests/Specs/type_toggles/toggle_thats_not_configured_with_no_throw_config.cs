using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.type_toggles
{
    public class toggle_thats_not_configured_with_no_throw_config : toggle_context
    {
        public toggle_thats_not_configured_with_no_throw_config()
        {
            Toggle.Config.NoToggleBehaviour = toggle => false;
        }
        [Fact]
        public void will_not_cause_exception()
        {
            Should.NotThrow(() => is_toggle_enabled<NotInConfigToggle>());
        }

        [Fact]
        public void is_disabled()
        {
            is_toggle_enabled<NotInConfigToggle>().ShouldBe(false);
        }
    }
}