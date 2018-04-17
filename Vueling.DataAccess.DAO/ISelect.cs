using System;
using System.Collections.Generic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public interface ISelect<T> where T : IVuelingModelObject
    {
        T GetByGUID(Guid guid);
        List<T> GetAll();
    }
}