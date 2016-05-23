using Cint.RobotCleaner.Domain;
using Cint.RobotCleaner.Domain.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.RobotCleaner.Console
{
    public class Bootstraper
    {
        static IKernel _kernel = new StandardKernel();

        public Bootstraper()
        {

        }

        public static void InitialDependencyMappings()
        {
            _kernel.Bind<ILogger>().To<StandardLogger>();
            _kernel.Bind<IRobot>().To<Robot>().WithConstructorArgument("logger", context => context.Kernel.Get<ILogger>());
        }

        public static ILogger Logger
        {
            get
            {
                return _kernel.Get<ILogger>();
            }
        }

        public static IRobot Robot
        {
            get
            {
                return _kernel.Get<IRobot>();
            }
        }
    }
}
