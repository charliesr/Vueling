using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Model
{
    public interface IVuelingModelObject : ICloneable
    {
        Guid Guid { get; set; }
        object[] GetPropertiesArray();
    }
}
