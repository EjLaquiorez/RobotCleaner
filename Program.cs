using System;
using System.Threading;
namespace RobotCleaner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Initialize robot");

            IStrategy zigzagStrategy = new ZigzagStrategy();

            Map map = new Map(20, 10);
            // map.Display( 10,10);

            map.AddDirt(5, 3);
            map.AddDirt(10, 8);
            map.AddObstacle(2, 5);
            map.AddObstacle(12, 1);
            map.Display(11, 8);

            Robot robot = new Robot(map, zigzagStrategy);

            robot.StartCleaning();

            Console.WriteLine("Done.");
        }
    }
}
