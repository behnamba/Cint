using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Common.Exceptions
{
    public class InvalidEnumTypeInception : Exception
    {
        public InvalidEnumTypeInception(string message) : base(message)
        {

        }
    }
}
