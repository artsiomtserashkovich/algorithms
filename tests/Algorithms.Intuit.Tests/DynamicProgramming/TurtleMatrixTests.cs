using Algorithms.Intuit.DynamicProgramming;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Intuit.Tests.DynamicProgramming
{
    public class TurtleMatrixTests
    {
        private TurtleMatrix _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new TurtleMatrix();
        }

        [TestCase(0, 0, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 2)]
        [TestCase(2, 2, 6)]
        [TestCase(3, 3, 20)]
        [TestCase(4, 4, 70)]
        public void GetCountOfRoutes(int row, int column, int result)
        {
            _sut.GetCountOfRoutes(row, column).Should().Be(result);
        }
    }
}