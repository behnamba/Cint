using Cint.RobotCleaner.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Domain
{
    public enum Direction
    {
        N,
        S,
        W,
        E
    }

    public class CleanTask : ICleanTask
    {
        public const int MaxSteps = 100000;
        public const int MinSteps = 1;

        public Direction Direction { get; set; }

        int _steps;
        public int Steps
        {
            get
            {
                return _steps;
            }
            private set
            {
                if (value < MinSteps)
                {
                    _steps = MinSteps;
                }
                else if (value > MaxSteps)
                {
                    _steps = MaxSteps;
                }
                else
                {
                    _steps = value;
                }
            }
        }

        public CleanTask(string command)
        {
            Steps = int.Parse(command.Split(' ')[1]);

            string directionStr = command.Split(' ')[0];
            Direction = Common.Helpers.EnumHelper.ParseEnum<Direction>(directionStr);
        }

        public Point DoClean(Point currentPosition, ILogger logger)
        {
            // for the start point
            logger.AddLog(currentPosition);

            for (int i = 0; i < Steps; i++)
            {
                switch (Direction)
                {
                    case Direction.N:
                        currentPosition = new Point(currentPosition.X, currentPosition.Y + 1);
                        break;
                    case Direction.E:
                        currentPosition = new Point(currentPosition.X + 1, currentPosition.Y);
                        break;
                    case Direction.S:
                        currentPosition = new Point(currentPosition.X, currentPosition.Y - 1);
                        break;
                    case Direction.W:
                        currentPosition = new Point(currentPosition.X - 1, currentPosition.Y);
                        break;
                }

                logger.AddLog(currentPosition);
            }

            return currentPosition;
        }
    }
}
