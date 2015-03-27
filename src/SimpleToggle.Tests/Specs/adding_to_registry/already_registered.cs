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
            Toggle.Register<MyToggle>();
            Toggle.Register<MyToggle>();
        }

        [Fact]
        public void doesnt_add_another()
        {
            Toggle.All.Count().ShouldBe(1);
            Toggle.All.ShouldContain(Toggle.NameFor<MyToggle>());
        }
    }
}