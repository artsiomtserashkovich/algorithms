using System;
using System.Collections.Generic;
using Algorithms.LeetCode.TwoPointers;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.TwoPointers
{
    public class ThreeSumTests 
    {
        [TestCaseSource(nameof(GetThreeSumCases))]
        public void Solution(int[] nums, IList<IList<int>> result)
        {
            new ThreeSum().Solution(nums).Should().BeEquivalentTo(result);
        }

        public static IEnumerable<TestCaseData> GetThreeSumCases()
        {
            yield return new TestCaseData(
                new[] { -1, 0, 1, 2, -1,-4 }, 
                new List<IList<int>>
                {
                    new List<int> { -1, -1, 2 },
                    new List<int> { -1, 0, 1 },
                });
            yield return new TestCaseData(
                Array.Empty<int>(), 
                new List<IList<int>>());
            yield return new TestCaseData(
                new[] { 0 }, 
                new List<IList<int>>());
        }    
    }
}