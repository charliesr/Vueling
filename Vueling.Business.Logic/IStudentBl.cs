using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic;

namespace Vueling.Business.Logic
{
    public interface IStudentBL
    {
        Student Add(Student alumno);
        void ChangeFormat(Enums.DataTypeAccess dataTypeAccess);
    }
}
