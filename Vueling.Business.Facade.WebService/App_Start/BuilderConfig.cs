using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Vueling.Autofac.Configuration;
using Vueling.Business.Logic;

namespace Vueling.Business.Facade.WebService.App_Start
{
    public class BuilderConfig
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterType<StudentBL>()
                .As<IStudentBL>()
                .InstancePerRequest();

            builder.RegisterModule(new CommonBuilder());

            return builder.Build();
        }
    }
}