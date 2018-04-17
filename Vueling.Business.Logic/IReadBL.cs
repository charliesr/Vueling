using System;
using System.Collections.Generic;
using Vueling.Common.Logic;
using Vueling.DataAccess.DAO;

namespace Vueling.Business.Logic
{
    public interface IReadBL<T>
    {
        List<T> GetAll(DataTypeAccess dataTypeAccess);
    }
}
