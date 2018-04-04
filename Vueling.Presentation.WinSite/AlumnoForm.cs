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

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        private IVuelingLogger log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
            log.Debug("Clicado el botón de guardar en TXT");
            LoadAlumnoData();
            alumnoBL.ChangeFormat(DataTypeAccess.txt);
            alumnoBL.Add(alumno);
        }

        private void BtnJson_Click(object sender, EventArgs e)
        {
            log.Debug("Clicado el botón de guardar en JSon");
            LoadAlumnoData();
            alumnoBL.ChangeFormat(DataTypeAccess.json);
            alumnoBL.Add(alumno);
        }

        private void BtnXml_Click(object sender, EventArgs e)
        {
            log.Debug("Clicado el botón de guardar en Xml");
            LoadAlumnoData();
            alumnoBL.ChangeFormat(DataTypeAccess.xml);
            alumnoBL.Add(alumno);
        }

        private void LoadAlumnoData()
        {
            log.Debug("Cargamos datos del alumno en el form");
            alumno.SetGuid();
            alumno.ID = Convert.ToInt32(txtId.Text);
            alumno.Nombre = txtNombre.Text;
            alumno.Apellidos = txtApellidos.Text;
            alumno.DNI = txtDni.Text;
            alumno.FechaDeNacimiento = dtpFechaNacimiento.Value;
        }

    }
}
