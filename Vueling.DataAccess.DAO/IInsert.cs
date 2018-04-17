using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO
{
    public interface IInsert<T>
    {
        T Add(T entity);
    }
}
