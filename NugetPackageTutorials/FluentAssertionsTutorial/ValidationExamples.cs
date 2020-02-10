using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsTutorial
{
    public class ValidationExamples
    {
        private List<string> _nameList = new List<string>
        {
            "Nick", "John", "Theodoris", "Mike"
        };
        
        [Fact]
        public void ShouldContainItemInList()
        {
            _nameList.Should().ContainMatch("Theo*");
        }
        
        [Fact]
        public void ShouldNotContainItemInList()
        {
            _nameList.Should().NotContain("Zoe");
        }
    }
}