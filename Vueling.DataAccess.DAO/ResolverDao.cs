using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.DataAccess.DAO.FormatImplementations;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.DataAccess.DAO
{
    public class ResolverDao
    {

        private static readonly IContainer _daoBuilder;
        static ResolverDao()
        {
            #region DaoDependencies
            var builder = new ContainerBuilder();
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
            _daoBuilder = builder.Build();

            #endregion
        }

        public static object GetIFormat(DataTypeAccess dataTypeAccess)
        {
            return _daoBuilder.ResolveKeyed(dataTypeAccess, typeof(IFormat<>));
        }

    }
}
