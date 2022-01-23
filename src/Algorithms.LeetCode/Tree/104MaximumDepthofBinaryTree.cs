using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode.Tree
{
    public class MaximumDepthOfBinaryTree 
    {
        public int MaxDepthDFS(TreeNode root) 
        {
            if(root == null) return 0;
            if(root.left == null && root.right == null) return 1;
        
            if(root.left == null)
            {
                return MaxDepthDFS(root.right) + 1;
            }

            if (root.right == null)
            {
                return MaxDepthDFS(root.left) + 1;
            }

            return Math.Max(MaxDepthDFS(root.left), MaxDepthDFS(root.right)) + 1;
        }
        
        public int MaxDepthBFS(TreeNode root)
        {
            int result = 0;
            if(root == null) return result;
            var treesQueue = new Queue<(TreeNode Node, int level)>();
            treesQueue.Enqueue((root, 1));
            
            while(treesQueue.Any())
            {
                var (node, level) = treesQueue.Dequeue();

                if (node.left != null)
                {
                    treesQueue.Enqueue((node.left, level + 1));
                }
                
                if (node.right != null)
                {
                    treesQueue.Enqueue((node.right, level + 1));
                }

                if (node.left == null && node.right == null)
                {
                    // result = level ?
                    result = Math.Max(result, level);
                }
            }

            return result;
        }
        
        public class TreeNode {
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