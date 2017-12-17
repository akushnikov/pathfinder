namespace Pathfined.App.Models
{
    public class Cell : Location
    {
        public Cell(int x, int y, byte passability) 
            : base(x, y)
        {
            Passability = passability;
        }

        public byte Passability { get; }
    }
}