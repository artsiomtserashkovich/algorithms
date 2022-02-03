using System;

namespace Algorithms.LeetCode.UnionFind.Sets
{
    public class QuickFindUnionSet
    {
        private readonly int[] _class;
        
        public QuickFindUnionSet(int size)
        {
            if (size <= 0)
                throw new ArgumentException(nameof(size));
            
            _class = new int[size];

            for (int i = 0; i < size; i++)
            {
                _class[i] = i;
            }
        }

        public void Union(int first, int second)
        {
            var firstClass = _class[first];
            var secondClass = _class[second];
            
            if (firstClass != secondClass)
            {
                for (int i = 0; i < _class.Length; i++)
                {
                    if (_class[i] == firstClass)
                    {
                        _class[i] = secondClass;
                    }
                }
            }
        }

        public bool IsConnected(int first, int second)
        {
            return _class[first] == _class[second];
        }
    }
}