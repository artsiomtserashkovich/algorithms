using System.Collections.Generic;
using Algorithms.LeetCode.BackTracking;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.BackTracking
{
    public class GenerateParenthesesTests 
    {
        [TestCaseSource(nameof(GetGenerateParenthesesCases))]
        public void Solution(int n, IList<string> result)
        {
            new GenerateParentheses().GenerateParenthesis(n).Should().BeEquivalentTo(result);
        }
        
        [TestCaseSource(nameof(GetGenerateParenthesesCases))]
        public void SolutionV2(int n, IList<string> result)
        {
            new GenerateParentheses().GenerateParenthesisV2(n).Should().BeEquivalentTo(result);
        }

        public static IEnumerable<TestCaseData> GetGenerateParenthesesCases()
        {
            yield return new TestCaseData(1, new List<string> { "()" });
            yield return new TestCaseData(
                2, 
                new List<string>
                {
                    "(())",
                    "()()",
                });
            yield return new TestCaseData(
                3, 
                new List<string>
                {
                    "((()))",
                    "(()())",
                    "(())()",
                    "()(())",
                    "()()()"
                });
        }   
    }
}