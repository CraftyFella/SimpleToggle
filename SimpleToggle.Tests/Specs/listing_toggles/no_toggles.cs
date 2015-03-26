using Shouldly;
using Xunit;

namespace SimpleToggle.Tests.Specs.listing_toggles
{
    public class no_toggles : toggle_context
    {
        [Fact]
        public void empty_list_returned()
        {
            Toggle.Registry.All.ShouldBeEmpty();
        }
    }
}