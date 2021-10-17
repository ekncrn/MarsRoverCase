using Mars_Rover.Helper;
using Mars_Rover.Models;
using Mars_Rover.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mars_Rover_Test
{
    public class UnitTest
    {        
        [Theory]
        [InlineData(5, 5,"1", "2", "N", "LMLMLMLMM", "1", "3", "N")]
        [InlineData(5, 5, "3", "3", "E", "MMRMMRMRRM", "5", "1", "E")]
        public void ProcessTest(int plateau_x, int plateau_y, string rover_x, string rover_y, string direction, string moves, string expected_x, string expected_y, string expected_direc)
        {
            Constants.Plateau_x = plateau_x;
            Constants.Plateau_y = plateau_y;

            IBusinessService businessService = new BusinessService();
            Rover rover = new Rover()
            {
                x = Convert.ToInt32(rover_x),
                y = Convert.ToInt32(rover_y),
                CurrentDirection = (Direction)Enum.Parse(typeof(Direction), direction)
            };
            businessService.Process(moves, rover);

            Assert.Equal(expected_x, rover.x.ToString());
            Assert.Equal(expected_y, rover.y.ToString());
            Assert.Equal(expected_direc, rover.CurrentDirection.ToString());
        }

        
        [Fact]
        public void GetRoversTest()
        {
            int count = 5;
            IBusinessService businessService = new BusinessService();
            List<Rover> list =  businessService.GetRovers(count);
            Assert.True(list.Any());
            Assert.Equal(list.Count(), count);
        }

        [Theory]
        [InlineData("L", "N", "W", "y")]
        [InlineData("R", "E", "S", "x")]
        public void GetDirectionInfoTest(string rotate, string direction, string nextDirection, string coordinate)
        {
            IBusinessService businessService = new BusinessService();
            DirectionInfo directionInfo=  businessService.GetDirectionInfo((Rotate)Enum.Parse(typeof(Rotate), rotate), (Direction)Enum.Parse(typeof(Direction), direction));

            Assert.NotNull(directionInfo);
            Assert.Equal(nextDirection, directionInfo.NextDirection.ToString());
            Assert.Equal(coordinate, directionInfo.Coordinate);
        }
    }
}
