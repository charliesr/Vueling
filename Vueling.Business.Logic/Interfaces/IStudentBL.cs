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
        Student GetByGUID(Guid guid);
        List<Student> GetAll();
        int DeleteByGUID(Guid guid);
        Student Update(int id, Student student);
        int CalcularEdad(DateTime registro, DateTime nacimiento);
        Student GetById(int id);
        int DeleteById(int id);
    }
}
