using Algorithms.LeetCode.UnionFind.Sets;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.UnionFind.Sets
{
    public class WeightedQuickUnionSetTests
    {
        [Test]
        public void Test()
        {
            var set = new WeightedQuickUnionSet(5);

            set.GetConnectedCount(0).Should().Be(1);
            set.GetConnectedCount(1).Should().Be(1);
            set.GetConnectedCount(2).Should().Be(1);
            set.GetConnectedCount(3).Should().Be(1);
            set.GetConnectedCount(4).Should().Be(1);

            set.IsConnected(4, 1).Should().BeFalse();
            set.IsConnected(3, 1).Should().BeFalse();
            set.IsConnected(3, 2).Should().BeFalse();
            set.IsConnected(3, 4).Should().BeFalse();
            set.IsConnected(0, 1).Should().BeFalse();
            set.IsConnected(0, 2).Should().BeFalse();
            set.IsConnected(0, 4).Should().BeFalse();
            
            set.Union(4, 1);
            set.IsConnected(4, 1).Should().BeTrue();
            set.GetConnectedCount(4).Should().Be(2);
            set.GetConnectedCount(1).Should().Be(2);
            set.GetConnectedCount(0).Should().Be(1);
            
            set.Union(1, 2);
            set.IsConnected(4, 1).Should().BeTrue();
            set.IsConnected(4, 2).Should().BeTrue();
            set.IsConnected(2, 1).Should().BeTrue();
            set.GetConnectedCount(2).Should().Be(3);
            set.GetConnectedCount(1).Should().Be(3);
            set.GetConnectedCount(0).Should().Be(1);
            
            set.IsConnected(0, 3).Should().BeFalse();
            
            set.Union(0, 3);
            set.IsConnected(4, 1).Should().BeTrue();
            set.IsConnected(4, 2).Should().BeTrue();
            set.IsConnected(2, 1).Should().BeTrue();
            set.IsConnected(0, 3).Should().BeTrue();
            set.IsConnected(3, 3).Should().BeTrue();
            set.GetConnectedCount(2).Should().Be(3);
            set.GetConnectedCount(1).Should().Be(3);
            set.GetConnectedCount(4).Should().Be(3);
            set.GetConnectedCount(0).Should().Be(2);
            set.GetConnectedCount(3).Should().Be(2);
            
            set.IsConnected(3, 1).Should().BeFalse();
            set.IsConnected(3, 2).Should().BeFalse();
            set.IsConnected(3, 4).Should().BeFalse();
            set.IsConnected(0, 1).Should().BeFalse();
            set.IsConnected(0, 2).Should().BeFalse();
            set.IsConnected(0, 4).Should().BeFalse();
            set.Union(3, 1);
            set.IsConnected(4, 1).Should().BeTrue();
            set.IsConnected(4, 2).Should().BeTrue();
            set.IsConnected(2, 1).Should().BeTrue();
            set.IsConnected(0, 3).Should().BeTrue();
            set.IsConnected(3, 3).Should().BeTrue();
            set.IsConnected(3, 1).Should().BeTrue();
            set.IsConnected(3, 2).Should().BeTrue();
            set.IsConnected(3, 4).Should().BeTrue();
            set.IsConnected(0, 1).Should().BeTrue();
            set.IsConnected(0, 2).Should().BeTrue();
            set.IsConnected(0, 4).Should().BeTrue();
            set.GetConnectedCount(0).Should().Be(5);
            set.GetConnectedCount(1).Should().Be(5);
            set.GetConnectedCount(4).Should().Be(5);
        }
    }
}