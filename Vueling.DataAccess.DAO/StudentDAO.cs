using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using System.Configuration;
using System;
using System.Collections.Generic;

namespace Vueling.DataAccess.DAO
{
    public class StudentDao : IStudentDao
    {
        private IFormat<Student> _format;

        public StudentDao()
        {
            _format = FormatFactory<Student>.GetFormat((DataTypeAccess)Enum.Parse(typeof(DataTypeAccess),ConfigurationManager.AppSettings["DefaultDataAccesType"]));
        }

        public Student Add(Student alumno)
        {
            _format.Insert(alumno);
            return _format.Select(alumno.Guid);
        }

        public void ChangeFormat(DataTypeAccess dataTypeAccess)
        {
            _format = FormatFactory<Student>.GetFormat(dataTypeAccess);
        }

        public List<Student> GetAll(DataTypeAccess dataTypeAccess)
        {
            switch (dataTypeAccess)
            {
                case DataTypeAccess.json:
                    var studentsSingleton = JsonStudents.GetJsonStudents();
                    return studentsSingleton.GetAll();
                case DataTypeAccess.xml:
                    var studentsSingletonXml = XmlStudents.GetXmlStudents();
                    return studentsSingletonXml.GetAll();
                default:
                    return _format.SelectAll();
            }
        }
    }
}
