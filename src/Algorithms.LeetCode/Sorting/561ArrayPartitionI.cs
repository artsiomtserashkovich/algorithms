public class ArrayPartitionI 
{
    public int ArrayPairSum(int[] nums) 
    {
        Array.Sort(nums);
        
        int result = 0;
        
        for(int index = 0; index < nums.Length; index += 2)
        {
            result += Math.Min(nums[index], nums[index + 1]); 
        }
        
        return result;
    }
}
