using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests
{
    public class LRUCacheTests 
    {
        [Test]
        public void Test()
        {
            var cache = new LRUCache(2);
            
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1).Should().Be(1);
            cache.Put(3,3);
            cache.Get(2).Should().Be(2);
            cache.Put(4,4);
            cache.Get(1).Should().Be(-1);
            cache.Get(3).Should().Be(3);
            cache.Get(4).Should().Be(4);
        }
    }
}