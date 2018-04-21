using System;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO.Interfaces
{
    public interface IDelete<T> where T : IVuelingModelObject
    {
        int DeleteByGuid(Guid guid);
        int DeleteById(int id);
    }
}