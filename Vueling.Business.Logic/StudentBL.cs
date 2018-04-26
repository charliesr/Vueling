using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using Vueling.Business.Logic.Interfaces;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.Business.Logic
{
    public class StudentBL : IStudentBL
    {
        private readonly IVuelingLogger log;
        private readonly ISelect<Student> _selectDao;
        private readonly IDelete<Student> _deleteDao;
        private readonly IUpdate<Student> _updateDao;
        private readonly IInsert<Student> _insertDao;
        private readonly ISelectStudentWebApi<Student> initiatorStudent;

        public StudentBL(ISelect<Student> selectDao, IInsert<Student> insertDao, IUpdate<Student> updateDao, IDelete<Student> deleteDao, IVuelingLogger log, ISelectStudentWebApi<Student> initiatorStudent)
        {
            this._deleteDao = deleteDao;
            this._insertDao = insertDao;
            this._selectDao = selectDao;
            this._updateDao = updateDao;
            this.initiatorStudent = initiatorStudent;
            this.log = log;
            this.log.Init(MethodBase.GetCurrentMethod().DeclaringType);
        }


        public Student Add(Student alumno)
        {
            try
            {
                log.Debug("Llamado método add del BL");
                if (alumno.Guid == Guid.Empty) alumno.Guid = Guid.NewGuid();
                alumno.FechaHoraRegistro = DateTime.Now;
                alumno.Edad = CalcularEdad(alumno.FechaHoraRegistro, alumno.FechaDeNacimiento);
                return this._insertDao.Add(alumno);
            }
            catch (ArgumentNullException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (OverflowException ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public List<Student> GetAll()
        {
            try
            {
                log.Debug("Método Get All alumnos");
                return this._selectDao.GetAll();
            }
            catch (FileNotFoundException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                log.Error(ex);
                throw;
            }

        }

        public int CalcularEdad(DateTime registro, DateTime nacimiento)
        {
            try
            {
                log.Debug(string.Format("Calculamos la edad pardiendo de {0} (Registro) {1} (Nacimiento)", registro, nacimiento));
                return Convert.ToInt32((registro - nacimiento).TotalDays / 365);
            }
            catch (OverflowException ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public Student GetByGUID(Guid guid)
        {
            try
            {
                log.Debug("Get By Guid - Business");
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
                log.Debug("Dropping by guid - BL");
                return this._deleteDao.DeleteByGuid(guid);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public Student Update(int id, Student student)
        {
            try
            {
                log.Debug("Updateing Student - BL");
                var studentToUpdate = GetById(id);
                student.Guid = studentToUpdate.Guid;
                student.FechaHoraRegistro = studentToUpdate.FechaHoraRegistro;
                student.Edad = CalcularEdad(studentToUpdate.FechaHoraRegistro, studentToUpdate.FechaDeNacimiento);
                return this._updateDao.Update(student);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public Student GetById(int id)
        {
            try
            {
                log.Debug("Get by id BL");
                return this._selectDao.GetById(id);
            }
            catch (NotImplementedException ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public int DeleteById(int id)
        {
            try
            {
                log.Debug("Delete by id BL");
                return _deleteDao.DeleteById(id);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public Student InitStudent()
        {
            return initiatorStudent.InitStudent();
        }
    }
}
