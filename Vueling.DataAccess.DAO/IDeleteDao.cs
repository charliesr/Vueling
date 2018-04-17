using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO.Formats;

namespace Vueling.DataAccess.DAO
{
    public interface IDeleteDao<T> : IDelete<T>, IBaseDao where T : IVuelingModelObject { }
}
