using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures.Stacks
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] _array;

        public ArrayStack()
        {
            _array = Array.Empty<T>();
            Count = 0;
        }
        
        public void Push(T item)
        {
            Resize(true);
            
            _array[Count++] = item;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            
            return _array[Count - 1];
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            
            var item = _array[--Count];
            Resize(false);
            
            return item;
        }

        private void Resize(bool increase)
        {
            var newSize = _array.Length + (increase ? 1 : -1);
            if (newSize < 0)
            {
                throw new ArgumentException(nameof(increase));
            }
            
            var newArray = new T[newSize];
            for (var i = 0; i < Count; i++)
            {
                newArray[i] = _array[i];
            }
            
            _array = newArray;
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = Count - 1; i >= 0; i--)
            {
                yield return _array[i];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}