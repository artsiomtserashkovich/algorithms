using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DataStructures.Graph
{
    public class Dijkstra
    {
        public int MinPath(Node[] nodes, Node start, Node end)
        {
            if ( start == null || end == null )
			{
				throw new ArgumentNullException ();
			}
		
			// If the start and end are same node, we can return the start node
			if ( start == end )
			{
				return start.Value;
			}
		
			// The list of unvisited nodes
			var unvisited = new List<Node>();
			// Previous nodes in optimal path from source
			
			//var previous = new Dictionary<Node, Node> ();
		
			// The calculated distances, set all to Infinity at start, except the start Node
			var distances = new Dictionary<Node, int?> ();

			foreach (var node in nodes)
			{
				unvisited.Add(node);
				// Setting the node distance to Infinity
				distances.Add(node, null);
			}

			// Set the starting Node distance to zero
			distances[start] = 0;
			while(unvisited.Count != 0 )
			{
				// Ordering the unvisited list by distance, smallest distance at start and largest at end
				unvisited = unvisited.OrderBy(node => distances[node]).ToList();
				// Getting the Node with smallest distance
				var current = unvisited.First();
				// Remove the current node from unvisisted list
				unvisited.Remove(current);
				
				// When the current node is equal to the end node, then we can break and return the path
				// if (current == end)
				// {
				// 	// Construct the shortest path
				// 	while (previous.ContainsKey(current))
				// 	{
				// 		// Insert the node onto the final result
				// 		// TRACK PATH HERE
				// 		
				// 		// Traverse from start to end
				// 		current = previous [ current ];
				// 	}
				// 	
				// 	break;
				// }
				
				// Looping through the Node connections (neighbors) and where the connection (neighbor) is available at unvisited list
				foreach(var neighbor in current.Connections )
				{
					// Getting the distance between the current node and the connection (neighbor)
					var length = neighbor.Value;
					// The distance from start node to this connection (neighbor) of current node
					var calculatedDistance = distances[current] + length;
					
					// A shorter path to the connection (neighbor) has been found
					if(distances[neighbor] == null || calculatedDistance < distances[neighbor])
					{
						distances[neighbor] = calculatedDistance;
						
						//previous[neighbor] = current;
					}
					
					// ALSO WE CAN ADD HERE NODE TO UNVISITED LIST!!
					//
					// if (!visited.contains(neighbor)) {
					//	if(distances[neighbor] == null || calculatedDistance < distances[neighbor])
					//	{
					// 		distances[neighbor] = calculatedDistance;
					// 		previous[neighbor] = current;
					//	}
					// 	visited.add(neighbor);
					// }
				}
			}
			
			return distances[end] ?? -1;
        }
    }
}