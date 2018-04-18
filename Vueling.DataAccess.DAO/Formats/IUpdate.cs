using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO.Formats
{
    public interface IUpdate<T> where T : IVuelingModelObject
    {
        bool Update(Guid guid, T entity);
    }
}
