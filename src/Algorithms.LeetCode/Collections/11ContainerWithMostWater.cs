using System;

namespace Algorithms.LeetCode.Collections
{
    // https://leetcode.com/problems/container-with-most-water/
    public class ContainerWithMostWater 
    {
        public int MaxArea(int[] height) 
        {
            int max = 0;
        
            for(int left = 0, rigth = height.Length - 1; left < rigth;)
            {
                max = Math.Max(
                    Math.Min(height[left], height[rigth]) * (rigth - left), 
                    max);
            
                if(height[left] < height[rigth])
                {
                    left ++;
                }
                else
                {
                    rigth --;
                }
            }
        
            return max;
        }
    }
}