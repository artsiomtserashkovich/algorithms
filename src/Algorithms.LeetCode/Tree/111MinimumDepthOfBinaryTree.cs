using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode.Tree
{
    public class MinimumDepthOfBinaryTree 
    {
        public int MinDepthDFS(TreeNode root) 
        {
            if (root == null)
            {
                return 0;
            }
        
            int leftMinDepth = MinDepthDFS(root.left);
            int rightMinDepth = MinDepthDFS(root.right);
        
            return leftMinDepth == 0 || rightMinDepth == 0 
                ? leftMinDepth + rightMinDepth + 1 
                : Math.Max(MinDepthDFS(root.left), MinDepthDFS(root.right)) + 1;
        }
        
        public int MinDepthBFS(TreeNode root) 
        {
            if (root == null)
            {
                return 0;
            }

            var queue = new Queue<(TreeNode node, int level)>();
            queue.Enqueue((root, 1));

            while (queue.Count != 0)
            {
                var (node, level) = queue.Dequeue();
                if (node.left == null && node.right == null)
                {
                    return level;
                }

                if (node.left != null)
                {
                    queue.Enqueue((node.left, level + 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue((node.right, level + 1));
                }
            }

            return -1;
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