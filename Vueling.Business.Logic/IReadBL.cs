using System;
using System.Collections.Generic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO;

namespace Vueling.Business.Logic
{
    public interface IReadBL<T>
    {
        List<T> GetAll();
        T GetByGUID(Guid guid);
        T GetById(int id);
    }
}
