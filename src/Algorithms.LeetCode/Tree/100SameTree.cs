namespace Algorithms.LeetCode.Tree
{
    public class SameTree 
    {
        public bool IsSameTree(TreeNode p, TreeNode q) 
        {
            if(p?.val != q?.val)
            {
                return false;
            }
        
            if(p == null & q == null)
            {
                return true;
            }
        
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        
        public bool IsSameTreeV2(TreeNode p, TreeNode q)
        {
            if (p == null & q == null) return true;
            return p?.val == q?.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
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