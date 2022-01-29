using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode.Tree
{
    public class FindLeafsOfBinaryTree 
    {
        public List<IList<int>> GetLeafsOfBinaryTree(TreeNode root)
        {
            var result = new List<IList<int>>();
    
            if(root == null)
            {
                return result;
            }
    
            var iterationAcc = new List<int>();
            while(!DFSRecursion(iterationAcc, root)) 
            { 
                result.Add(iterationAcc);
                iterationAcc = new List<int>();
            }    
            result.Add(iterationAcc);
            
            return result;
        }
        
        private static bool DFSRecursion(IList<int> acc, TreeNode root)
        {
            if(root.left == null && root.right == null)
            {
                acc.Add(root.val);
                return true;
            }
		
            if(root.left != null)
            {
                var removeLeft = DFSRecursion(acc, root.left);
                if(removeLeft)
                {
                    root.left = null;
                }
            }
    
            if(root.right != null)
            {
                var removeRight = DFSRecursion(acc, root.right);
                if(removeRight)
                {
                    root.right = null;
                }
            }
    
            return false;
        }
        
        public IList<IList<int>> GetLeafsOfBinaryTreeV2(TreeNode root)
        {
            if(root == null)
            {
                return null;
            }

            var accumulator = new Dictionary<int, IList<int>>();
            DepthFirstIterator(accumulator, root);
            
            
            return accumulator.Select(kv => kv.Value).ToList();
        }

        private static int DepthFirstIterator(IDictionary<int, IList<int>> acc, TreeNode node)
        {
            if (node.left == null && node.right == null)
            {
                if (!acc.ContainsKey(0))
                {
                    acc[0] = new List<int>() { node.val };
                }
                else
                {
                    acc[0].Add(node.val);
                }
                return 0;
            }

            int leftChildLevel = node.left != null ? DepthFirstIterator(acc, node.left) : -1;
            int rightChildLevel = node.right != null ? DepthFirstIterator(acc, node.right) : -1;

            var currentNodeLevel = Math.Max(leftChildLevel, rightChildLevel) + 1;
            if (!acc.ContainsKey(currentNodeLevel))
            {
                acc[currentNodeLevel] = new List<int>() { node.val };
            }
            else
            {
                acc[currentNodeLevel].Add(node.val);
            }
            
            return currentNodeLevel;
        }
        
        public class TreeNode 
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}