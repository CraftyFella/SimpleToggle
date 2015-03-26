using System.Linq;
using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.adding_to_registry
{
    public class already_registered : toggle_context
    {
        public already_registered()
        {
            Toggle.Registry.Add<MyToggle>();
            Toggle.Registry.Add<MyToggle>();
        }

        [Fact]
        public void doesnt_add_another()
        {
            Toggle.Registry.All.Count().ShouldBe(1);
            Toggle.Registry.All.ShouldContain(Toggle.NameFor<MyToggle>());
        }
    }
}