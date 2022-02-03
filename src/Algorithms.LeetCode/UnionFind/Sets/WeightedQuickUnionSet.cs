using System;

namespace Algorithms.LeetCode.UnionFind.Sets
{
    public class WeightedQuickUnionSet
    {
        private readonly int[] _roots;
        private readonly int[] _treeCount;
        
        public WeightedQuickUnionSet(int size)
        {
            if (size <= 0)
                throw new ArgumentException(nameof(size));
            
            _roots = new int[size];
            _treeCount = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                _roots[i] = i;
                _treeCount[i] = 1;
            }
        }

        public void Union(int first, int second)
        {
            var firstRoot = GetRoot(first);
            var secondRoot = GetRoot(second);
            
            if (firstRoot != secondRoot)
            {
                if(GetConnectedCount(firstRoot) > GetConnectedCount(secondRoot))
                {
                    _roots[secondRoot] = firstRoot;
                    _treeCount[firstRoot] += _treeCount[secondRoot];
                    _treeCount[secondRoot] = 0;
                }
                else
                {
                    _roots[firstRoot] = secondRoot;
                    _treeCount[secondRoot] += _treeCount[firstRoot];
                    _treeCount[firstRoot] = 0;
                }
            }
        }

        public bool IsConnected(int first, int second)
        {
            return GetRoot(first) == GetRoot(second);
        }

        public int GetConnectedCount(int index)
        {
            return _treeCount[GetRoot(index)];
        }

        private int GetRoot(int index)
        {
            var root = _roots[index];
            while(root != _roots[root])
            {
                root = _roots[root];
            }

            return root;
        }
    }
}