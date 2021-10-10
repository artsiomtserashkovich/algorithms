using Algorithms.Intuit.DynamicProgramming;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Intuit.Tests.DynamicProgramming
{
    public class FibonacciNumbersTests
    {
        private FibonacciNumbers _sut;
        
        [SetUp]
        public void Setup()
        {
            _sut = new FibonacciNumbers();
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 8)]
        [TestCase(7, 13)]
        [TestCase(8, 21)]
        public void RecursionGet_ProvideN_ShouldCalculateNumber(int n, int result)
        {
            _sut.RecursionGet(n).Should().Be(result);
        }
        
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 8)]
        [TestCase(7, 13)]
        [TestCase(8, 21)]
        public void DynamicGet_ProvideN_ShouldCalculateNumber(int n, int result)
        {
            _sut.DynamicGet(n).Should().Be(result);
        }
    }
}