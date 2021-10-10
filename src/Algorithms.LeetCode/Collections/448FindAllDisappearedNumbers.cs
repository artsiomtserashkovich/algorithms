using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode.Collections
{
    // https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
    public class FindAllDisappearedNumbers 
    {
        public IList<int> FindDisappearedNumbers(int[] nums) {
            var presentedFlag = new bool[nums.Length];
        
            foreach (var t in nums)
            {
                presentedFlag[t - 1] = true;
            }
        
            var missing = new List<int>();
        
            for(var index = 0; index < nums.Length; index ++)
            {
                if(!presentedFlag[index])
                {
                    missing.Add(index + 1);
                }
            }

            return missing;
        }
        
        public IList<int> FindDisappearedNumbersV2(int[] nums) {
            for(int index = 0; index < nums.Length; index++)
            {
                var numberIndex = Math.Abs(nums[index]) - 1;

                nums[numberIndex] = -Math.Abs(nums[numberIndex]);
            }
        
            var missing = new List<int>();
        
            for(var numberIndex = 0; numberIndex < nums.Length; numberIndex ++)
            {
                if(nums[numberIndex] > 0)
                {
                    missing.Add(numberIndex + 1);
                }
            }

            return missing;
        }
    }
}