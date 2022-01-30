using System.Collections.Generic;

namespace Algorithms.LeetCode.Tree
{
    public class CheckCompletenessofaBinaryTree 
    {
        public bool IsCompleteTree(TreeNode root) 
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(!IsNulls(queue))
            {
                var iterateNode = queue.Dequeue();
                queue.Enqueue(iterateNode.left);
                queue.Enqueue(iterateNode.right);	
	
                if(IsNullInMiddle(queue))
                {
                    return false;
                }
            }	
 
            return true;
        }

        private bool IsNulls(Queue<TreeNode> queue)
        {
            foreach(var node in queue)
            {
                if(node != null)
                {
                    return false;
                }
            }

            return true;
        }

        // Check if null between 2 not nulls node . E.g  [2, null, 4] -> true
        private bool IsNullInMiddle(Queue<TreeNode> queue)
        {
            var arrayQueue = queue.ToArray();
            for(int i = 0; i < queue.Count - 1; i++)
            {
                if(arrayQueue[i] == null && arrayQueue[i + 1] != null)
                {
                    return true;
                }
            }

            return false;
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