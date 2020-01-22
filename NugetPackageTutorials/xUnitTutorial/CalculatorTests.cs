using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace xUnitTutorial
{
    public class CalculatorTests
    {
        private readonly Calculator _sut;

        public CalculatorTests()
        {
            _sut = new Calculator();
        }

        [Fact(Skip = "This test is broken")]
        public void AddTwoNumbersShouldEqualTheirEqual()
        {
            _sut.Add(5);
            _sut.Add(8);
            Assert.Equal(13, _sut.Value);
        }
        
        [Theory]
        [InlineData(13, 5, 8)]
        [InlineData(0, -3, 3)]
        [InlineData(0, 0, 0)]
        public void AddTwoNumbersShouldEqualTheirEqualTheory(
            decimal expected, decimal firstToAdd, decimal secondToAdd)
        {
            _sut.Add(firstToAdd);
            _sut.Add(secondToAdd);
            Assert.Equal(expected, _sut.Value);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AddManyNumbersShouldEqualTheirEqualTheory(
            decimal expected, params decimal[] valuesToAdd)
        {
            foreach (var value in valuesToAdd)
            {
                _sut.Add(value);
            }

            Assert.Equal(expected, _sut.Value);
        }
        
        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void DivideManyNumbersTheory(
            decimal expected, params decimal[] valuesToAdd)
        {
            foreach (var value in valuesToAdd)
            {
                _sut.Divide(value);
            }

            Assert.Equal(expected, _sut.Value);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {15, new decimal[] { 10, 5 }};
            yield return new object[] {15, new decimal[] { 5, 5, 5 }};
            yield return new object[] {-10, new decimal[] { -30, 20 }};
        }
    }

    public class DivisionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {30, new decimal[] { 60, 2 }};
            yield return new object[] {0, new decimal[] { 0, 1 }};
            yield return new object[] {1, new decimal[] { 50, 50 }};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}