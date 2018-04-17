using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO.Formats
{
    public interface IBaseDao
    {
        void ChangeFormat(DataTypeAccess dataTypeAccess);
    }
}