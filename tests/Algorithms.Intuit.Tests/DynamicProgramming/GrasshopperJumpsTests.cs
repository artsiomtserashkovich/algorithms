using System;
using System.Linq;
using Algorithms.Intuit.DynamicProgramming;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Intuit.Tests.DynamicProgramming
{
    public class GrasshopperJumpsTests
    {
        private GrasshopperJumps _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new GrasshopperJumps();
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 4)]
        [TestCase(4, 7)]
        [TestCase(5, 13)]
        public void TripleStepsGet(int n, int result)
        {
            _sut.TripleStepsGet(n).Should().Be(result); 
        }
        
        [TestCase(3,1, 1)]
        [TestCase(3,2, 2)]
        [TestCase(3,3, 4)]
        [TestCase(3,4, 7)]
        [TestCase(3,5, 13)] 
        public void KStepsGet(int k, int n, int result)
        {
            _sut.KStepsGet(k, n).Should().Be(result); 
        }

        [Test]
        public void GetMaxEarned()
        {
            var taxes = new[] {0, 2, -5, -1, 3 ,0 };
            
            _sut.GetMaxEarned(2, 5, taxes).Should().Be(4); 
        }
        
        [Test]
        public void GetMaxEarnedPath()
        {
            var taxes = new[] {0, 2, -5, -1, 3 ,0 };
            
            var result = _sut.GetMaxEarnedPath(2, 5, taxes);
                
            result.First().Should().Be(5);
            foreach (var routePoint in result)
            {
                Console.WriteLine(routePoint);
            }
        }
    }
}