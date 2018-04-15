using System;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic;
using System.Reflection;
using System.IO;
using System.Security;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Vueling.Common.Logic.Utils;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Student alumno;
        private IStudentBL alumnoBL;
        
        public AlumnoForm()
        {
            // dibuja todos los controles
            InitializeComponent();
            alumno = new Student();
            alumnoBL = new StudentBL();
            SetFormat(ConfigurationUtils.LoadFormat());
        }

        private void SetFormat(string format)
        {
            lbActualFormat.Text = format;
            this.configuraciónToolStripMenuItem.DropDownItems
                .Cast<ToolStripMenuItem>().ToList()
                .ForEach(item => item.Checked = false);
            this.configuraciónToolStripMenuItem.DropDownItems
                .Cast<ToolStripMenuItem>()
                .First(item => item.Text.Contains(format)).Checked = true;
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
            catch (FormatException ex)
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

        private void AplicarTraducciones()
        {
            var resources = new ComponentResourceManager(this.GetType());
            GetChildren(this).ToList().ForEach(ctrl =>
            {
                resources.ApplyResources(ctrl, ctrl.Name);
            });
            Text = resources.GetString("$this.text");
            lbActualFormat.Text = ConfigurationUtils.LoadFormat();
        }

        private IEnumerable<Control> GetChildren(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetChildren(ctrl)).Concat(controls);
        }

        private void CambiaIdioma_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(((ToolStripMenuItem)sender).Text);
            ((ToolStripMenuItem)sender).Checked = true;
            this.idiomaToolStripMenuItem.DropDownItems
                .Cast<ToolStripMenuItem>().ToList()
                .ForEach(item => item.Checked = false);
            ((ToolStripMenuItem)sender).Checked = true;
            AplicarTraducciones();
        }

        private void ChangeFormatConfig(object sender, EventArgs e)
        {
            var format = ((ToolStripMenuItem)sender).Text;
            alumnoBL.ChangeFormat(EnumsHelper.StringToDataTypeAccess(format));
            ConfigurationUtils.SaveFormat(format);
            SetFormat(format);
        }

        private void SaveEntity(object sender, EventArgs e)
        {
            try
            {
                _log.Debug("Clicado el botón de guardar en " + ConfigurationUtils.LoadFormat());
                LoadAlumnoData();
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
    }
}
