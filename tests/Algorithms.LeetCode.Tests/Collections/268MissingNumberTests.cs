using System.Collections.Generic;
using Algorithms.LeetCode.Collections;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.Collections
{
    public class MissingNumberTests 
    {
        [TestCaseSource(nameof(GetMissingNumberCases))]
        public void GetMissingNumberV2(int[] nums, int result)
        {
            new MissingNumber().GetMissingNumberV2(nums).Should().Be(result);
        }
        
        [TestCaseSource(nameof(GetMissingNumberCases))]
        public void GetMissingNumber(int[] nums, int result)
        {
            new MissingNumber().GetMissingNumber(nums).Should().Be(result);
        }

        public static IEnumerable<TestCaseData> GetMissingNumberCases()
        {
            yield return new TestCaseData(new[] { 3, 0, 2 }, 1);
            yield return new TestCaseData(new[] { 0, 1 }, 2);
            yield return new TestCaseData(new[] { 0 }, 1);
            yield return new TestCaseData(new[] { 9,6,4,2,3,5,7,0,1 }, 8);
        }
    }
}