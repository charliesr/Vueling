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
    public partial class AlumnoShowForm : Form
    {
        private readonly IStudentBL _studentBL = new StudentBL();
        public AlumnoShowForm()
        {
            InitializeComponent();

            this.dgvResults.DataSource = _studentBL.GetAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            var studentsBL
        }
    }
}
