using System.Collections.Generic;
using Algorithms.LeetCode.BackTracking;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.BackTracking
{
    public class BackTrackingTests
    {
        private Backtracking _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Backtracking();
        }
        
        [TestCaseSource(nameof(GetSubsetsTestCases))]
        public void DistinctSubsetsV1(int[] nums, IList<IList<int>> result)
        {
            _sut.DistinctSubsetsV1(nums).Should().BeEquivalentTo(result);
        }
        
        [TestCaseSource(nameof(GetSubsetsTestCases))]
        public void DistinctSubsetsV2(int[] nums, IList<IList<int>> result)
        {
            _sut.DistinctSubsetsV2(nums).Should().BeEquivalentTo(result);
        }
        
        [TestCaseSource(nameof(GetSubsetsTestCases))]
        public void DistinctSubsetsV3(int[] nums, IList<IList<int>> result)
        {
            _sut.DistinctSubsetsV3(nums).Should().BeEquivalentTo(result);
        }

        public static IEnumerable<TestCaseData> GetSubsetsTestCases()
        {
            yield return new TestCaseData(
                new[] { 1, 2, 3 },
                new List<IList<int>>
                {
                    new List<int>(),
                    new List<int> {1},
                    new List<int> {2},
                    new List<int> {1, 2},
                    new List<int> {3},
                    new List<int> {1, 3},
                    new List<int> {2, 3},
                    new List<int> {1, 2, 3}
                });
                
            yield return new TestCaseData(
                new[] { 1, 2, 2 },
                new List<IList<int>>
                {
                    new List<int>(),
                    new List<int> {1},
                    new List<int> {2},
                    new List<int> {1, 2},
                    new List<int> {3},
                    new List<int> {1, 3},
                    new List<int> {2, 3},
                    new List<int> {1, 2, 3}
                });
        }
    }
}