using System.Collections.Generic;
using Algorithms.LeetCode.UnionFind;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.UnionFind
{
    public class MaxAreaofIslandTests 
    {
        [TestCaseSource(nameof(GetMaxAreaofIslandCases))]
        public void Solution(int[][] grid, int result)
        {
            new MaxAreaOfIsland().GetMaxAreaOfIsland(grid).Should().Be(result);
        }

        public static IEnumerable<TestCaseData> GetMaxAreaofIslandCases()
        {
            yield return new TestCaseData(
            new int[][]
            {
                        
                    
                new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0},
                new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0},
                new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0},
                new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0}
            }, 6);
            
        }
    }
}