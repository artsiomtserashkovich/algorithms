public class NextGreaterElementI 
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2) 
    {
        var result = new int[nums1.Length];
        var hashmap = new Dictionary<int, int>(); // key = nums[i], value = value of next greater number
        var stack = new Stack<int>();
        
        
        for(int index = 0; index < nums2.Length; index++)
        {
            while(stack.Any() && nums2[stack.Peek()] < nums2[index])
            {
                var elementIndex = stack.Pop();
                
                hashmap[nums2[elementIndex]] = nums2[index];
            }
            
            stack.Push(index);
        }
        
        for(int index = 0; index < nums1.Length; index++)
        {
            result[index] = hashmap.TryGetValue(nums1[index], out var offset) ? offset : -1;
        }
        
        return result;
    }
}
