using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic;
using System.Linq.Expressions;

namespace Vueling.Business.Logic.Interfaces
{
    public interface IStudentBL : IBaseBL<Student>
    {
        int CalcularEdad(DateTime registro, DateTime nacimiento);
    }
}
