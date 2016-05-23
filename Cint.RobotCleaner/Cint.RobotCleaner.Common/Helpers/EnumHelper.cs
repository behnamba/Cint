using Cint.RobotCleaner.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Common.Helpers
{
    public class EnumHelper
    {
        public static T ParseEnum<T>(string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch
            {
                throw new InvalidEnumTypeInception("Input string is not convertable to enum.");
            }
        }
    }
}
