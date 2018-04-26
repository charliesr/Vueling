using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Utils;

namespace Vueling.Autofac.Configuration
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType(ConfigurationUtils.LoadTypeLogger())
                .As<IVuelingLogger>();


            base.Load(builder);
        }
    }
}
