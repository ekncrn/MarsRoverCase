

namespace Mars_Rover.Models
{
    public class DirectionInfo
    {
        public Direction Direction { get; set; }
        public Direction NextDirection { get; set; }
        public Rotate Rotate { get; set; }
        public string Coordinate { get; set; }
        public int Value { get; set; }
    }
}
