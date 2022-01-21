using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode.TwoPointers
{
    public class ThreeSumClosest 
    {
        public int Solution(int[] nums, int target)
        {
            if (nums.Length < 3)
            {
                throw new InvalidOperationException();
            }

            var result = nums[0] + nums[1] + nums[2];
            Array.Sort(nums);

            for (int firstIndex = 0; firstIndex < nums.Length - 2; firstIndex++)
            {
                if (firstIndex != 0 && nums[firstIndex] == nums[firstIndex + 1])
                {
                    continue;
                }
                
                int secondIndex = firstIndex + 1;
                int thirdIndex = nums.Length - 1;

                while (secondIndex < thirdIndex)
                {
                    result = GetClosest(
                        result,
                        nums[firstIndex] + nums[secondIndex] + nums[thirdIndex],
                        target);
                    
                    if (nums[firstIndex] + nums[secondIndex] + nums[thirdIndex] < target)
                    {
                        secondIndex++;
                    }
                    else if(nums[firstIndex] + nums[secondIndex] + nums[thirdIndex] > target)
                    {
                        thirdIndex--;
                    }
                    else
                    {
                        return target;
                    }
                    
                    while (secondIndex < thirdIndex && nums[secondIndex] == nums[secondIndex + 1])
                    {
                        secondIndex++;
                    }
                    while (secondIndex < thirdIndex && nums[thirdIndex - 1] == nums[thirdIndex])
                    {
                        thirdIndex--;
                    }
                }
            }

            return result;
        }
        
        private int GetClosest(int first, int second, int target)
        {
            if (Math.Abs(target - first) < Math.Abs(target - second))
            {
                return first;
            }

            return second;
        }
    }
}