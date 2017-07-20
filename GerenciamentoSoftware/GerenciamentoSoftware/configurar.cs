using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace GerenciamentoSoftware
{
    public partial class configurar : Form
    {
        public configurar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "TVT@ltiris#")
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\config.exe");
                this.Close();
            }
            else
            {
                MessageBox.Show(null, "Senha errada favor contactar o Administrador.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text == "TVT@ltiris#")
                {
                    Process.Start(Directory.GetCurrentDirectory() + "\\config.exe");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(null, "Senha errada favor contactar o Administrador.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
