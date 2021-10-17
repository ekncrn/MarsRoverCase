using Mars_Rover.Helper;
using Mars_Rover.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Mars_Rover.Services
{
    public interface IBusinessService 
    {
        public List<Rover> GetRovers(int count);
        public void Process(string rotate, Rover rover);
        public DirectionInfo GetDirectionInfo(Rotate? newRotate, Direction roverDirection);
    }
    public class BusinessService : IBusinessService
    {
        public List<Rover> GetRovers(int count)
        {
            List<Rover> rovers = new List<Rover>();
            Random rnd = new Random();
            for (int i = 0; i< count; i++)
            {
                rovers.Add(new Rover());
            }
            return rovers;
        }
        public void Process(string rotate, Rover rover)
        {
            foreach (var chr in rotate)
            {
                Enum.TryParse(chr.ToString(), out Rotate rotatee);
                SetNewLocation(rotatee, rover);
            }
        }

        private void SetNewLocation(Rotate newRotate, Rover rover)
        {
            if (newRotate == Rotate.M)
            {
                DirectionInfo directionInfo = GetDirectionInfo(rover.Rotate, rover.CurrentDirection);
                if (directionInfo.Coordinate == "x" && (rover.x + directionInfo.Value) <= Constants.Plateau_x)
                    rover.x += directionInfo.Value;
                else if (directionInfo.Coordinate == "y" && (rover.y + directionInfo.Value) <= Constants.Plateau_y)
                    rover.y += directionInfo.Value;
            }
            else
            {
                DirectionInfo directionInfo = GetDirectionInfo(newRotate, rover.CurrentDirection);
                rover.CurrentDirection = directionInfo.NextDirection;
                rover.Rotate = newRotate;
            }

        }

        public DirectionInfo GetDirectionInfo(Rotate? newRotate, Direction roverDirection)
        {
            return Constants.DirectionInfos.Where(x => (newRotate == null || x.Rotate == newRotate.Value) && x.Direction == roverDirection).FirstOrDefault();
        }
    }
}
