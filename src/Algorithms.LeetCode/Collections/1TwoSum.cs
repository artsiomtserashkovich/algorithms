using System.Collections.Generic;

namespace Algorithms.LeetCode.Collections
{
    // https://leetcode.com/problems/two-sum/
    public class TwoSum 
    {
        public int[] GetSumPair(int[] nums, int target) {
        
            var previousElements = new Dictionary<int, int>();
        
        
            for(var index = 0; index < nums.Length; index++)
            {
                if(previousElements.TryGetValue(target - nums[index], out var previousElementIndex))
                {
                    return new [] { previousElementIndex, index };
                }
                else 
                {
                    previousElements[nums[index]] = index;
                }
            
            }
        
            return null;
        }
    }
}