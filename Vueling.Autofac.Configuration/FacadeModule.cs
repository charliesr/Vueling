using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;
using Vueling.Business.Logic.Interfaces;

namespace Vueling.Autofac.Configuration
{
    public class FacadeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StudentBL>()
                .As<IStudentBL>()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
