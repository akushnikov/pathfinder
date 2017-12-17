using Pathfined.App.Models;

namespace Pathfined.App.Interfaces
{
    public interface IWorldBuilder
    {
        Cell[,] BuildWorld(int sizeX, int sizeY);
    }
}