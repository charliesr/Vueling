using System.Collections.Generic;
using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO
{
    public interface ISelectDAO<T>
    {
        List<T> GetAll(DataTypeAccess dataTypeAccess);
        void ChangeFormat(DataTypeAccess dataTypeAccess);
    }
}
