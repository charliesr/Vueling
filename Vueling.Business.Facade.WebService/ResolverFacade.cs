using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vueling.Business.Logic;

namespace Vueling.Business.Facade.WebService
{
    public class ResolverFacade
    {
        private static IContainer _facadeBuilder;
        static ResolverFacade()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<StudentBL>()
                .As<IStudentBL>();

            _facadeBuilder = builder.Build();
        }

        public static IStudentBL GetStudentBL()
        {
            return _facadeBuilder.Resolve<IStudentBL>();
        }
    }
}