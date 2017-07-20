using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace GerenciamentoSoftware.update
{
    public partial class atualiza_users : Form
    {
        static string vloi;
        DateTime localDate = DateTime.Now;
        public atualiza_users()
        {
            InitializeComponent();
        }


        public atualiza_users(string valor)
        {
            InitializeComponent();
            vloi = valor;

        }

        private void atualiza_users_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //softwareBindingSource1.ResetBindings(true);
            Connection con = new Connection();
            string Str = "Select * from login where id_user = " + vloi;
            SqlCommand cmd = new SqlCommand(Str, con.cone());
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            fullname.Text = sdr["FULLNAME"].ToString();
            username.Text = sdr["USERNAME"].ToString();

            comboBox1.Text = sdr["PERFIL"].ToString();
            email.Text = sdr["EMAIL"].ToString();
            tels.Text = sdr["TELEFONES"].ToString();
            setor.Text = sdr["SETOR"].ToString();
            empresa.Text = sdr["EMPRESA"].ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados atualizados não serão salvos, deseja cancelar a atualização?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult Resultado = MessageBox.Show("Confirma as atualizações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {

                Connection cone = new Connection();
                string Str = "Select * from login where id_user = " + vloi;
                SqlCommand cmd = new SqlCommand(Str, cone.cone());
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                cone.cone().Close();
                String query = "update login set username ='" + username.Text + "', perfil='" + comboBox1.Text + "', fullname='" + fullname.Text + "', empresa='" + empresa.Text + "', setor='" + setor.Text + "', email='" + email.Text + "',telefones='" + tels.Text + "', data_cad='" + localDate.ToString() + "' where id_user = " + vloi;
                SqlCommand cmd1 = new SqlCommand(query, cone.cone());
                cmd1.ExecuteNonQuery();
                cone.cone().Close();
                MessageBox.Show(null, "Cadastro atualizado com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
            }

        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            DialogResult Resultado = MessageBox.Show("Confirma as atualizações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {

                Connection cone = new Connection();
                string Str = "Select * from login where id_user = " + vloi;
                SqlCommand cmd = new SqlCommand(Str, cone.cone());
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                cone.cone().Close();
                String query = "update login set username ='" + username.Text + "', perfil='" + comboBox1.Text + "', fullname='" + fullname.Text + "', empresa='" + empresa.Text + "', setor='" + setor.Text + "', email='" + email.Text + "',telefones='" + tels.Text + "', data_cad='" + localDate.ToString() + "' where id_user = " + vloi;
                SqlCommand cmd1 = new SqlCommand(query, cone.cone());
                cmd1.ExecuteNonQuery();
                cone.cone().Close();
                MessageBox.Show(null, "Cadastro atualizado com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados atualizados não serão salvos, deseja cancelar a atualização?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
