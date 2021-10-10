namespace Algorithms.LeetCode.Collections
{
    public class SingleNumber 
    {
        public int GetSingleNumber(int[] nums)
        {
            int xor = 0;

            foreach (var num in nums)
            {
                xor ^= num;
            }

            return xor;
        }
    }
}