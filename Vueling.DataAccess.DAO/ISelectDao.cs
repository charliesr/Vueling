using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO.Formats;

namespace Vueling.DataAccess.DAO
{
    public interface ISelectDao<T> : ISelect<T>, IBaseDao where T : IVuelingModelObject { }
}