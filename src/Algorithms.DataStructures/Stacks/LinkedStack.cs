using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures.Stacks
{
    public class LinkedStack<T> : IStack<T>
    {
        private Node<T> _head;

        public LinkedStack()
        {
            _head = null;
            Count = 0;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            
            return _head.Value;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            
            var value = _head.Value;

            _head = _head.Next;
            Count--;
            
            return value;
        }

        public void Push(T item)
        {
            var previousHead = _head;
            
            _head = new Node<T>(item, previousHead);
            
            Count++;
        }

        public int Count { get; private set; }
        
        public IEnumerator<T> GetEnumerator()
        {
            var iterateNode = _head;

            for (int i = 0; i < Count; i++)
            {
                yield return iterateNode.Value;
                
                iterateNode = iterateNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        internal class Node<T>
        {
            public Node(T value, Node<T> next)
            {
                Value = value;
                Next = next;
            }
            
            public T Value { get; }
            
            public Node<T> Next { get; }
        }
    }
}