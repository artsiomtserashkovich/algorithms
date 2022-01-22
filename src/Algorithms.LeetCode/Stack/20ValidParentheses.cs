using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode.Stack
{
    public class ValidParentheses 
    {
        private static IDictionary<char, char> BracketPairs = new Dictionary<char, char>
        {
            [')'] = '(',
            ['}'] = '{',
            [']'] = '[',
        };
    
        public bool IsValid(string s) 
        {
            var stack = new Stack<char>();
        
            foreach(var bracket in s)
            {
                if(stack.Any() && BracketPairs.ContainsKey(bracket) && stack.Peek() == BracketPairs[bracket])
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(bracket);
                }
            }
        
            return !stack.Any();
        }
    }
}