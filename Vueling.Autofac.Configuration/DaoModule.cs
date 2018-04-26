using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.DataAccess.DAO;
using Vueling.DataAccess.DAO.FormatImplementations;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.Autofac.Configuration
{
    public class DaoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder
                .RegisterGeneric(typeof(SqlFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.sql, typeof(IFormat<>));
            builder
                .RegisterGeneric(typeof(TxtFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.txt, typeof(IFormat<>));
            builder
                .RegisterGeneric(typeof(JsonFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.json, typeof(IFormat<>));
            builder
                .RegisterGeneric(typeof(SqlStoredProcedureFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.sqlStoredProcedure, typeof(IFormat<>));
            builder
                .RegisterGeneric(typeof(XmlFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.xml, typeof(IFormat<>));
            builder
                .RegisterGeneric(typeof(WebApiFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.webApi, typeof(IFormat<>));
            builder
                .RegisterGeneric(typeof(WebApiFormat<>))
                .As(typeof(IConnection<>));

            builder
                .RegisterType<HttpClient>();

            base.Load(builder);
        }
    }
}
