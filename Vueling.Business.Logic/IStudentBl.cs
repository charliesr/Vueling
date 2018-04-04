using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic;
using System.Linq.Expressions;

namespace Vueling.Business.Logic
{
    public interface IStudentBL
    {
        Student Add(Student alumno);
        List<Student> GetAll(DataTypeAccess dataTypeAccess);
        void ChangeFormat(DataTypeAccess dataTypeAccess);
        int CalcularEdad(DateTime registro, DateTime nacimiento);
    }
}
