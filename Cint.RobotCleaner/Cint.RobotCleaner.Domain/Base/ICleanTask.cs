using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Domain.Base
{
    public interface ICleanTask
    {
        Point DoClean(Point currentPosition, ILogger logger);
    }
}
