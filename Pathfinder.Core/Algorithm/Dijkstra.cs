using System;
using System.Collections.Generic;
using Pathfinder.Core.Interfaces;

namespace Pathfinder.Core.Algorithm
{
    public class Dijkstra<T> : IAlgorithm<T>
    {
        public Dijkstra(IDictionary<T, IVertex<T>> vertices)
        {
            Vertices = vertices;
        }
        
        private IDictionary<T, IVertex<T>> Vertices { get; }

        public ICollection<T> Execute(T start, T finish)
        {
            var previous = new Dictionary<T,T>();
            var distances = new Dictionary<T, int>();
            var nodes = new List<T>();
            
            var path = new List<T>();
            
            foreach (var vertex in Vertices)
            {
                distances[vertex.Key] = vertex.Key.Equals(start) ? 0 : Int32.MaxValue;
                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest.Equals(finish))
                {
                    path = new List<T>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }
                    path.Reverse();
                    break;
                }

                if (distances[smallest] == int.MaxValue) break;
                
                foreach (var neighbor in Vertices[smallest].Edges)
                {
                    var alt = distances[smallest] + neighbor.Weight;
                    if (alt >= distances[neighbor.Destination]) continue;
                    
                    distances[neighbor.Destination] = alt;
                    previous[neighbor.Destination] = smallest;
                }
            }

            return path;
        }
    }
}