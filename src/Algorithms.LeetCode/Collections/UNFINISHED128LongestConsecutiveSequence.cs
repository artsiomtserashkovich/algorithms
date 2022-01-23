using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode.Collections
{
    public class LongestConsecutiveSequence 
    {
        public int LongestConsecutive(int[] nums) 
        {
            int result = 0;
            var dict = new Dictionary<int, int>();
        
            foreach (var num in nums)
            {
                int rangeEnd = num;
                int rangeStart = num;
            
                if(!dict.ContainsKey(num))
                {
                    int? lowerRangeStart = null;
                    int? lowerRangeEnd = null;
                    
                    int? higherRangeStart = null;
                    int? higherRangedEnd = null;
                    
                    if(dict.TryGetValue(num - 1, out var ls))
                    {
                        lowerRangeStart = ls;
                        lowerRangeEnd = dict[ls];
                    }

                    if(dict.TryGetValue(num + 1, out var he))
                    {
                        higherRangedEnd = he;
                        higherRangeStart = dict[he];
                    }

                    if (lowerRangeStart != null || higherRangeStart != null)
                    {
                        rangeStart = higherRangeStart == null || (lowerRangeStart < higherRangeStart) 
                            ? lowerRangeStart.Value 
                            : higherRangeStart.Value;
                    }

                    if (lowerRangeEnd != null || higherRangedEnd != null)
                    {
                        rangeEnd = lowerRangeEnd == null || lowerRangeEnd < higherRangedEnd
                            ? higherRangedEnd.Value
                            : lowerRangeEnd.Value;

                    }

                    dict[rangeStart] = rangeEnd;
                    dict[rangeEnd] = rangeStart;            
                }
            
                result = Math.Max(result, Math.Abs(rangeEnd - rangeStart) + 1);
            }
        
            return result;
        }
    }
}