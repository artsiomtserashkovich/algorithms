using System.Collections.Generic;
using Algorithms.LeetCode.Collections;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.Collections
{
    public class LongestConsecutiveSequenceTests
    {
        [TestCaseSource(nameof(GetLongestConsecutiveSequenceCases))]
        public void Solution(int[] nums, int result)
        {
            new LongestConsecutiveSequence().LongestConsecutive(nums).Should().Be(result);
        }

        public static IEnumerable<TestCaseData> GetLongestConsecutiveSequenceCases()
        {
            yield return new TestCaseData(new[] { 100, 4, 200, 1, 3, 2 }, 4);
            yield return new TestCaseData(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9);
            yield return new TestCaseData(
                new[] { -6, 6, -9, -7, 0, 3, 4, -2, 2, -1, 9, -9, 5, -3, 6, 1, 5, -1, -2, 9, -9, -4, -6, -5, 6, -1, 3},
                14);
        }
    }
}