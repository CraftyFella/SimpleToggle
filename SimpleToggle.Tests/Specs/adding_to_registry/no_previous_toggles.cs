using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.adding_to_registry
{
    public class no_previous_toggles : toggle_context
    {
        public no_previous_toggles()
        {
            Toggle.Register<MyToggle>();
        }

        [Fact]
        public void toggle_is_added_to_registry()
        {
            Toggle.All.ShouldContain(Toggle.NameFor<MyToggle>());
        }
    }
}