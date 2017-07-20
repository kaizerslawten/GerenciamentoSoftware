using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoSoftware.update
{
    public partial class atualiza_localidade : Form
    {
        public atualiza_localidade()
        {
            InitializeComponent();
        }
        string vloi, operacao;
        public atualiza_localidade(string valor, string valor1)
        {
            InitializeComponent();
            vloi = valor;
            operacao = valor1;
        }

        private void atualiza_localidade_Load(object sender, EventArgs e)
        {
            if (operacao == "CLIENT")
            {
                pictureBox2.Enabled = false;
            }
            DataTable dt = new DataTable();
            //softwareBindingSource1.ResetBindings(true);
            Connection cone = new Connection();
            string Str = "Select * from cadastro_localidades where id_localidade = " + vloi;
            SqlCommand cmd = new SqlCommand(Str, cone.cone());
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            cnpj.Text = sdr["cnpj"].ToString();
            nome_site.Text = sdr["nome_site"].ToString();
            empresa.Text = sdr["empresa"].ToString();
            endereco.Text = sdr["endereco"].ToString();
            cidade.Text = sdr["cidade"].ToString();
            estado.Text = sdr["estado"].ToString();
            cone.cone().Close();
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


                String query = "update cadastro_localidades set cnpj ='" + cnpj.Text + "',nome_site ='" + nome_site.Text + "',empresa = '" + empresa.Text + "',endereco = '" + endereco.Text + "',cidade ='" + cidade.Text + "',estado ='" + estado.Text + "' where id_localidade = " + vloi;
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
