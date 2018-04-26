using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO.Interfaces
{
    public interface IConnection<T>
    {
        Student InitCache();
    }
}