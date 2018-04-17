using System;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public interface IDelete<T> where T : IVuelingModelObject
    {
        bool DeleteByGuid(Guid guid);
    }
}