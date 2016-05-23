using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Domain.Base
{
    public interface ILogger
    {
        List<Point> VisitedPoint { get; set; }

        void AddLog(Point point);

        string ReadLog();
    }
}
