using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO.Interfaces
{
    public interface IUpdate<T> where T : IVuelingModelObject
    {
        T Update(T entity);
    }
}
