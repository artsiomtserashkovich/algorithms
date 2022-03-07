public class ReverseWordsInString 
{
    public string ReverseWords(string s) 
    {
        var stack = new Stack<char>();
        int startWordIndex = 0;
        
        s = s.TrimEnd().TrimStart();
        
        for(int index = 0; index < s.Length; index ++)
        {
            if(s[index] != ' ' && (index + 1 == s.Length || s[index + 1] == ' '))
            {
                var wordIndex = index;
                
                while(wordIndex >= 0 && s[wordIndex] != ' ')
                {
                    stack.Push(s[wordIndex]);
                    wordIndex --;
                }
                
                if(index + 1 != s.Length)
                {
                    stack.Push(' ');
                }
            }
            
        }
        
        return new string(stack.ToArray());
    }
}
