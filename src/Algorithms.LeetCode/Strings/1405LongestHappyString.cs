public class LongestHappyString 
{
    public string LongestDiverseString(int a, int b, int c)
    {
        var acc = new StringBuilder();
        int possibleLength = a + b + c;
        int currA = 0, currB = 0, currC = 0;
        
        while(possibleLength > 0)
        {
            if((currA < 2 && a > 0) && ((a >= b && a >= c) || (currB == 2) || (currC == 2)))
            {
                acc.Append('a');
                
                a --;
                
                currA ++;
                currB = 0;
                currC = 0;
            }
            else if((currB < 2 && b > 0) && ((b >= a && b >= c) || (currA == 2) || (currC == 2)))
            {
                acc.Append('b');
                
                b --;
                
                currA = 0;
                currB ++;
                currC = 0;
            }
            else if((currC < 2 && c > 0) && ((c >= a && c >= b) || (currA == 2) || (currB == 2)))
            {
                acc.Append('c');
                
                c --;
                
                currA = 0;
                currB = 0;
                currC ++;
            }
            else
            {
                return acc.ToString();
            }
            
            possibleLength --;
        }
        
        return acc.ToString();
    }
    
    public string LongestDiverseStringV1(int a, int b, int c) 
    {
        return LongestDiverseRecursion(new Stack<char>(), a, b, c);
    }
    
    private string LongestDiverseRecursion(Stack<char> acc, int a, int b, int c)
    {
        string result = new string(acc.Reverse().ToArray());
        
        if(a > 0 && CouldAttach(acc, 'a'))
        {
            acc.Push('a');
            result = LongestDiverseRecursion(acc, a - 1, b, c);
            acc.Pop();
        }
        
        if(b > 0 && CouldAttach(acc, 'b'))
        {
            acc.Push('b');
            var bResult = LongestDiverseRecursion(acc, a, b - 1, c);
            acc.Pop();
            
            if(bResult.Length > result.Length)
            {
                result = bResult;
            }
        }
        
        if(c > 0 && CouldAttach(acc, 'c'))
        {
            acc.Push('c');
            var cResult = LongestDiverseRecursion(acc, a, b, c - 1);
            acc.Pop();
            
            if(cResult.Length > result.Length)
            {
                result = cResult;
            }
        }
        
        return result;
    }
    
    private static bool CouldAttach(Stack<char> acc, char letter)
    {
        if(acc.TryPeek(out var last) && last == letter)
        {
            var tempRemove = acc.Pop();
            
            var flag = acc.TryPeek(out var preLast) && preLast == letter;
            
            acc.Push(tempRemove);
            
            return !flag;
        }
        
        return true;
    }
}
