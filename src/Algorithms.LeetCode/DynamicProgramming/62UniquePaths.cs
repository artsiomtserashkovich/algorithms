namespace Algorithms.LeetCode.DynamicProgramming
{
    public class UniquePaths 
    {
        public int UniquePathsSolution(int m, int n) 
        {
            var paths = new int[m, n];
        
            for(int col = 0; col < n - 1; col ++)
            {
                paths[0, col] = 1;
            }
        
            for(int row = 1; row < m; row ++)
            {
                for(int col = 0; col < n; col ++)
                {
                    var upPaths = paths[row - 1, col];
                    var leftPaths = col == 0 ? 0 : paths[row, col - 1];
                
                    paths[row, col] = upPaths + leftPaths;
                }
            }
        
            return paths[m - 1, n - 1] + 1;
        }
    }
}