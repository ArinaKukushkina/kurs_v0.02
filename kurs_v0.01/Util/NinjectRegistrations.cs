using BLL;
using BLL.Interface;
using BLL.Service;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIApp.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IOutService>().To<OutService>();
            Bind<IDbCrud>().To<DBDataOperation>();
        }
    }
}
