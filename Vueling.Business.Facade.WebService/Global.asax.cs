using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Vueling.Autofac.Configuration;
using Vueling.Business.Facade.WebService.App_Start;
using Vueling.Business.Logic.Interfaces;

namespace Vueling.Business.Facade.WebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = IoCConfiguration.Build(Assembly.GetExecutingAssembly());

            GlobalConfiguration.Configuration.DependencyResolver = 
                new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Filters.Add(new CustomExceptionFilter());


            var studentBl = container.Resolve<IStudentBL>();
            var student = studentBl.InitStudent();

        }
    }
}
