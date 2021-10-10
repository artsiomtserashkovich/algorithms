using Algorithms.Intuit.DynamicProgramming;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Intuit.Tests.DynamicProgramming
{
    public class CombinationsTests
    {
        private Combinations _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Combinations();
        }

        [TestCase(1, 2)]
        [TestCase(2, 4)]
        [TestCase(3, 6)]
        [TestCase(4, 10)]
        public void GetPetStoreCombination(int cellNumber, int result)
        {
            _sut.GetPetStoreCombination(cellNumber).Should().Be(result);
        }
    }
}