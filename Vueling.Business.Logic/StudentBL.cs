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
        private readonly IReadBL<Student> _readBL = new CrudBL<Student>();
        private readonly ISaveBL<Student> _saveBL = new CrudBL<Student>();
        public event EventHandler<DataTypeAccess> ChangeFormatPetition;

        public Student Add(Student alumno)
        {
            try
            {
                _log.Debug("Llamado método add del BL");
                alumno.FechaHoraRegistro = DateTime.Now;
                alumno.Edad = CalcularEdad(alumno.FechaHoraRegistro, alumno.FechaDeNacimiento);
                return _saveBL.Add(alumno);
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

        public List<Student> GetAll(DataTypeAccess dataTypeAccess)
        {
            try
            {
                _log.Debug("Método Get All alumnos");
                return _readBL.GetAll(dataTypeAccess);
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

        public void ChangeFormat(DataTypeAccess dataTypeAccess)
        {
            _log.Debug("Cambiamos el formato de la factory (formato del archivo a) " + dataTypeAccess.ToString());
            ChangeFormatPetition?.Invoke(this, dataTypeAccess);
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
    }
}
