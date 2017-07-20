using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.IO;

namespace GerenciamentoSoftware.update
{
    public partial class atualiza_forn : Form
    {
        static string vloi;
        public atualiza_forn()
        {
            InitializeComponent();
        }

        string deco()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "\\config.cfg");
            byte[] b = (Convert.FromBase64String(file.ReadLine()));
            String dec = Encoding.UTF8.GetString(b);
            return dec;
        }

        string operacao;
        public atualiza_forn(string valor, string valor1)
        {
            InitializeComponent();
            vloi = valor;
            operacao = valor1;
        }

        private void atualiza_forn_Load(object sender, EventArgs e)
        {
            if (operacao == "CLIENT")
            {
                pictureBox2.Enabled = false;
            }

            DataTable dt = new DataTable();
            //softwareBindingSource1.ResetBindings(true);
            Connection cone = new Connection();
            string Str = "Select * from fornecedor where id_forn = " + vloi;
            SqlCommand cmd = new SqlCommand(Str, cone.cone());
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            cnpj.Text = sdr["cnpj"].ToString();
            nome.Text = sdr["forn_nome"].ToString();
            contato.Text = sdr["forn_contato"].ToString();
            tel1.Text = sdr["forn_tel_contato1"].ToString();
            tel2.Text = sdr["forn_tel_contato2"].ToString();
            pessoacontato.Text = sdr["forn_nome_contato"].ToString();
            telpessoa.Text = sdr["forn_nome_contato_tel"].ToString();
            txtemail.Text = sdr["forn_email"].ToString();
            cone.cone().Close();

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
            Connection cone = new Connection();
            DialogResult Resultado = MessageBox.Show("Confirma as atualizações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {


                String query = "update fornecedor set cnpj ='" + cnpj.Text + "', forn_nome='" + nome.Text + "',forn_contato='" + contato.Text + "',forn_tel_contato1='" + tel1.Text + "',forn_tel_contato2='" + tel2.Text + "',forn_nome_contato='" + pessoacontato.Text + "',forn_nome_contato_tel='" + telpessoa.Text + "',forn_email='" + txtemail.Text + "' where id_forn = '" + vloi + "'";
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados atualizados não serão salvos, deseja cancelar a atualização?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Connection cone = new Connection();
            DialogResult Resultado = MessageBox.Show("Confirma as atualizações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {


                String query = "update fornecedor set cnpj ='" + cnpj.Text + "', forn_nome='" + nome.Text + "',forn_contato='" + contato.Text + "',forn_tel_contato1='" + tel1.Text + "',forn_tel_contato2='" + tel2.Text + "',forn_nome_contato='" + pessoacontato.Text + "',forn_nome_contato_tel='" + telpessoa.Text + "',forn_email='" + txtemail.Text + "' where id_forn = '" + vloi + "'";
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
    }
}
