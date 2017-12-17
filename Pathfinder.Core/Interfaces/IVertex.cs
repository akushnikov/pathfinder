using System.Collections.Generic;

namespace Pathfinder.Core.Interfaces
{
    public interface IVertex<T>
    {
        T Key { get; }
        ICollection<IEdge<T>> Edges { get; }
    }
}