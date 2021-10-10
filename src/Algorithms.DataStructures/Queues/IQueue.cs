using System.Collections.Generic;

namespace Algorithms.DataStructures.Queues
{
    public interface IQueue<T> : IEnumerable<T>
    {
        // From top without remove
        T Peek();

        // From top with remove
        T Dequeue();

        void Enqueue(T item);

        public int Count { get; }
    }
}