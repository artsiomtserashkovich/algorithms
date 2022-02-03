using System;
using Algorithms.LeetCode.UnionFind.Sets;

namespace Algorithms.LeetCode.UnionFind
{
    public class SurroundedRegions 
    {
        public void Solve(char[][] board) 
        {
            int? firstRegionRow = null;
            int? firstRegionCol = null;
            
            var wqumSet = new WQUMatrixSet(board.Length, board[0].Length);
            
            for(int row = 0; row < board.Length; row++)
            {
                for(int col = 0; col < board[0].Length; col++)
                {
                    if(board[row][col] == 'O')
                    {
                        if(row == 0 || col == 0 || row == board.Length - 1 || col == board[0].Length - 1)
                        {
                            if(firstRegionRow == null || firstRegionCol == null)
                            {
                                firstRegionRow = row;
                                firstRegionCol = col;
                            }
                            else
                            {
                                wqumSet.Union((firstRegionRow.Value, firstRegionCol.Value), (row, col));
                            }
                        }
                        else
                        {
                            if (IsValid(row - 1, col, board) && board[row - 1][col] == 'O')
                            {
                                wqumSet.Union((row, col), (row - 1, col));
                            }
                            if (IsValid(row, col - 1, board) && board[row][col - 1] == 'O')
                            {
                                wqumSet.Union((row, col), (row, col - 1));
                            }
                            if (IsValid(row + 1, col, board) && board[row + 1][col] == 'O')
                            {
                                wqumSet.Union((row, col), (row + 1, col));
                            }
                            if (IsValid(row, col + 1, board) && board[row][col + 1] == 'O')
                            {
                                wqumSet.Union((row, col), (row, col + 1));
                            }
                        }
                    }
                }
            }
            
            for(int row = 0; row < board.Length; row++)
            {
                for(int col = 0; col < board[0].Length; col++)
                {
                    var notFound = (firstRegionRow == null || firstRegionCol == null);
                    var connected = !notFound && wqumSet.IsConnected((firstRegionRow.Value, firstRegionCol.Value), (row, col));
                    
                    if(!connected)
                    {
                        board[row][col] = 'X';
                    }
                    else
                    {
                        board[row][col] = 'O';
                    }
                }
            }
        }
    
        private static bool IsValid(int row, int col, char[][] grid)
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