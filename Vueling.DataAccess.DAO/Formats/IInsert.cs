using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO.Formats
{
    public interface IInsert<T> where T : IVuelingModelObject
    {
        T Add(T entity);
    }
}
