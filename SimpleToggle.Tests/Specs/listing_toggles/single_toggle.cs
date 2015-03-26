using System.Linq;
using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.listing_toggles
{
    public class single_toggle : toggle_context
    {
        public single_toggle()
        {
            Feature.Register("toggle");
        }
        [Fact]
        public void toggle_returned()
        {
            Feature.All.ShouldContain("toggle");
        }

        [Fact]
        public void list_has_one_item()
        {
            Feature.All.Count().ShouldBe(1);
        }
    }
}