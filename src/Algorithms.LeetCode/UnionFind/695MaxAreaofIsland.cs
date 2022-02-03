using System;
using Algorithms.LeetCode.UnionFind.Sets;

namespace Algorithms.LeetCode.UnionFind
{
    // TimeComplexity = O(n*m) -> n = rowSize; m = colSize;
    // MemoryComplexity = O(n*m) -> n = rowSize; m = colSize;
    public class MaxAreaOfIsland 
    {
        public int GetMaxAreaOfIsland(int[][] grid)
        {
            var maxArea = 0;
            var visited = new bool[grid.Length, grid[0].Length];
            
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col ++)
                {
                    if (grid[row][col] == 1 && !visited[row, col])
                    {
                        maxArea = Math.Max(maxArea, GetIslandAreaDFS(grid, row, col, visited));
                    }
                }
            }


            return maxArea;
        }

        private static int GetIslandAreaDFS(int[][] grid, int row, int col, bool[,] visited)
        {
            if (visited[row, col])
            {
                return 0;
            }
            visited[row, col] = true;
            int area = 1;

            if ((row !=0) && (grid[row -1][col] == 1) && (!visited[row -1, col]))
            {
                area += GetIslandAreaDFS(grid, row - 1, col, visited);
            }
            
            if ((col !=0) && (grid[row][col - 1] == 1) && (!visited[row, col - 1]))
            {
                area += GetIslandAreaDFS(grid, row, col - 1, visited);
            }

            if ((row != grid.Length - 1) && (grid[row + 1][col] == 1) && (!visited[row + 1, col]))
            {
                area += GetIslandAreaDFS(grid, row + 1, col, visited);
            }
            
            if ((col != grid[0].Length - 1) && grid[row][col + 1] == 1 && !visited[row, col + 1])
            {
                area += GetIslandAreaDFS(grid, row, col + 1, visited);
            }

            return area;
        }
        
        
        public int GetMaxAreaOfIslandV2(int[][] grid)
        {
            var maxArea = 0;
            var unionSet = new WQUMatrixSet(grid.Length, grid[0].Length);
            
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col ++)
                {
                    if (grid[row][col] == 1)
                    {
                        if (
                            IsValid(row - 1, col, grid) &&
                            grid[row - 1][col] == 1 &&
                            !unionSet.IsConnected((row, col), (row - 1, col)))
                        {
                            unionSet.Union((row, col), (row - 1, col));
                        }
                        if (
                            IsValid(row, col - 1, grid) &&
                            grid[row][col - 1] == 1 &&
                            !unionSet.IsConnected((row, col), (row, col - 1)))
                        {
                            unionSet.Union((row, col), (row, col - 1));
                        }
                        if (
                            IsValid(row + 1, col, grid) &&
                            grid[row + 1][col] == 1 &&
                            !unionSet.IsConnected((row, col), (row + 1, col)))
                        {
                            unionSet.Union((row, col), (row + 1, col));
                        }
                        if (
                            IsValid(row, col + 1, grid) &&
                            grid[row][col + 1] == 1 &&
                            !unionSet.IsConnected((row, col), (row, col + 1)))
                        {
                            unionSet.Union((row, col), (row, col + 1));
                        }

                        maxArea = Math.Max(maxArea, unionSet.GetConnectedCount(row, col));
                    }
                }
            }


            return maxArea;
        }

        private static bool IsValid(int row, int col, int[][] grid)
        {
            if (row < 0)
                return false;
            if (col < 0)
                return false;
            if (row >= grid.Length)
                return false;
            if (col >= grid[0].Length)
                return false;

            return true;
        }
    }
}