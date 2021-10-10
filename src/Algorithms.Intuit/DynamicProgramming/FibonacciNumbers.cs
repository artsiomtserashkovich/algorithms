using System;

namespace Algorithms.Intuit.DynamicProgramming
{
    public class FibonacciNumbers
    {
        // F1 = 1
        // F2 = 1
        // Fn = Fn-1 + Fn-2
        
        // O(n) ~~1.5 ^ n
        public int RecursionGet(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException(nameof(n));
            } else if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return RecursionGet(n - 1) + RecursionGet(n - 2);
            }
        }

        // O(n) = n
        public int DynamicGet(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException(nameof(n));
            } else if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                var numbers = new int[n];
                numbers[0] = 1;
                numbers[1] = 1;

                for (int index = 2; index < n; index++)
                {
                    numbers[index] = numbers[index - 1] + numbers[index - 2];
                }

                return numbers[n - 1];
            }
        }
    }
}