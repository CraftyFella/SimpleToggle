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
            Feature.Register<MyToggle>();
            Feature.Register<MyToggle>();
        }

        [Fact]
        public void doesnt_add_another()
        {
            Feature.All.Count().ShouldBe(1);
            Feature.All.ShouldContain(Feature.NameFor<MyToggle>());
        }
    }
}