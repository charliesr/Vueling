using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoShowForm : Form
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IStudentBL _studentBL = new StudentBL();
        private List<Student> students = new List<Student>();
        public AlumnoShowForm()
        {
            InitializeComponent();
            GridRestart(_studentBL.GetAll(DataTypeAccess.txt));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _log.Debug("Filtramos DataGridView");
            IEnumerable<Student> query = students.AsEnumerable();
            if (!string.IsNullOrEmpty(txtGuid.Text)) query = query.Where(s => s.Guid.ToString().Contains(txtGuid.Text));
            if (!string.IsNullOrEmpty(txtID.Text)) query = query.Where(s => s.ID == Convert.ToInt32(txtID.Text));
            if (!string.IsNullOrEmpty(txtNombre.Text)) query = query.Where(s => s.Nombre.Contains(txtNombre.Text));
            if (!string.IsNullOrEmpty(txtApellidos.Text)) query = query.Where(s => s.Apellidos.Contains(txtApellidos.Text));
            if (!string.IsNullOrEmpty(txtDni.Text)) query = query.Where(s => s.DNI.Contains(txtDni.Text));
            query = query.Where(s => s.Edad == nudEdad.Value);
            query = query.Where(s => s.FechaDeNacimiento > dtpNacimiento.Value);
            query = query.Where(s => s.FechaHoraRegistro > dtpRegistro.Value);
            this.dgvResults.DataSource = query.ToList();
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            _log.Debug("Cargamos los datos desde Json");
            GridRestart(_studentBL.GetAll(DataTypeAccess.json));
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            _log.Debug("Cargamos los datos desde xml");
            GridRestart(_studentBL.GetAll(DataTypeAccess.xml));
        }

        private void GridRestart(List<Student> source)
        {
            _log.Debug("Restablecemos la grid con nuevos datos");
            this.dgvResults.DataSource = source;
            students = source;
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            _log.Debug("Cargamos los datos desde txt");
            GridRestart(_studentBL.GetAll(DataTypeAccess.txt));
        }
    }
}
