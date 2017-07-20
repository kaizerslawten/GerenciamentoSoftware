using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoSoftware
{
    public partial class ajuda : Form
    {
        public ajuda()
        {
            InitializeComponent();
        }

        private void ajuda_Load(object sender, EventArgs e)
        {
            s1.Visible = false;
            s2.Visible = false;
            s4.Visible = false;
            s5.Visible = false;
            s3.Visible = false;
            s6.Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nota_Paint(object sender, PaintEventArgs e)
        {

        }

        private void software_Paint(object sender, PaintEventArgs e)
        {

        }

        private void localidade_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fornecedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void relatorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usuarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            s2.Visible = false;
            s3.Visible = false;
            s4.Visible = false;
            s5.Visible = false;
            s6.Visible = false;
            s1.Visible = true;
            software.Visible = false;
            localidade.Visible = false;
            fornecedor.Visible = false;
            usuarios.Visible = false;
            notas.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            s1.Visible = false;
            s3.Visible = false;
            s4.Visible = false;
            s5.Visible = false;
            s6.Visible = false;
            s2.Visible = true;
            localidade.Visible = false;
            fornecedor.Visible = false;
            usuarios.Visible = false;
            notas.Visible = false;
            software.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            s1.Visible = false;
            s2.Visible = false;
            s4.Visible = false;
            s5.Visible = false;
            s6.Visible = false;
            s3.Visible = true;
            software.Visible = false;
            fornecedor.Visible = false;
            usuarios.Visible = false;
            notas.Visible = false;
            localidade.Visible = true;


        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            s1.Visible = false;
            s2.Visible = false;
            s3.Visible = false;
            s5.Visible = false;
            s6.Visible = false;
            s4.Visible = true;
            software.Visible = false;
            localidade.Visible = false;
            usuarios.Visible = false;
            notas.Visible = false;
            fornecedor.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            s1.Visible = false;
            s2.Visible = false;
            s4.Visible = false;
            s5.Visible = false;
            s3.Visible = false;
            s6.Visible = true;
            software.Visible = false;
            localidade.Visible = false;
            fornecedor.Visible = false;
            notas.Visible = false;
            usuarios.Visible = true;

        }


    }
}
