using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cint.RobotCleaner.Domain.Base;

namespace Cint.RobotCleaner.Domain
{
    public class StandardLogger : ILogger
    {
        public List<Point> VisitedPoint
        {
            get; set;
        }

        public StandardLogger()
        {
            VisitedPoint = new List<Point>();
        }

        public void AddLog(Point point)
        {
            VisitedPoint.Add(point);
        }

        public string ReadLog()
        {
            return string.Format("=> Cleaned: {0}", VisitedPoint.Distinct().Count());
        }
    }
}
