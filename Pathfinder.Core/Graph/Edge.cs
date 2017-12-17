using Pathfinder.Core.Interfaces;

namespace Pathfinder.Core.Graph
{
    public class Edge<T> : IEdge<T>
    {
        public Edge(T destination, byte weight)
        {
            Destination = destination;
            Weight = weight;
        }
        
        public T Destination { get; }
        public byte Weight { get; }
    }
}