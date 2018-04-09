using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;

namespace Vueling.Business.Logic
{
    public interface ICrudReadBL<T>
    {
        List<T> GetAll(DataTypeAccess dataTypeAccess);
    }
}
