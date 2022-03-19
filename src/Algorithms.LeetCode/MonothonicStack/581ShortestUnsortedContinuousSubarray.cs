public class ShortestUnsortedContinuousSubarray 
{
    public int FindUnsortedSubarray(int[] nums) 
    {
        int begin = 0;
        int max = nums[0];
        
        int end = 0;
        int reverseMin = nums[nums.Length - 1];
        
        for(int index = 1; index < nums.Length; index++)
        {
            max = Math.Max(max, nums[index]);
            if(max > nums[index])
            {
                end = index;
            }
            
            /////////////////////////////////////////////
            // Could be implemented using monothon stack (that keep head as a minimal element) => if(stack.peek() < cur_value) => save index as begin
            int reverseIndex = nums.Length - 1 - index;
            reverseMin = Math.Min(reverseMin, nums[reverseIndex]);
            if(reverseMin < nums[reverseIndex])
            {
                begin = reverseIndex;
            }
        }
        
        return end <= begin ? 0 : end - begin + 1;
    }
}
