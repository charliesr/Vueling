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

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
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
            LoadAlumnoData();
            alumnoBL.ChangeFormat(Enums.DataTypeAccess.txt);
            alumnoBL.Add(alumno);
        }

        private void BtnJson_Click(object sender, EventArgs e)
        {
            LoadAlumnoData();
            alumnoBL.ChangeFormat(Enums.DataTypeAccess.json);
            alumnoBL.Add(alumno);
        }

        private void BtnXml_Click(object sender, EventArgs e)
        {
            LoadAlumnoData();
            alumnoBL.ChangeFormat(Enums.DataTypeAccess.xml);
            alumnoBL.Add(alumno);
        }

        private void LoadAlumnoData()
        {
            alumno.SetGuid();
            alumno.ID = Convert.ToInt32(txtId.Text);
            alumno.Nombre = txtNombre.Text;
            alumno.Apellidos = txtApellidos.Text;
            alumno.DNI = txtDni.Text;
            alumno.FechaDeNacimiento = dtpFechaNacimiento.Value;
        }

    }
}
