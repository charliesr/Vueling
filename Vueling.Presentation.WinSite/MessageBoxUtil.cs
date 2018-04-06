using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vueling.Presentation.WinSite
{
    public static class MessageBoxUtil
    {
        public static void ShowException(Exception ex)
        {
            MessageBox.Show("Ha ocurrido la siguiente excepción" + ex.GetType().Name + "\n\r Información de la excepción: \n\r" + ex.Message + "\n\r Para más info Mirar el fichero de log", "Excepcion Lanzada!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
