using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.Contracts
{
    public interface IFormat<T> : ISelect<T>, IInsert<T>, IUpdate<T>, IDelete<T> where T : IVuelingModelObject
    {
        DataTypeAccess GetFormat();
    }
}
