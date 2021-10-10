using System;

namespace Algorithms.LeetCode.Collections
{
    // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    public class BestTimeToBuy 
    {
        // KADANE 
        public int GetMaxProfit(int[] prices) {
        
        
            var localMaxSum = 0;
            var totalMaxSum = 0;
        
            for(int index = 1; index < prices.Length; index++)
            {
                localMaxSum = Math.Max(localMaxSum + (prices[index] - prices[index - 1]), prices[index] - prices[index - 1]);
                totalMaxSum = totalMaxSum > localMaxSum ? totalMaxSum : localMaxSum;
            }
        
        
            return totalMaxSum;
        }
        
        public int GetMaxProfitV2(int[] prices) {
            if(prices.Length <= 1)
            {
                return 0;
            }
        
            int minPrice = prices[0];
            int maxProfit = prices[1] - prices[0];
        
            for(int day = 1; day < prices.Length; day ++)
            {
                maxProfit = Math.Max(maxProfit, prices[day] - minPrice);
                minPrice =  Math.Min(minPrice,  prices[day]);
            }
    
        
            return maxProfit > 0 ? maxProfit : 0;
        }
    }
}