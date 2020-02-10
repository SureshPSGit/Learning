using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsTutorial
{
    public class CalculatorTests
    {
        private readonly Calculator _sut;

        public CalculatorTests()
        {
            _sut = new Calculator();
        }
        
        [Theory]
        [InlineData(13, 5, 8)]
        [InlineData(0, -3, 3)]
        [InlineData(0, 0, 0)]
        public void Add_ShouldAddTwoNumbers_WhenTheAdditionIsValid(
            decimal expected, decimal firstToAdd, decimal secondToAdd)
        {
            // Arrange
            _sut.Add(firstToAdd);
            _sut.Add(secondToAdd);
            
            // Act
            var result = _sut.Value;
            
            // Assert
            Assert.Equal(expected, result);
            Assert.StartsWith("The result is: ", _sut.Text);
            Assert.EndsWith(result.ToString(), _sut.Text);
        }
        
        [Theory]
        [InlineData(13, 5, 8)]
        [InlineData(0, -3, 3)]
        [InlineData(0, 0, 0)]
        public void Add_ShouldAddTwoNumbers_WhenTheAdditionIsValidFa(
            decimal expected, decimal firstToAdd, decimal secondToAdd)
        {
            // Arrange
            _sut.Add(firstToAdd);
            _sut.Add(secondToAdd);
            
            // Act
            var result = _sut.Value;
            
            // Assert
            result.Should().Be(expected);
            _sut.Text.Should().StartWith("The result is: ");
            _sut.Text.Should().EndWith(result.ToString());
        }

        [Theory]
        [MemberData(nameof(AddTestData))]
        public void Add_ShouldAddManyNumbers_WhenTheAdditionIsValid(
            decimal expected, params decimal[] valuesToAdd)
        {
            // Arrange
            foreach (var value in valuesToAdd)
            {
                _sut.Add(value);
            }
            
            // Act
            var result = _sut.Value;
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [MemberData(nameof(MultiplyWithZeroTestData))]
        public void Multiply_ShouldReturnZero_WhenOneOfTheNumbersIsZero(
            params decimal[] valuesToMultiply)
        {
            // Arrange
            foreach (var value in valuesToMultiply)
            {
                _sut.Multiply(value);
            }
            
            // Act
            var result = _sut.Value;
            
            // Assert
            Assert.Equal(0, result);
        }
        
        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void Divide_ShouldDivideManyNumbers_WhenTheDivisionIsValid(
            decimal expected, params decimal[] valuesToAdd)
        {
            // Arrange
            foreach (var value in valuesToAdd)
            {
                _sut.Divide(value);
            }
            
            // Act
            var result = _sut.Value;
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_ShouldThrowDivideByZeroException_WhenDividingWithZero()
        {
            // Arrange
            _sut.Divide(50);
            
            // Act
            Func<object> resultFunc = () => _sut.Divide(0);

            // Assert
            var exception = Assert.Throws<DivideByZeroException>(resultFunc);
            Assert.Equal("Attempted to divide by zero.", exception.Message);
        }
        
        [Fact]
        public void Divide_ShouldThrowDivideByZeroException_WhenDividingWithZeroFa()
        {
            // Arrange
            _sut.Divide(50);
            
            // Act
            Func<object> resultFunc = () => _sut.Divide(0);

            // Assert
            resultFunc.Should().Throw<DivideByZeroException>().WithMessage("Attempted to divide by zero.");
        }

        public static IEnumerable<object[]> AddTestData()
        {
            yield return new object[] {15, new decimal[] { 10, 5 }};
            yield return new object[] {15, new decimal[] { 5, 5, 5 }};
            yield return new object[] {-10, new decimal[] { -30, 20 }};
        }
        
        public static IEnumerable<object[]> MultiplyWithZeroTestData()
        {
            yield return new object[] {new decimal[] { 0, 5, 10, 0 }};
            yield return new object[] {new decimal[] { 0 }};
            yield return new object[] {new decimal[] { -30, 0 }};
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