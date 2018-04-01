using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO;

namespace Vueling.Business.Logic
{
    public class StudentBL : IStudentBL
    {
        private readonly IStudentDao _studentDao;
        public StudentBL()
        {
            _studentDao = new StudentDao();
        }
        public Student Add(Student alumno)
        {
            alumno.FechaHoraRegistro = DateTime.Now;
            alumno.Edad = alumno.FechaHoraRegistro.Year - alumno.FechaDeNacimiento.Year;
            return _studentDao.Add(alumno);
        }

        public void ChangeFormat(Enums.DataTypeAccess dataTypeAccess)
        {
            _studentDao.ChangeFormat(dataTypeAccess);
        }
    }
}
