using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using Vueling.Business.Logic.Interfaces;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.Business.Logic
{
    public class StudentBL : IStudentBL
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISelect<Student> _selectDao;
        private readonly IDelete<Student> _deleteDao;
        private readonly IUpdate<Student> _updateDao;
        private readonly IInsert<Student> _insertDao;

        public StudentBL(ISelect<Student> selectDao, IInsert<Student> insertDao, IUpdate<Student> updateDao, IDelete<Student> deleteDao)
        {
            this._deleteDao = deleteDao;
            this._insertDao = insertDao;
            this._selectDao = selectDao;
            this._updateDao = updateDao;
        }


        public Student Add(Student alumno)
        {
            try
            {
                _log.Debug("Llamado método add del BL");
                if (alumno.Guid == Guid.Empty) alumno.Guid = Guid.NewGuid();
                alumno.FechaHoraRegistro = DateTime.Now;
                alumno.Edad = CalcularEdad(alumno.FechaHoraRegistro, alumno.FechaDeNacimiento);
                return this._insertDao.Add(alumno);
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
                return this._selectDao.GetAll();
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
                return this._selectDao.GetByGUID(guid);
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
                return this._deleteDao.DeleteByGuid(guid);
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
                return this._updateDao.Update(student);
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
                return this._selectDao.GetById(id);
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
                return _deleteDao.DeleteById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }
    }
}
