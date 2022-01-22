using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode.BackTracking
{
    public class LetterCombinationsPhoneNumber 
    {
        private static IDictionary<char, char[]> MAPPING = new Dictionary<char, char[]>
        {
            ['2'] = new[] {'a', 'b', 'c'},
            ['3'] = new[] {'d', 'e', 'f'},
            ['4'] = new[] {'g', 'h', 'i'},
            ['5'] = new[] {'j', 'k', 'l'},
            ['6'] = new[] {'m', 'n', 'o'},
            ['7'] = new[] {'p', 'q', 'r', 's'},
            ['8'] = new[] {'t', 'u', 'v'},
            ['9'] = new[] {'w', 'x', 'y', 'z'},
        };
    
        public IList<string> LetterCombinations(string digits) 
        {
            var result = new List<string>();
            if(digits.Length == 0)
            {
                return result;
            }
        
            Backtrack(result, new Stack<char>(), digits);
        
            return result;
        }
    
        private void Backtrack(IList<string> acc, Stack<char> current, string number)
        {
            if(number.Length == 0)
            {
                acc.Add(new string(current.Reverse().ToArray()));
                return;
            }
        
            var letters = MAPPING[number[0]];
        
            foreach(var letter in letters)
            {
                current.Push(letter);
                Backtrack(acc, current, number.Substring(1, number.Length - 1));
                current.Pop();
            }
        
        }
    }
}