using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Pathfined.App.Core;
using Pathfined.App.Models;

namespace Pathfined.App
{
    class Program
    {
        static readonly Dictionary<string, string> DefaultOptions = new Dictionary<string, string>
        {
            {"Start:X", "0"},
            {"Start:Y", "0"},
            {"Finish:X", "2"},
            {"Finish:Y", "2"},
            {"Dimension:X", "3"},
            {"Dimension:Y", "3"}
        };
        
        private static IConfiguration Configuration { get; set; }
        
        static void Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(DefaultOptions)
                .AddCommandLine(args)
                .Build();

            var sizeX = Configuration.GetValue<int>("Dimension:X");
            var sizeY = Configuration.GetValue<int>("Dimension:Y");
            
            var worldBuilder = new RandomWorldBuilder();
            var world = new World(sizeX, sizeY, worldBuilder);

            var start = new Location(Configuration.GetValue<int>("Start:X"), Configuration.GetValue<int>("Start:Y"));
            var finish = new Location(Configuration.GetValue<int>("Finish:X"), Configuration.GetValue<int>("Finish:Y"));
            
            var way = world.FindShortestWay(start, finish);
            
            world.PrintWorld();
            
            Console.WriteLine($"Shortest way from {start.X}:{start.Y} to {finish.X}:{finish.Y}");
            
            for (var i = 0; i < way.Length; i++)
            {
                Console.WriteLine($"Step {i + 1}: to {way[i].X}:{way[i].Y}");
            }

            Console.ReadKey();
        }
    }
}