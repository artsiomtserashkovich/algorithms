using System.Collections.Generic;

namespace Algorithms.DataStructures.Stacks
{
    public interface IStack<T> : IEnumerable<T>
    {
        // From top without remove
        T Peek();

        // From top with remove
        T Pop();

        void Push(T item);

        public int Count { get; }
    }
}