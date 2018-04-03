﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO;

namespace Vueling.Business.Logic
{
    public class StudentBL : IStudentBL
    {
        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IStudentDao _studentDao;
        public StudentBL()
        {
            _studentDao = new StudentDao();
        }
        public Student Add(Student alumno)
        {
            _log.Debug("Llamado método add del BL");
            alumno.FechaHoraRegistro = DateTime.Now;
            alumno.Edad = CalcularEdad(alumno.FechaHoraRegistro.Year,alumno.FechaDeNacimiento.Year);
            return _studentDao.Add(alumno);
        }

        public void ChangeFormat(Enums.DataTypeAccess dataTypeAccess)
        {
            _log.Debug("Cambiamos el formato de la factory (formato del archivo a) " + dataTypeAccess.ToString());
            _studentDao.ChangeFormat(dataTypeAccess);
        }

        public int CalcularEdad(int registro, int nacimiento)
        {
            _log.Debug(string.Format("Calculamos la edad pardiendo de {0} (Registro) {1} (Nacimiento)", registro, nacimiento));
            return registro - nacimiento;
        }

    }
}