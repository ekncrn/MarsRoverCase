using Mars_Rover.Helper;
using Mars_Rover.Models;
using Mars_Rover.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Mars_Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IBusinessService businessService = new BusinessService();
                List<Rover> rovers = businessService.GetRovers(Int32.Parse(ConfigurationManager.AppSettings["RoverCount"]));

                Console.Write("Enter The Plateau Size: ");
                var size = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                Constants.Plateau_x = Convert.ToInt32(size[0]);
                Constants.Plateau_y = Convert.ToInt32(size[1]);

                foreach (var rover in rovers)
                {
                    Console.Write("Enter The Rover Location: ");
                    var location = Console.ReadLine().Split(' ').ToList();
                    if(location.Count == 3)
                    {
                        Enum.TryParse(location[2].ToUpper(), out Direction direction);

                        rover.x = Convert.ToInt32(location[0]);
                        rover.y = Convert.ToInt32(location[1]);
                        rover.CurrentDirection = direction;

                        Console.Write("Enter The Rover Moves: ");
                        string moves = Console.ReadLine();
                        businessService.Process(moves.ToUpper(), rover);
                    }
                }

                Console.WriteLine("***Results***");
                rovers.ForEach(x => { Console.WriteLine(x.x + " " + x.y + " " + x.CurrentDirection); });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }


    }
}
