using System;

namespace Algorithms.LeetCode.UnionFind.Sets
{
    public class QuickUnionSet
    {
        private readonly int[] _roots;
        
        public QuickUnionSet(int size)
        {
            if (size <= 0)
                throw new ArgumentException(nameof(size));
            
            _roots = new int[size];

            for (int i = 0; i < size; i++)
            {
                _roots[i] = i;
            }
        }

        public void Union(int first, int second)
        {
            var firstRoot = GetRoot(first);
            var secondRoot = GetRoot(second);
            
            if (firstRoot != secondRoot)
            {
                _roots[firstRoot] = secondRoot;
            }
        }

        public bool IsConnected(int first, int second)
        {
            return GetRoot(first) == GetRoot(second);
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