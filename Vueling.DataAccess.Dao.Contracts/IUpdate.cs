using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.Contracts
{
    public interface IUpdate<T> where T : IVuelingModelObject
    {
        T Update(T entity);
    }
}
