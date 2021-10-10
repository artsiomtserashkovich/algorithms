using System;
using System.Collections.Generic;

namespace Algorithms.Intuit.DynamicProgramming
{
    public class GrasshopperJumps
    {
        // 3 possible steps: 1, 2, 3
        // As a result to find all possible routes to N
        // we can use reccurent expression: Fn = Fn-1 + Fn-2 + Fn+3
        public int TripleStepsGet(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException(nameof(n));
            }
            else if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                var numbers = new int[n + 1];
                numbers[0] = 1;
                numbers[1] = 1;
                numbers[2] = 2;

                for (int index = 3; index <= n; index++)
                {
                    numbers[index] = numbers[index - 1] + numbers[index - 2] + numbers[index - 3];
                }

                return numbers[n];
            }
        }
        
        // 3 possible steps: 1, 2, 3, ..., K
        // As a result to find all possible routes to N
        // we can use reccurent expression: F[N] = Sum(F[N-1], ... , F[N-max(K,N)])
        public int KStepsGet(int k, int n)
        {
            if (n < 0)
            {
                throw new ArgumentException(nameof(n));
            } else if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                var numbers = new int[n + 1];
                numbers[0] = 1;

                for (int index = 1; index <= n; index++)
                {
                    numbers[index] = 0;
                    var limit = Math.Min(index, k);

                    for (var j = 1; j <= limit; j++)
                    {
                        // we can add here some condition
                        numbers[index] += numbers[index - j];
                    }
                }

                return numbers[n];
            }
        }
        
        // Other type of task
        // Program should calculate profit instead of possible ways
        // each steps give some point
        // we should return max point which can be rea ch for specific n 
        public int GetMaxEarned(int k, int n, int[] taxes)
        {
            if (k < 1)
            {
                throw new ArgumentException(nameof(k));
            }
            else if (n < 0)
            {
                throw new ArgumentException(nameof(n));
            }
            else if (taxes is null || taxes.Length != n + 1)
            {
                throw new ArgumentException(nameof(taxes));
            }
            else if (n == 0)
            {
                return taxes[0];
            }
            else
            {
                var paidTaxes = new int[n + 1];
                paidTaxes[0] = taxes[0];

                for (int index = 1; index <= n; index++)
                {
                    var tax = taxes[index];
                    var limit = Math.Min(index, k);

                    paidTaxes[index] = paidTaxes[index - 1] + tax;
                    
                    for (int j = 2; j <= limit; j++)
                    {
                        paidTaxes[index] = Math.Max(paidTaxes[index - j], paidTaxes[index] - tax) + tax;
                    }
                }

                return paidTaxes[n];
            }
        }
        
        // Other type of task
        // Program should calculate profit instead of possible ways
        // each steps give some point
        // we should return max point which can be rea ch for specific n 
        public IReadOnlyCollection<int> GetMaxEarnedPath(int k, int n, int[] taxes)
        {
            if (k < 1)
            {
                throw new ArgumentException(nameof(k));
            }
            else if (n < 0)
            {
                throw new ArgumentException(nameof(n));
            }
            else if (taxes is null || taxes.Length != n + 1)
            {
                throw new ArgumentException(nameof(taxes));
            }
            else
            {
                var paidTaxes = new (int Value, int Path)[n + 1];
                paidTaxes[0] =  (taxes[0], 0);

                for (int index = 1; index <= n; index++)
                {
                    var tax = taxes[index];
                    var limit = Math.Min(index, k);

                    paidTaxes[index] = (paidTaxes[index - 1].Value + tax, index-1);
                    
                    for (int j = 2; j <= limit; j++)
                    {
                        if (paidTaxes[index - j].Value >= paidTaxes[index].Value - tax)
                        {
                            paidTaxes[index] = (paidTaxes[index - j].Value + tax, index - j);
                        }
                    }
                }

                var route = new List<int> { n };

                var indexRoute = n;
                while(true)
                {
                    if (indexRoute == 0)
                    {
                        return route;
                    }
                    route.Add(paidTaxes[indexRoute].Path);
                    indexRoute = paidTaxes[indexRoute].Path;
                }
            }
        }
    }
}