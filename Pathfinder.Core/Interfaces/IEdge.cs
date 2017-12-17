namespace Pathfinder.Core.Interfaces
{
    public interface IEdge<out T>
    {
        T Destination { get; }
        byte Weight { get; }
    }
}