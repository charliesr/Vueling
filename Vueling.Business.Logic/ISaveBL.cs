using System;
using Vueling.Common.Logic;
using Vueling.DataAccess.DAO;

namespace Vueling.Business.Logic
{
    public interface ISaveBL<T>
    {
        T Add(T entity);
    }
}
