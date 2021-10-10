using Algorithms.LeetCode.Collections;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.Collections
{
    public class LongestUnrepeatingSubarraysTests 
    {
        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        [TestCase("anviaj", 5)]
        [TestCase("aab", 2)]
        [TestCase("", 0)]
        public void GetLengthOfLongestSubstring(string str, int maxLength)
        {
            new LongestUnrepeatingSubarrays().GetLengthOfLongestSubstring(str).Should().Be(maxLength);
        }
        
        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        [TestCase("anviaj", 5)]
        [TestCase("aab", 2)]
        [TestCase("", 0)]
        public void GetLengthOfLongestSubstringV2(string str, int maxLength)
        {
            new LongestUnrepeatingSubarrays().GetLengthOfLongestSubstringV2(str).Should().Be(maxLength);
        }
    }
}