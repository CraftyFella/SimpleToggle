﻿using Shouldly;
using SimpleToggle.Tests.Specs._contexts;
using Xunit;

namespace SimpleToggle.Tests.Specs.getting_toggle_status
{
    public class toggle_turned_on_in_second_provider : toggle_context
    {
        public toggle_turned_on_in_second_provider()
        {
            toggle_on_in<MyToggle>(new InMemoryProvider());
        }
        
        [Fact]
        public void is_enabled()
        {
            is_toggle_enabled<MyToggle>().ShouldBe(true);
        }
    }
}