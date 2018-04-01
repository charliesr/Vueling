using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using System.Configuration;
using System;

namespace Vueling.DataAccess.DAO
{
    public class StudentDao : IStudentDao
    {
        private IFormat<Student> _format;

        public StudentDao()
        {
            _format = FormatFactory<Student>.GetFormat((Enums.DataTypeAccess)Enum.Parse(typeof(Enums.DataTypeAccess),ConfigurationManager.AppSettings["DefaultDataAccesType"]));
        }

        public Student Add(Student alumno)
        {
            _format.Insert(alumno);
            return _format.Select(alumno.Guid);
        }

        public void ChangeFormat(Enums.DataTypeAccess dataTypeAccess)
        {
            _format = FormatFactory<Student>.GetFormat(dataTypeAccess);
        }
    }
}
