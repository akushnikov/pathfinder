using System.Collections.Generic;
using Pathfinder.Core.Interfaces;

namespace Pathfinder.Core.Graph
{
    public class Vertex<T> : IVertex<T>
    {
        public Vertex()
        {
            Edges = new List<IEdge<T>>();
        }

        public Vertex(T key)
            : this()
        {
            Key = key;
        }

        public T Key { get; }
        public ICollection<IEdge<T>> Edges { get; }
    }
}