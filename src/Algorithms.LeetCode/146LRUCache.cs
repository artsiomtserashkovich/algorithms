using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class LRUCache
    {
        private readonly int _cacheSize;
        private readonly IDictionary<int, CacheableNode> _cache;

        private int _currentCapacity;

        private CacheableNode _head = null;
        private CacheableNode _tail = null;

        public LRUCache(int capacity)
        {
            _cacheSize = capacity;
            _cache = new Dictionary<int, CacheableNode>();
            _currentCapacity = 0;
        }

        public int Get(int key)
        {
            if (_currentCapacity != 0 && _cache.ContainsKey(key))
            {
                var node = _cache[key];

                if (node == _head)
                    _head = node.right;

                if (node == _tail)
                    _tail = node.left;

                if (node.right != null)
                    node.right.left = node.left;

                if (node.left != null)
                    node.left.right = node.right;

                _cache.Remove(node.key);
                _currentCapacity--;

                return node.val;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            var node = new CacheableNode(key, value);

            _cache[node.key] = node;

            if (_tail != null)
                _tail.right = node;

            node.left = _tail;
            _tail = node;

            if (_currentCapacity == _cacheSize)
            {
                var prevHead = _head;
                _head = prevHead.right;

                if (_head != null)
                    _head.left = null;

                _cache.Remove(prevHead.key);
            }
            else
            {
                _currentCapacity++;

                if (_head == null)
                    _head = node;
            }
        }

        private class CacheableNode
        {
            public int key { get; }
            public int val { get; }

            public CacheableNode(int key, int val)
            {
                this.key = key;
                this.val = val;
            }

            public CacheableNode left;
            public CacheableNode right;
        }
    }
}