using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace ToteBettinProblem
{
    public class TestModule:Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IGame>().To<ToteBettingGame>().WithConstructorArgument(15.00);
            Bind<IGame>().To<TotePlaceBettingGame>().WithConstructorArgument(14.5);
        }
    }
}
