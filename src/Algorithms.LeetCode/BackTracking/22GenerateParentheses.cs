using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.LeetCode.BackTracking
{
    public class GenerateParentheses 
    {
        public IList<string> GenerateParenthesis(int n) 
        {
            var result = new List<string>();
            if (n == 0) return result;
                
            Backtrack(result, new Stack<char>(), new Stack<char>(), n);
        
            return result;
        }
    
        private static void Backtrack(
            IList<string> acc, 
            Stack<char> prefix, 
            Stack<char> postfix, 
            int n)
        {
            if(n == 1)
            {
                acc.Add(
                    new string(prefix.Reverse().ToArray()) 
                    + "()"
                    + new string(postfix.ToArray()));
                return;
            }
        
            // Problem is that we not handling cased (()) ->
            // cause we not expect more than 1 closing bracket in row
            prefix.Push('(');
            prefix.Push(')');
            Backtrack(acc, prefix, postfix, n - 1);
            prefix.Pop();
            prefix.Pop();
        
            prefix.Push('(');
            postfix.Push(')');
            Backtrack(acc, prefix, postfix, n - 1);
            prefix.Pop();
            postfix.Pop();
        }
        
        public IList<string> GenerateParenthesisV2(int n) 
        {
            var result = new List<string>();
            if (n == 0) return result;
                
            BacktrackV2(result, string.Empty, 0, 0, n);
        
            return result;
        }

        private static void BacktrackV2(
            IList<string> acc, 
            string current, 
            int currentOpen, 
            int currentClose, 
            int pairsCount)
        {
            if (current.Length == pairsCount * 2)
            {
                acc.Add(current);
                return;
            }

            if (currentOpen < pairsCount)
            {
                // current.Push();
                BacktrackV2(
                    acc, 
                    current + '(', 
                    currentOpen + 1, 
                    currentClose, 
                    pairsCount);
                // current.Pop();
            }

            if (currentOpen > currentClose)
            {
                BacktrackV2(acc, 
                    current + ')', 
                    currentOpen, 
                    currentClose + 1, 
                    pairsCount);
            }
        }
    }
}