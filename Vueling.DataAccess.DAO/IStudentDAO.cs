using System.Collections.Generic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public interface IStudentDao
    {
        Student Add(Student alumno);
        void ChangeFormat(DataTypeAccess dataTypeAccess);
        List<Student> GetAll(DataTypeAccess dataTypeAccess);
    }
}
