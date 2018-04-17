using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public interface ICrudDAO<T> : IDelete<T>, ISelect<T>, IUpdate<T>, IInsert<T> where T : IVuelingModelObject
    {
        void ChangeFormat(DataTypeAccess dataTypeAccess);
    }
}
