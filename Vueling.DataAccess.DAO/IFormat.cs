using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public interface IFormat<T> where T : IVuelingModelObject
    {
        T Insert(T entity);
        T Select(Guid guid);
        List<T> SelectAll();
    }
}
