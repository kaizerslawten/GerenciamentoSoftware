using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoSoftware
{
    public partial class cadastro_localidades : Form
    {
        public cadastro_localidades()
        {
            InitializeComponent();
        }

        string operacao;
        public cadastro_localidades(string valor)
        {
            InitializeComponent();
            operacao = valor;

        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void ClearComboBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is ComboBox)
                        (control as ComboBox).ResetText();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ArrayList lista_user = new ArrayList();
            int i = 0;
            Connection con = new Connection();

            DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {

                try
                {
                    Connection cones = new Connection();
                    String query = "insert into cadastro_localidades values('" + cnpj.Text + "','" + nome_site.Text + "','" + empresa.Text + "','" + endereco.Text + "','" + cidade.Text + "','" + estado.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, cones.cone());
                    cmd.ExecuteNonQuery();
                    cones.cone().Close();
                    MessageBox.Show("Cadastro efetuado com sucesso!", "AVISO");
                    ClearTextBoxes();
                    ClearComboBoxes();
                    nome_site.Focus();

                }
                catch (SqlException exe)
                {
                    MessageBox.Show(exe.ToString());
                }


            }
            else
            {
                MessageBox.Show("Cancelado", "AVISO");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cadastro_localidades_Load(object sender, EventArgs e)
        {
            if (operacao == "CLIENT")
            {
                pictureBox2.Enabled = false;
            }
        }
    }
}
