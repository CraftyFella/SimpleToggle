using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.adding_to_registry
{
    public class no_previous_toggles : toggle_context
    {
        public no_previous_toggles()
        {
            Toggle.Registry.Add<MyToggle>();
        }

        [Fact]
        public void toggle_is_added_to_registry()
        {
            Toggle.Registry.All.ShouldContain(Toggle.NameFor<MyToggle>());
        }
    }
}