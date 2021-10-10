using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode.BackTracking
{
    public class Backtracking
    {
        //Given an integer array nums of unique elements, return all possible subsets (the power set).
        //The solution set must not contain duplicate subsets. Return the solution in any order.
        public IList<IList<int>> DistinctSubsetsV1(int[] nums)
        {
            var result = new List<IList<int>>();
            for(var combination = 0; combination < Math.Pow(2, nums.Length); combination++)
            {
                var comb = new List<int>();
                for(var bitIndex=0; bitIndex < nums.Length; bitIndex++)
                {
                    if((combination & (1 << bitIndex)) != 0)
                    {
                        comb.Add(nums[bitIndex]);    
                    }
                }
                result.Add(comb);
            }
            return result;   
        }
        
        // https://leetcode.com/problems/combination-sum/discuss/16502/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        //Given an integer array nums of unique elements, return all possible subsets (the power set).
        //The solution set must not contain duplicate subsets. Return the solution in any order.
        public IList<IList<int>> DistinctSubsetsV2(int[] nums)
        {
            var result = new List<IList<int>>();
            
            BacktrackRec(result, new List<int>(), nums, 0);

            return result;   
        }
        
        private void BacktrackRec(
            IList<IList<int>> list,
            List<int> tempList,
            int[] nums,
            int start)
        {
            list.Add(new List<int>(tempList));
            
            for(var index = start; index < nums.Length; index++)
            {
                tempList.Add(nums[index]);
                
                BacktrackRec(list, tempList, nums, index + 1);
                
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
        
        // https://leetcode.com/problems/combination-sum/discuss/16502/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        //Given an integer array nums of unique elements, return all possible subsets (the power set).
        //The solution set must not contain duplicate subsets. Return the solution in any order.
        public IList<IList<int>> DistinctSubsetsV3(int[] nums)
        {
            var result = new List<IList<int>>();
            
            BacktrackRecV2(result, new Stack<int>(), nums, 0);

            return result;   
        }
        
        private void BacktrackRecV2(
            IList<IList<int>> list,
            Stack<int> accumulator,
            int[] nums,
            int start)
        {
            // Make a snapshot from accumulator and save this combination
            list.Add(new List<int>(accumulator));
            
            for(var index = start; index < nums.Length; index++)
            {
                accumulator.Push(nums[index]);
                
                BacktrackRecV2(list, accumulator, nums, index + 1);
                
                accumulator.Pop();
            }
        }
        
        // Given an array of distinct integers candidates and a target integer target,
        // return a list of all unique combinations of candidates where the chosen numbers sum to target.
        // You may return the combinations in any order.
        // The same number may be chosen from candidates an unlimited number of times.
        // Two combinations are unique if the frequency of at least one of the chosen numbers is different.
        public IList<IList<int>> CombinationSum(int[] candidates, int target) 
        {
            var result = new List<IList<int>>();
        
            BacktrackRecDistinctSum(
                result, 
                new Stack<int>(), 
                candidates, 
                target, 
                0);
        
            return result;
        }
    
        private static void BacktrackRecDistinctSum(
            IList<IList<int>> result, 
            Stack<int> combination,
            int[] nums,
            int leftSum,
            int startIndex)
        {
            if(leftSum == 0)
            {
                result.Add(new List<int>(combination));
            } 
            else if(leftSum < 0)
            {
                return;    
            }
        
            for(var index = startIndex; index < nums.Length; index++)
            {
                combination.Push(nums[index]);
            
                BacktrackRecDistinctSum(
                    result, 
                    combination, 
                    nums, 
                    leftSum - nums[index], 
                    index);
            
                combination.Pop();
            }
        }
    }
}