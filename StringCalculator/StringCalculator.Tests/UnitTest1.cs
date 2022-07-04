using NUnit.Framework;
using System;

namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1,2", ExpectedResult = 3)]
        [TestCase("1,2,3", ExpectedResult = 6)]
        [TestCase("'2'3", ExpectedResult = 5)]
        [TestCase(";\n2;3", ExpectedResult = 5)]
        [TestCase("a\n2a3", ExpectedResult = 5)]
        [TestCase("1,20002,3", ExpectedResult = 4)]
        [TestCase("2232,1002,3", ExpectedResult = 3)]
        [TestCase("[***]1***2***3", ExpectedResult = 6)]
        [TestCase("[*][%]\n1*0%2*2%3", ExpectedResult = 8)]
        public int Add_ValidNumbers_ReturnsSum(string numbers)
        {
            // Act
            var actual = StringCalculator.Add(numbers);

            // Assert
            return actual;
        }

        [TestCase("", ExpectedResult = 0)]
        public int Add_InvalidString_ReturnsZero(string numbers)
        {
            // Act
            var actual = StringCalculator.Add(numbers);

            // Assert
            return actual;
        }

        [TestCase("-3,-1,4,1,-2")]
        public void Add_InvalidString_ReturnsNegativeNumbersException(string numbers)
        {
            Assert.Throws(Is.TypeOf<FormatException>()
                    .And.Message.EqualTo("Negatives not allowed: -3 -1 -2"),
                    () => StringCalculator.Add(numbers));
        }
    }
}