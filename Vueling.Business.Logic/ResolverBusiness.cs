using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.Business.Logic
{
    public static class ResolverBusiness<T> where T : IVuelingModelObject
    {
        private static IContainer _businessBuilder;
        static ResolverBusiness()
        {
            var builder = new ContainerBuilder();

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

            _businessBuilder = builder.Build();
        }

        public static IUpdate<T> GetIUpdate()
        {
            return (IUpdate<T>)_businessBuilder.Resolve(typeof(IUpdate<T>));
        }

        public static IInsert<T> GetIInsert()
        {
            return (IInsert<T>)_businessBuilder.Resolve(typeof(IInsert<T>));
        }

        public static IDelete<T> GetIDelete()
        {
            return (IDelete<T>)_businessBuilder.Resolve(typeof(IDelete<T>));
        }

        public static ISelect<T> GetISelect()
        {
            return (ISelect<T>)_businessBuilder.Resolve(typeof(ISelect<T>));
        }
    }
}
