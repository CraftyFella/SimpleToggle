using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.type_toggles
{
    public class toggle_thats_not_configured_with_default_config : toggle_context
    {
        [Fact]
        public void will_cause_exception()
        {
            Should.Throw<KeyNotFoundException>(() => is_toggle_enabled<NotInConfigToggle>());
        }
    }
}