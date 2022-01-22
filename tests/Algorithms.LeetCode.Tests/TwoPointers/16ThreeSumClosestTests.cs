using System;
using System.Collections.Generic;
using Algorithms.LeetCode.TwoPointers;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.TwoPointers
{
    public class ThreeSumClosestTests 
    {
        [TestCaseSource(nameof(GetThreeSumClosestCases))]
        public void Solution(int[] nums, int target, int result)
        {
            new ThreeSumClosest().Solution(nums, target).Should().Be(result);
        }

        public static IEnumerable<TestCaseData> GetThreeSumClosestCases()
        {
            yield return new TestCaseData(
                new[] { -1, 2, 1, -4 }, 
                1,
                2);
            yield return new TestCaseData(
                new[] { 0,0,0 }, 
                1,
                0);
            yield return new TestCaseData(
                new[] { -1, 0, 1, 1, 55 }, 
                3,
                2);
            yield return new TestCaseData(
                new[] { -4,-7,-2,2,5,-2,1,9,3,9,4,9,-9,-3,7,4,1,0,8,5,-7,-7 }, 
                29,
                27);
        }   
    }
}