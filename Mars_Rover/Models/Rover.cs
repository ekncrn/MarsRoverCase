

namespace Mars_Rover.Models
{
    public class Rover
    {
        public int x { get; set; }
        public int y { get; set; }
        public Direction CurrentDirection { get; set; }
        public Rotate? Rotate { get; set; }
    }
}
