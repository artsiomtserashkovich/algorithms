using System.Collections.Generic;

namespace Algorithms.DataStructures.Graph
{
    public class Graph
    {
        public IReadOnlyCollection<Node> Nodes { get; set; }
    }
    
    public class Node
    {
        public int Value { get; set; }

        public IReadOnlyCollection<Node> Connections { get; set; }
    }
}