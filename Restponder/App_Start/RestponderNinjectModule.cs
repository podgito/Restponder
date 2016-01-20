using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restponder.App_Start
{
    public class RestponderNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<Restponder.Models.MockServices.IMockServiceStore>()
               .To<Restponder.Models.MockServices.ParseServiceStore>();
        }
    }
}