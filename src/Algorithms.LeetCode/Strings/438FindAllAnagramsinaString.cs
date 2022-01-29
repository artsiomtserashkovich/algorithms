using System.Collections.Generic;

namespace Algorithms.LeetCode.Strings
{
    public class FindAllAnagramsinaString 
    {
        public IList<int> FindAnagrams(string s, string p) 
        {
            var result = new List<int>();
        
            var lettersHash = new int[26];
            foreach(var letter in p)
            {
                var letterIndex = (int)(letter - 'a');
                lettersHash[letterIndex]++;
            }
        
            var windowStart = 0;
            var windowEnd = 0;
            var anagramLength = p.Length;
        
            while(windowEnd < s.Length)
            {
                var windowEndLetterIndex = (int)s[windowEnd] - 'a';
                if(lettersHash[windowEndLetterIndex] >= 1)
                {
                    anagramLength --;
                }
                lettersHash[windowEndLetterIndex] --;
                windowEnd ++;
            
            
                if(anagramLength == 0)
                {
                    result.Add(windowStart);
                }
            
                if(windowEnd - windowStart == p.Length)
                {
                    var windowStartLetterIndex = (int)s[windowStart] - 'a';
                    if(lettersHash[windowStartLetterIndex] >= 0)
                    {
                        anagramLength++;
                    }

                    lettersHash[windowStartLetterIndex]++;
                    windowStart++;
                }
            
            }
        
        
            return result;
        }
    }
}