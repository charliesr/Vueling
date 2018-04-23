using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.DataAccess.DAO;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.Autofac.Configuration
{
    public class CommonBuilder : Module
    {
        public override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(CrudDao<>))
                .As(typeof(IInsert<>))
                .As(typeof(ISelect<>))
                .As(typeof(IUpdate<>))
                .As(typeof(IDelete<>))
                .InstancePerRequest();




        }
    }
}
