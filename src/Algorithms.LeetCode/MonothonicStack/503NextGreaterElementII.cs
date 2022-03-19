public class NextGreaterElementII 
{
    public int[] NextGreaterElements(int[] nums) 
    {
        var result = new int[nums.Length];
        var stack = new Stack<int>();
        
        int max = nums[0];
        
        for(int index = 0; index < nums.Length; index++)
        {
            while(stack.Any() && nums[stack.Peek()] < nums[index])
            {
                int j = stack.Pop();
                
                result[j] = nums[index];
            }
            
            max = Math.Max(max, nums[index]);
            
            stack.Push(index);
        }
        
        for(int index = 0; index < nums.Length; index++)
        {
            while(nums[stack.Peek()] < nums[index])
            {
                int j = stack.Pop();
                
                result[j] = nums[index];
            }
            
            if(nums[index] == max)
            {
                result[index] = -1;
            }
            
            stack.Push(index);
        }
        
        return result;
    }
}
