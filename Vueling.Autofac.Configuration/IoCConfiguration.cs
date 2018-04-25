using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Autofac.Configuration
{
    public static class IoCConfiguration
    {
        public static IContainer Build(Assembly apiAssembly)
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterApiControllers(apiAssembly)
                .InstancePerRequest();

            builder
                .RegisterModule(new FacadeModule())
                .RegisterModule(new BusinessModule())
                .RegisterModule(new DaoModule())
                .RegisterModule(new CommonModule());

            return builder.Build();
        }
    }
}
