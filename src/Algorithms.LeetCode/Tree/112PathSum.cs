namespace Algorithms.LeetCode.Tree
{
    public class PathSum 
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            return true;
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