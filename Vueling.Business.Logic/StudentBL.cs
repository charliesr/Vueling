using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;

namespace Vueling.Business.Logic
{
    public class StudentBL : IStudentBL
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Student Add(Student alumno)
        {
            try
            {
                _log.Debug("Llamado método add del BL");
                if (alumno.Guid == Guid.Empty) alumno.Guid = Guid.NewGuid();
                alumno.FechaHoraRegistro = DateTime.Now;
                alumno.Edad = CalcularEdad(alumno.FechaHoraRegistro, alumno.FechaDeNacimiento);
                return ResolverBusiness<Student>.GetIInsert().Add(alumno);
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
            catch (OverflowException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public List<Student> GetAll()
        {
            try
            {
                _log.Debug("Método Get All alumnos");
                return ResolverBusiness<Student>.GetISelect().GetAll();
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

        public int CalcularEdad(DateTime registro, DateTime nacimiento)
        {
            try
            {
                _log.Debug(string.Format("Calculamos la edad pardiendo de {0} (Registro) {1} (Nacimiento)", registro, nacimiento));
                return Convert.ToInt32((registro - nacimiento).TotalDays / 365);
            }
            catch (OverflowException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public Student GetByGUID(Guid guid)
        {
            try
            {
                _log.Debug("Get By Guid - Business");
                return ResolverBusiness<Student>.GetISelect().GetByGUID(guid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteByGUID(Guid guid)
        {
            try
            {
                _log.Debug("Dropping by guid - BL");
                return ResolverBusiness<Student>.GetIDelete().DeleteByGuid(guid);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public Student Update(int id, Student student)
        {
            try
            {
                _log.Debug("Updateing Student - BL");
                var studentToUpdate = GetById(id);
                student.Guid = studentToUpdate.Guid;
                student.FechaHoraRegistro = studentToUpdate.FechaHoraRegistro;
                student.Edad = CalcularEdad(studentToUpdate.FechaHoraRegistro, studentToUpdate.FechaDeNacimiento);
                return ResolverBusiness<Student>.GetIUpdate().Update(student);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public Student GetById(int id)
        {
            try
            {
                _log.Debug("Get by id BL");
                return ResolverBusiness<Student>.GetISelect().GetById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public int DeleteById(int id)
        {
            try
            {
                _log.Debug("Delete by id BL");
                return ResolverBusiness<Student>.GetIDelete().DeleteById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }
    }
}
