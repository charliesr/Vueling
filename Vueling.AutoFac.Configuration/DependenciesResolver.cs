using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.DataAccess.DAO;
using Vueling.DataAccess.DAO.FormatImplementations;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.AutoFac.Configuration
{
    public static class DependenciesResolver
    {
        private static readonly IContainer _daoBuilder;
        private static readonly IContainer _businessBuilder;
        private static readonly IContainer _facadeBuilder;


        static DependenciesResolver()
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

            #region BusinessDependencies

            builder = new ContainerBuilder();

            builder
                .RegisterGeneric(typeof(CrudDao<>))
                .As(typeof(ISelect<>));
            builder
                .RegisterGeneric(typeof(CrudDao<>))
                .As(typeof(IUpdate<>));
            builder
                .RegisterGeneric(typeof(CrudDao<>))
                .As(typeof(IDelete<>));
            builder
                .RegisterGeneric(typeof(CrudDao<>))
                .As(typeof(IInsert<>));
            builder
                .RegisterGeneric(typeof(CrudBL<>))
                .As(typeof(IReplaceBL<>));
            builder
                .RegisterGeneric(typeof(CrudBL<>))
                .As(typeof(ISaveBL<>));
            builder
                .RegisterGeneric(typeof(CrudBL<>))
                .As(typeof(IDropBL<>));
            builder
                .RegisterGeneric(typeof(CrudBL<>))
                .As(typeof(IReadBL<>));

            _businessBuilder = builder.Build();
            #endregion

            #region FacadeDependencies
            builder = new ContainerBuilder();

            builder
                .RegisterType<StudentBL>()
                .As<IStudentBL>();

            _facadeBuilder = builder.Build();
            #endregion
        }

        public static object GetIFormat(DataTypeAccess dataTypeAccess)
        {
            return _daoBuilder.ResolveKeyed(dataTypeAccess, typeof(IFormat<>));
        }

        public static object GetIUpdate()
        {
            return _businessBuilder.Resolve(typeof(IUpdate<>));
        }

        public static object GetIInsert()
        {
            return _businessBuilder.Resolve(typeof(IInsert<>));
        }

        public static object GetIDelete()
        {
            return _businessBuilder.Resolve(typeof(IDelete<>));
        }

        public static object GetISelect()
        {
            return _daoBuilder.Resolve(typeof(ISelect<>));
        }

        public static object GetIReadBL()
        {
            return _businessBuilder.Resolve(typeof(IReadBL<>));
        }

        public static object GetIReplaceBL()
        {
            return _businessBuilder.Resolve(typeof(IReplaceBL<>));
        }

        public static object GetIDropBL()
        {
            return _businessBuilder.Resolve(typeof(IDropBL<>));
        }

        public static object GetISaveBL()
        {
            return _businessBuilder.Resolve(typeof(ISaveBL<>));
        }

        public static object GetStudentBL()
        {
            return _facadeBuilder.Resolve<IStudentBL>();
        }

    }
}
