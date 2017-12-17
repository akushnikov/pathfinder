using Pathfined.App.Interfaces;

namespace Pathfined.App.Models
{
    public class Location : ILocation
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case ILocation location:
                    return X == location.X && Y == location.Y;
                default:
                    return false;
            }
        }
    }
}