using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.listing_toggles
{
    public class no_toggles : toggle_context
    {
        [Fact]
        public void empty_list_returned()
        {
            Feature.All.ShouldBeEmpty();
        }
    }
}