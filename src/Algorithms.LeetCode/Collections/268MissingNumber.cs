namespace Algorithms.LeetCode.Collections
{
    // https://leetcode.com/problems/missing-number/
    public class MissingNumber 
    {
        public int GetMissingNumber(int[] nums)
        {
            int totalSum = nums.Length * (nums.Length + 1) / 2;
        
            for(int index = 0; index < nums.Length; index ++)
            {
                totalSum -= nums[index];
            }

            return totalSum;
        }
        
        public int GetMissingNumberV2(int[] nums)
        {
            var presentedFlag = new bool[nums.Length + 1];
        
            for(int index = 0; index < nums.Length; index ++)
            {
                presentedFlag[nums[index]] = true;
            }
            for(int index = 0; index < nums.Length + 1; index ++)
            {
                if(!presentedFlag[index])
                {
                    return index;
                }
            }
        
            return nums.Length;
        }

    }
}