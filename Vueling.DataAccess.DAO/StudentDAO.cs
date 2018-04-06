using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;

namespace Vueling.DataAccess.DAO
{
    public class StudentDao : IStudentDao
    {
        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IFormat<Student> _format;

        public StudentDao()
        {
            _format = FormatFactory<Student>.GetFormat((DataTypeAccess)Enum.Parse(typeof(DataTypeAccess), ConfigurationManager.AppSettings["DefaultDataAccesType"]));
        }

        public Student Add(Student alumno)
        {
            try
            {
                _log.Debug("Añadiendo " + typeof(Student).Name);
                _format.Insert(alumno);
                return _format.Select(alumno.Guid);
            }
            catch (ArgumentNullException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error(ex);
                throw;
            }

        }

        public void ChangeFormat(DataTypeAccess dataTypeAccess)
        {
            _log.Debug("Factory pedimos " + dataTypeAccess.ToString());
            _format = FormatFactory<Student>.GetFormat(dataTypeAccess);
        }

        public List<Student> GetAll(DataTypeAccess dataTypeAccess)
        {
            try
            {
                _log.Debug("Obtenemos todos " + typeof(Student).ToString());
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
            catch (FileNotFoundException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error(ex);
                throw;
            }
        }
    }
}
