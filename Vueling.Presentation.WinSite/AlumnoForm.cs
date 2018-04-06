using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic;
using System.Reflection;
using System.IO;
using System.Security;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        private IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Student alumno;
        private IStudentBL alumnoBL;
        public AlumnoForm()
        {
            // dibuja todos los controles
            InitializeComponent();
            alumno = new Student();
            alumnoBL = new StudentBL();
        }

        private void BtnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                _log.Debug("Clicado el botón de guardar en TXT");
                LoadAlumnoData();
                alumnoBL.ChangeFormat(DataTypeAccess.txt);
                alumnoBL.Add(alumno);
            }
            catch (OverflowException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (ArgumentNullException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (PathTooLongException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (NotSupportedException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (SecurityException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
        }

        private void BtnJson_Click(object sender, EventArgs e)
        {
            try
            {
                _log.Debug("Clicado el botón de guardar en JSon");
                LoadAlumnoData();
                alumnoBL.ChangeFormat(DataTypeAccess.json);
                alumnoBL.Add(alumno);
            }
            catch (OverflowException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (ArgumentNullException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (PathTooLongException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (NotSupportedException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (SecurityException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
        }

        private void BtnXml_Click(object sender, EventArgs e)
        {
            try
            {
                _log.Debug("Clicado el botón de guardar en Xml");
                LoadAlumnoData();
                alumnoBL.ChangeFormat(DataTypeAccess.xml);
                alumnoBL.Add(alumno);
            }
            catch (OverflowException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (ArgumentNullException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (PathTooLongException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (NotSupportedException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
            catch (SecurityException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
        }

        private void LoadAlumnoData()
        {
            try
            {
                _log.Debug("Cargamos datos del alumno en el form");
                alumno.SetGuid();
                alumno.ID = Convert.ToInt32(txtId.Text);
                alumno.Nombre = txtNombre.Text;
                alumno.Apellidos = txtApellidos.Text;
                alumno.DNI = txtDni.Text;
                alumno.FechaDeNacimiento = dtpFechaNacimiento.Value;
            }
            catch (OverflowException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
        }

        private void btnOpenShowStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var formShowStudent = new AlumnoShowForm();
                formShowStudent.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                _log.Error(ex);
                MessageBoxUtil.ShowException(ex);
            }
        }
    }
}
