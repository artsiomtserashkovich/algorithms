namespace Algorithms.LeetCode.Collections
{
    // https://leetcode.com/problems/missing-number/
    public class MissingNumberXOR 
    {
        public int GetMissingNumber(int[] nums)
        {
            int xor = 0;
        
            for(int index = 0; index < nums.Length; index ++)
            {
                xor = xor ^ index ^ nums[index];
            }

            return xor;
        }
    }
}