using Vueling.Common.Logic;
using Vueling.DataAccess.DAO;

namespace Vueling.Business.Logic
{
    public interface ISaveBL<T> : IFormatFactory
    {
        T Add(T entity);
    }
}
