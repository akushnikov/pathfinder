using System.Collections.Generic;

namespace Pathfinder.Core.Interfaces
{
    public interface IAlgorithm<T>
    {
        ICollection<T> Execute(T start, T finish);
    }
}