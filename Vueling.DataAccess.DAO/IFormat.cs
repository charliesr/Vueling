using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAccess.DAO
{
    public interface IFormat<T> where T : class
    {
        string Filename { get; set; }
        T Insert(T entity);
        T Select(Guid guid);
    }
}
