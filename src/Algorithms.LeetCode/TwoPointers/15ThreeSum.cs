using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode.TwoPointers
{
    // Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
    // such that i != j, i != k, and j != k,
    // and nums[i] + nums[j] + nums[k] == 0.

   // Notice that the solution set must not contain duplicate triplets.
    public class ThreeSum 
    {
        public IList<IList<int>> Solution(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length < 3)
            {
                return result;
            }
            Array.Sort(nums);
            
            for (var index = 0; index < nums.Length - 2; index++)
            {
                var frontIndex = index + 1;
                var backIndex = nums.Length - 1;

                while (frontIndex < backIndex)
                {
                    if (nums[index] + nums[frontIndex] + nums[backIndex] > 0)
                    {
                        backIndex --;
                    }
                    else if (nums[index] + nums[frontIndex] + nums[backIndex] < 0)
                    {
                        frontIndex ++;
                    }
                    else
                    {
                        result.Add(
                            new List<int> 
                                { nums[index], nums[frontIndex], nums[backIndex] });

                        while(frontIndex < backIndex && nums[frontIndex] == nums[frontIndex + 1])
                        {
                            frontIndex ++;
                        }
                        
                        while(frontIndex < backIndex && nums[backIndex - 1] == nums[backIndex])
                        {
                            backIndex --;
                        }
                        
                        frontIndex ++;
                        backIndex --;
                    }
                }

                if (index < nums.Length - 2 && nums[index] == nums[index + 1])
                {
                    index ++;
                }
            }

            return result;
        }
    }
}