using System.Linq;

namespace Algorithms.LeetCode.Strings
{
    // https://leetcode.com/problems/longest-palindromic-substring/
    public class LongestPalindromicSubstring 
    {
        public string LongestPalindrome(string s) 
        {
            if(s.Length < 2)
            {
                return s;
            }
        
            var symbols = s.ToArray();
            var maxPalindromicLength = 0;
            var maxPalindromicStartIndex = 0;
        
            void IsPolindrome(int startIndex, int endIndex)
            {
                while (startIndex >= 0 && endIndex < symbols.Length && symbols[startIndex] == symbols[endIndex])
                {
                    startIndex--;
                    endIndex++;
                }
                
                startIndex++;
                endIndex--;
            
                if (maxPalindromicLength < (endIndex - startIndex) + 1) 
                {
                    maxPalindromicStartIndex = startIndex;
                    maxPalindromicLength = (endIndex - startIndex) + 1;
                }
            }
       
            for (var index = 0; index < symbols.Length; index++) 
            {
                IsPolindrome(index, index);  //assume odd length, try to extend Palindrome as possible
                IsPolindrome(index, index + 1); //assume even length.
            }
        
            return s.Substring(maxPalindromicStartIndex, maxPalindromicLength);
        }
    }
}