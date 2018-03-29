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

        private void btnTxt_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(((Button)sender).Text);

        }

        private void btnJson_Click(object sender, EventArgs e)
        {

        }

        private void btnXml_Click(object sender, EventArgs e)
        {

        }

        private void LoadAlumnoData()
        {
            alumno.ID = Convert.ToInt32(txtId.Text);
            alumno.Nombre = txtNombre.Text;
            alumno.ID = Convert.ToInt32(txtId.Text);
            alumno.ID = Convert.ToInt32(txtId.Text);

        }

    }
}
