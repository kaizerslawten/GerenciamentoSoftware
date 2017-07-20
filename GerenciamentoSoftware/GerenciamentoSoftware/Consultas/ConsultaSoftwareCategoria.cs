using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoSoftware.Consultas
{
    public partial class ConsultaSoftwareCategoria : Form
    {
        public ConsultaSoftwareCategoria()
        {
            InitializeComponent();
        }

        private void btn_cancelcadsoftware_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
