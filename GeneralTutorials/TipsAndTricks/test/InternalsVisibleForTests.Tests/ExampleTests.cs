using FluentAssertions;
using Xunit;

namespace InternalsVisibleForTests.Tests
{
    public class ExampleTests
    {
        [Fact]
        public void IsNickCreatingYoutubeVideos_Should_ReturnTrue()
        {
            var testClass = new ClassToTest();
            testClass.IsNickCreatingYoutubeVideos().Should().BeTrue();
        }
    }
}