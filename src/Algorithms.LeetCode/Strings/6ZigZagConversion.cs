using System.Linq;
using System.Text;

namespace Algorithms.LeetCode.Strings
{
    // https://leetcode.com/problems/zigzag-conversion/
    public class ZigZagConversion 
    {
        public string Convert(string s, int numRows) 
        {
            var symbols = s.ToArray();
            var builder = new StringBuilder();
            var zigZagOffset = GetZigZagOffset(numRows);
        
            for(int row = 0; row < numRows; row++)
            {
                for(int offset = 0; offset < symbols.Length; offset += zigZagOffset)
                {
                    AppendIfIndexNotNull(builder, GetColIndex(row, offset, symbols.Length), symbols);
                
                    if(row != 0 && row != numRows - 1)
                    {
                        AppendIfIndexNotNull(builder, GetMiddleColIndex(row, offset, numRows, symbols.Length), symbols);
                    }
                }
            }
            
            return builder.ToString();
        }
    
        private static int GetZigZagOffset(int numRows)
        {
            if(numRows < 2)
            {
                return numRows;
            }
        
            return numRows + (numRows - 2);
        }
    
        private static int? GetColIndex(int row, int offset, int maxLength)
        {
            var index = offset + row; 
        
            return index < maxLength ? index : (int?)null;
        }
    
        private static int? GetMiddleColIndex(int row, int offset, int numRows, int maxLength)
        {
            var index = offset + (numRows - 1) + (numRows - 1 - row); 
        
            return index < maxLength ? index : (int?)null;
        }
    
        private static void AppendIfIndexNotNull(StringBuilder builder, int? index, char[] symbols)
        {
            if(index != null)
            {
                builder.Append(symbols[index.Value]);
            }
        }
    }
}