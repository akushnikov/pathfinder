using System;
using Pathfined.App.Interfaces;
using Pathfined.App.Models;

namespace Pathfined.App.Core
{
    public class RandomWorldBuilder : IWorldBuilder
    {
        public Cell[,] BuildWorld(int sizeX, int sizeY)
        {
            var rnd = new Random();

            var world = new Cell[sizeX, sizeY];
            
            for (var x = 0; x < sizeX; x++)
            for (var y = 0; y < sizeY; y++)
                world[x, y] = new Cell(x, y, (byte)rnd.Next(0, Constants.MaxPassability));

            return world;
        }
    }
}