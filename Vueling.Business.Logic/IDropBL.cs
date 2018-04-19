using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.Business.Logic
{
    public interface IDropBL<T> where T : IVuelingModelObject
    {
        int DropByGUID(Guid guid);
        int DropById(int id);
    }
}
