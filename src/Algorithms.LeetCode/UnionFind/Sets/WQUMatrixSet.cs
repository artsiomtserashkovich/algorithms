namespace Algorithms.LeetCode.UnionFind.Sets
{
    public class WQUMatrixSet
    {
        private readonly WeightedQuickUnionSet _unionSet;

        private readonly int _rowSize;
        private readonly int _colSize;
        
        public WQUMatrixSet(int row, int col)
        {
            _unionSet = new WeightedQuickUnionSet(row * col);

            _rowSize = row;
            _colSize = col;
        }

        public void Union((int row, int col) first, (int row, int col) second)
        {
            var firstIndex = first.row * _colSize + first.col;
            var secondIndex = second.row * _colSize + second.col;
            
            _unionSet.Union(firstIndex, secondIndex);
        }
        
        public bool IsConnected((int row, int col) first, (int row, int col) second)
        {
            var firstIndex = first.row * _colSize + first.col;
            var secondIndex = second.row * _colSize + second.col;
            
            return _unionSet.IsConnected(firstIndex, secondIndex);
        }
        
        public int GetConnectedCount(int row, int col)
        {
            var index  = row * _colSize + col;
            
            return _unionSet.GetConnectedCount(index);
        }
    }
}