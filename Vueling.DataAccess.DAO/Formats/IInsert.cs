using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO.Formats
{
    public interface IInsert<T>
    {
        T Add(T entity);
    }
}
