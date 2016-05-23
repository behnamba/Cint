using Cint.RobotCleaner.Domain;
using Cint.RobotCleaner.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initilize IOC container
            Bootstraper.InitialDependencyMappings();

            // get the data
            IRobot robot = Bootstraper.Robot;

            System.Console.WriteLine("How many command should robot expect?");
            robot.TasksCount = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("What is the start point?");
            robot.CurrentPosition = new Point(System.Console.ReadLine());

            System.Console.WriteLine("Start adding commands:");

            while (!robot.IsValid)
            {
                robot.AddCleanTask(System.Console.ReadLine());
            }

            System.Console.WriteLine("Press any key to start cleaning :-)");
            System.Console.ReadLine();

            // Do the Cleaning 
            robot.DoCleaning();
            System.Console.WriteLine(robot.Display());

            System.Console.ReadKey();
        }
    }
}
