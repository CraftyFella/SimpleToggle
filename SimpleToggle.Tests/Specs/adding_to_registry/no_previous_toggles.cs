using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.adding_to_registry
{
    public class no_previous_toggles : toggle_context
    {
        public no_previous_toggles()
        {
            Feature.Register<MyToggle>();
        }

        [Fact]
        public void toggle_is_added_to_registry()
        {
            Feature.All.ShouldContain(Feature.NameFor<MyToggle>());
        }
    }
}