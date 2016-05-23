using System;

namespace Cint.RobotCleaner.Domain
{
    public class Point : IEquatable<Point>
    {
        public const int MaxPoint = 100000;
        public const int MinPoint = -100000;

        int _x;
        public int X
        {
            get { return _x; }
            private set
            {
                if (value < MinPoint)
                {
                    _x = MinPoint;
                }
                else if (value > MaxPoint)
                {
                    _x = MaxPoint;
                }
                else
                {
                    _x = value;
                }
            }
        }

        int _y;
        public int Y
        {
            get
            {
                return _y;
            }
            private set
            {
                if (value < -100000)
                {
                    _y = -100000;
                }
                else if (value > 100000)
                {
                    _y = 100000;
                }
                else
                {
                    _y = value;
                }
            }
        }

        public Point(string points)
        {
            X = int.Parse(points.Split(' ')[0]);
            Y = int.Parse(points.Split(' ')[1]);
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            if (X == other.X && Y == other.Y)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hashX = X.GetHashCode();
            int hashY = Y.GetHashCode();

            return hashX ^ hashY;
        }
    }
}