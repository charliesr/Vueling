using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .Keyed(DataTypeAccess.sql, typeof(IFormat<>))
                .InstancePerRequest();
            builder
                .RegisterGeneric(typeof(TxtFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.txt, typeof(IFormat<>))
                .InstancePerRequest();
            builder
                .RegisterGeneric(typeof(JsonFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.json, typeof(IFormat<>))
                .InstancePerRequest();
            builder
                .RegisterGeneric(typeof(SqlStoredProcedureFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.sqlStoredProcedure, typeof(IFormat<>))
                .InstancePerRequest();
            builder
                .RegisterGeneric(typeof(XmlFormat<>))
                .As(typeof(IFormat<>))
                .Keyed(DataTypeAccess.xml, typeof(IFormat<>))
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
