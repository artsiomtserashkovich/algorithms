using System;
using System.Linq;

namespace Algorithms.LeetCode.Collections
{
    public class LongestUnrepeatingSubarrays 
    {
        public int GetLengthOfLongestSubstring(string s) 
        {
            var max = s.Length == 0 ? 0 : 1;
            var occuredLetter = new int[256];
            var symbols = s.ToArray();

            int index = 1;
            for(int startIndex = 0; startIndex < symbols.Length;)
            {
                int? collisionIndex = null;
                occuredLetter[symbols[startIndex]] = startIndex + 1;
                
                for(;index < symbols.Length; index++)
                {
                    if(occuredLetter[symbols[index]] == 0)
                    {
                        max = Math.Max(max, index - startIndex + 1);
                        occuredLetter[symbols[index]] = index + 1;
                    }
                    else
                    {
                        collisionIndex = occuredLetter[symbols[index]];
                        index++;
                        break;
                    }
                }
            
                if(collisionIndex == null)
                {
                    break;
                }
                else
                {
                    for(;startIndex < collisionIndex; startIndex++ )
                    {
                        occuredLetter[symbols[startIndex]] = 0;
                    }
                }
            }
        
        
            return max;
        }
        
        public int GetLengthOfLongestSubstringV2(string s) 
        {
            var max = 0;
            var occuredLetter = new int[257];
            var symbols = s.ToArray();

            for(int index = 0, previousOccured = 0; index < symbols.Length; index++)
            {
                // Two purpose:
                // 1) check previous occurred of current symbol (symbols[index])
                // 2) store recent previous occured of previous symbol 
                previousOccured = Math.Max(
                    occuredLetter[symbols[index]] == 0 ? 0 : occuredLetter[symbols[index]],
                    previousOccured);
                
                max = Math.Max(max, index - previousOccured + 1);

                occuredLetter[symbols[index]] = index + 1;
            }
            
            return max;
        }
    }
}