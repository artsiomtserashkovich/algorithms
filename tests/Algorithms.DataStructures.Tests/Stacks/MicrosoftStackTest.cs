using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.DataStructures.Tests.Stacks
{
    public class MicrosoftStackTest
    {
        private Stack<int> _sut;
        
        [SetUp]
        public void Setup()
        {
            _sut = new Stack<int>();
        }

        [Test]
        public void Test()
        {
            _sut.Count.Should().Be(0);
            
            _sut.Push(3);

            _sut.Peek().Should().Be(3);
            
            _sut.Push(2);
            _sut.Push(1);

            _sut.Count.Should().Be(3);
            
            _sut.Pop().Should().Be(1);
            _sut.Count.Should().Be(2);
            
            _sut.Pop().Should().Be(2);
            _sut.Pop().Should().Be(3);
            _sut.Count.Should().Be(0);
        }
    }
}