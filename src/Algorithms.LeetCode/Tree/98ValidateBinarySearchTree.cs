namespace Algorithms.LeetCode.Tree
{
    public class ValidateBinarySearchTree 
    {
        public bool IsValidBST(TreeNode root, int? minValue = null, int? maxValue = null) 
        {
            if(root == null) return true;
            if((minValue != null && minValue >= root.val) 
               || 
               (maxValue != null && maxValue <= root.val))
            {
                return false;
            }
        
            return 
                IsValidBST(root.left, minValue, root.val) 
                && 
                IsValidBST(root.right, root.val, maxValue);
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