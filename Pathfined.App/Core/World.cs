using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinder.Core.Algorithm;
using Pathfinder.Core.Graph;
using Pathfinder.Core.Interfaces;
using Pathfined.App.Interfaces;
using Pathfined.App.Models;

namespace Pathfined.App.Core
{
    public class World
    {
        public World(int sizeX, int sizeY, IWorldBuilder worldBuilder)
        {
            SizeX = sizeX;
            SizeY = sizeY;

            WorldBuilder = worldBuilder;

            GenerateWorld();
        }

        private int SizeY { get; }
        private int SizeX { get; }

        private IWorldBuilder WorldBuilder { get; }

        private Cell[,] _cells;

        private void GenerateWorld()
        {
            _cells = WorldBuilder.BuildWorld(SizeX, SizeY);
        }

        private IEnumerable<IEdge<ILocation>> GenerateEdges(ILocation location)
        {
            if (location.X < SizeX - 1)
            {
                var destination = _cells[location.X + 1, location.Y];
                if (destination.Passability != 0)
                    yield return new Edge<ILocation>(destination, 
                        (byte)(Constants.MaxPassability - destination.Passability));
            }

            if (location.X > 0)
            {
                var destination = _cells[location.X - 1, location.Y];
                if (destination.Passability != 0)
                    yield return new Edge<ILocation>(destination, 
                        (byte)(Constants.MaxPassability - destination.Passability));
            }

            if (location.Y < SizeY - 1)
            {
                var destination = _cells[location.X, location.Y + 1];
                if (destination.Passability != 0)
                    yield return new Edge<ILocation>(destination, 
                        (byte)(Constants.MaxPassability - destination.Passability));
            }

            if (location.Y > 0)
            {
                var destination = _cells[location.X, location.Y - 1];
                if (destination.Passability != 0)
                    yield return new Edge<ILocation>(destination, 
                        (byte)(Constants.MaxPassability - destination.Passability));
            }
        }

        private IEnumerable<IVertex<ILocation>> GenerateVertices()
        {
            var vertices = new List<IVertex<ILocation>>();

            for (var x = 0; x < SizeX; x++)
            for (var y = 0; y < SizeY; y++)
            {
                var cell = _cells[x, y];
                var vertex = new Vertex<ILocation>(cell);

                foreach (var edge in GenerateEdges(cell))
                    vertex.Edges.Add(edge);
                
                vertices.Add(vertex);
            }

            return vertices;
        }

        public void PrintWorld()
        {
            for (var x = 0; x < SizeX; x++)
            {
                for (var y = 0; y < SizeY; y++)
                {
                    var cell = _cells[x, y];
                    Console.Write($"({cell.X}, {cell.Y}) : {Constants.MaxPassability - cell.Passability:00}\t");
                }
                Console.Write(Environment.NewLine);
            }
        }

        public ILocation[] FindShortestWay(ILocation start, ILocation finish)
        {
            var vertices = GenerateVertices().ToDictionary(k => k.Key, v => v);
            var algorithm = new Dijkstra<ILocation>(vertices);
            var result = algorithm.Execute(start, finish);

            return result.ToArray();
        }
    }
}