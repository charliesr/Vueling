using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO
{
    public interface IInsertDAO<T>
    {
        T Add(T entity);
        void ChangeFormat(DataTypeAccess dataTypeAccess);
    }
}
