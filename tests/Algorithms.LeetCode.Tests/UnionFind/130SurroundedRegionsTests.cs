using System.Collections.Generic;
using Algorithms.LeetCode.UnionFind;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.UnionFind
{
    public class SurroundedRegionsTests 
    {
        [TestCaseSource(nameof(GetMaxAreaofIslandCases))]
        public void Solution(char[][] grid, char[][] result)
        {
            new SurroundedRegions().Solve(grid);

            grid.Should().BeEquivalentTo(result);
        }

        public static IEnumerable<TestCaseData> GetMaxAreaofIslandCases()
        {
            yield return new TestCaseData(
                new char[][]
                {
                    new char[] {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','X','X','X','X','O','O','O','X','X','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','O','O','O','X','O','X','O','X','X','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','O','X','O','X','O','X','O','O','O','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','O','X','O','O','O','X','X','X','X','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','O','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
                }, 
                new char[][]
                {
                    new char[] {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','X','X','X','X','O','O','O','X','X','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','O','O','O','X','O','X','O','X','X','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','O','X','O','X','O','X','O','O','O','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','O','X','O','O','O','X','X','X','X','X','X','X','X','X','X'},
                    new char[] {'X','X','X','X','X','O','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
                });
        }
    }
}
