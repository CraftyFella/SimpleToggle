using System.Linq;
using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.listing_toggles
{
    public class single_toggle : toggle_context
    {
        public single_toggle()
        {
            Toggle.Registry.Add("toggle");
        }
        [Fact]
        public void toggle_returned()
        {
            Toggle.Registry.All.ShouldContain("toggle");
        }

        [Fact]
        public void list_has_one_item()
        {
            Toggle.Registry.All.Count().ShouldBe(1);
        }
    }
}