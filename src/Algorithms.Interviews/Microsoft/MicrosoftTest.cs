using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Interviews.Microsoft
{
    public class MicrosoftTest
    {
        public string solution(string S)
        {
            // 4 possible state => 
            // 0) not occur
            // 1) lowcase occur
            // 2) uppercase occur
            // 3) bothcases occur

            // So, bit manipulation or bool[] are not suitable here
            var occurred = new byte[26];

            foreach (var letter in S)
            {
                if (letter >= 'a' && letter <= 'z')
                {
                    var letterIndex = letter - 'a';
                    var letterStatus = occurred[letterIndex];

                    if (letterStatus == 2)
                    {
                        occurred[letterIndex] = 3;
                    }
                    else if (letterStatus != 3)
                    {
                        occurred[letterIndex] = 1;
                    }
                }

                if (letter >= 'A' && letter <= 'Z')
                {
                    var letterIndex = letter - 'A';
                    var letterStatus = occurred[letterIndex];

                    if (letterStatus == 1)
                    {
                        occurred[letterIndex] = 3;
                    }
                    else if (letterStatus != 3)
                    {
                        occurred[letterIndex] = 2;
                    }
                }
            }

            for (int letterIndex = 25; letterIndex >= 0; letterIndex--)
            {
                if (occurred[letterIndex] == 3)
                {
                    return char.ToString((char) (letterIndex + 'A'));
                }
            }

            return "NO";
        }

        public int[] solution(int N)
        {
            var isCountEven = N % 2 == 0;
            var uniquePairs = N / 2;

            var array = new int[N];

            for (var pairCount = 0; pairCount < uniquePairs; pairCount++)
            {
                array[pairCount * 2] = pairCount + 1;
                array[(pairCount * 2) + 1] = -1 * (pairCount + 1);
            }

            if (!isCountEven)
            {
                array[N - 1] = 0;
            }

            return array;
        }


        // Diverse alphabet
        class Solution
        {
            private const char A = 'a';
            private const char B = 'b';
            private const char C = 'c';

            public string solution(int A, int B, int C)
            {
                /*
                var backtrackingOptions = new List<string>();
                Backtrack(backtrackingOptions, new StringBuilder(), A, B, C);
        
                return backtrackingOptions
                    .OrderByDescending(s => s.Length)
                    .FirstOrDefault();*/

                return BacktrackLongest(new StringBuilder(), A, B, C);
            }

            private static void Backtrack(
                IList<string> acc,
                StringBuilder current,
                int leftA,
                int leftB,
                int leftC)
            {
                acc.Add(current.ToString());

                if (IsExtendable(current, A) && leftA > 0)
                {
                    current.Append(A);
                    Backtrack(acc, current, leftA - 1, leftB, leftC);
                    current.Remove(current.Length - 1, 1);
                }

                if (IsExtendable(current, B) && leftB > 0)
                {
                    current.Append(B);
                    Backtrack(acc, current, leftA, leftB - 1, leftC);
                    current.Remove(current.Length - 1, 1);
                }

                if (IsExtendable(current, C) && leftC > 0)
                {
                    current.Append(C);
                    Backtrack(acc, current, leftA, leftB, leftC - 1);
                    current.Remove(current.Length - 1, 1);
                }
            }

            private static string BacktrackLongest(
                StringBuilder current,
                int leftA,
                int leftB,
                int leftC)
            {
                string localLongest = current.ToString();

                if (IsExtendable(current, A) && leftA > 0)
                {
                    current.Append(A);
                    localLongest = GetLongest(
                        localLongest,
                        BacktrackLongest(current, leftA - 1, leftB, leftC));
                    current.Remove(current.Length - 1, 1);
                }

                if (IsExtendable(current, B) && leftB > 0)
                {
                    current.Append(B);
                    localLongest = GetLongest(
                        localLongest,
                        BacktrackLongest(current, leftA, leftB - 1, leftC));
                    current.Remove(current.Length - 1, 1);
                }

                if (IsExtendable(current, C) && leftC > 0)
                {
                    current.Append(C);
                    localLongest = GetLongest(
                        localLongest,
                        BacktrackLongest(current, leftA, leftB, leftC - 1));
                    current.Remove(current.Length - 1, 1);
                }

                return localLongest;
            }

            private static string GetLongest(string left, string right)
            {
                if (left.Length > right.Length)
                {
                    return left;
                }

                return right;
            }

            private static bool IsExtendable(StringBuilder str, char letter)
            {
                if (str.Length == 0 || str.Length == 1)
                {
                    return true;
                }

                return !(str[str.Length - 1] == letter && str[str.Length - 2] == letter);
            }
        }
    }
}