using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Domain.Base
{
    public interface IRobot
    {
        int TasksCount { get; set; }
        Point CurrentPosition { get; set; }

        bool IsValid { get; }
        void DoCleaning();
        void AddCleanTask(string command);
        string Display();
    }
}
