
using Mars_Rover.Models;
using System.Collections.Generic;

namespace Mars_Rover.Helper
{
    public class Constants
    {
        public static int Plateau_x;
        public static int Plateau_y;
        public readonly static List<DirectionInfo> DirectionInfos = new List<DirectionInfo>() 
        { 
            new DirectionInfo() { Direction = Direction.N, Rotate = Rotate.L, Coordinate = "y", Value = 1, NextDirection = Direction.W },
            new DirectionInfo() { Direction = Direction.N, Rotate = Rotate.R, Coordinate = "y", Value = 1, NextDirection = Direction.E },
            new DirectionInfo() { Direction = Direction.E, Rotate = Rotate.L, Coordinate = "x", Value = 1, NextDirection = Direction.N },
            new DirectionInfo() { Direction = Direction.E, Rotate = Rotate.R, Coordinate = "x", Value = 1, NextDirection = Direction.S },
            new DirectionInfo() { Direction = Direction.S, Rotate = Rotate.L, Coordinate = "y", Value = -1, NextDirection = Direction.E },
            new DirectionInfo() { Direction = Direction.S, Rotate = Rotate.R, Coordinate = "y", Value = -1, NextDirection = Direction.W },
            new DirectionInfo() { Direction = Direction.W, Rotate = Rotate.L, Coordinate = "x", Value = -1, NextDirection = Direction.S },
            new DirectionInfo() { Direction = Direction.W, Rotate = Rotate.R, Coordinate = "x", Value =-1, NextDirection = Direction.N }
        };
    }
}
