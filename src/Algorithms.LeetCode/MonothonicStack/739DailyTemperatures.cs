public class DailyTemperatures 
{
    public int[] DailyTemperaturesV3(int[] temperatures) 
    {
        if(temperatures.Length == 0)
        {
            return Array.Empty<int>();
        }
        var stack = new Stack<int>();
        var result = new int[temperatures.Length];
        
        for(int i = 0; i < temperatures.Length; i++)
        {
            while(stack.Any() && temperatures[i]  > temperatures[stack.Peek()])
            {
                var index = stack.Pop();
                result[index] = i - index;
            }
            
            stack.Push(i);
        }
        
        return result;
    }
    
    public int[] DailyTemperaturesV2(int[] temperatures) 
    {
        if(temperatures.Length == 0)
        {
            return Array.Empty<int>();
        }
        var heap = new PriorityQueue<int, int>();
        var result = new int[temperatures.Length];
        
        heap.Enqueue(0, temperatures[0]);
        
        for(int i = 1; i < temperatures.Length; i++)
        {
            while(heap.TryPeek(out var index, out var priority) && priority < temperatures[i])
            {
                heap.Dequeue();
                result[index] = i - index;
            }
            
            heap.Enqueue(i, temperatures[i]);
        }
        
        return result;
    }
    
    public int[] DailyTemperaturesV1(int[] temperatures) 
    {
        var result = new int[temperatures.Length];
        
        for(int index = 0; index < temperatures.Length; index++)
        {
            int distance = 0;
            for(
                int next = index + 1; 
                next < temperatures.Length && distance == 0; 
                next++)
            {
                if(temperatures[next] > temperatures[index])
                {
                    distance = next - index;
                }   
            }
            
            result[index] = distance;
        }
        
        return result;
    }
}
