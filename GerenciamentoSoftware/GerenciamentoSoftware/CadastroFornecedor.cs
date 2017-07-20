using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
//Extras
using System.Data.SqlClient;


namespace GerenciamentoSoftware
{
    public partial class CadastroFornecedor : Form
    {
        public CadastroFornecedor()
        {
            InitializeComponent();
        }

        string operacao;
        public CadastroFornecedor(string valor)
        {
            InitializeComponent();
            operacao = valor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados inseridos serão perdidos, deseja cancelar o cadastro?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList lista_user = new ArrayList();
            int i = 0;
            Connection con = new Connection();
            SqlCommand cmd1 = new SqlCommand("select cnpj from fornecedor;", con.cone());
            SqlDataReader sdr;
            sdr = cmd1.ExecuteReader();
            while (sdr.Read())
            {
                lista_user.Add(sdr["cnpj"].ToString());
                i++;
            }
            if (lista_user.Contains(cnpj.Text) == false)
            {
                DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Resultado == DialogResult.Yes)
                {

                    try
                    {


                        Connection cones = new Connection();
                        String query = "INSERT INTO fornecedor(cnpj,forn_nome,forn_contato,forn_tel_contato1,forn_tel_contato2,forn_nome_contato,forn_nome_contato_tel,forn_email) VALUES('" + cnpj.Text + "','" + nome.Text + "','" + contato.Text + "','" + tel1.Text + "','" + tel2.Text + "','" + pessoacontato.Text + "','" + telpessoa.Text + "','" + txtemail.Text + "')";
                        SqlCommand cmd = new SqlCommand(query, cones.cone());
                        cmd.ExecuteNonQuery();
                        cones.cone().Close();
                        MessageBox.Show("Cadastro efetuado com sucesso!", "AVISO");
                        this.Dispose();
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
            else
            {
                MessageBox.Show("CNPJ já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cnpj.BackColor = Color.Red;
                cnpj.Focus();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList lista_user = new ArrayList();
            int i = 0;
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("select cnpj from fornecedor;", con.cone());
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                lista_user.Add(sdr["cnpj"].ToString());
                i++;
            }
            if (lista_user.Contains(cnpj.Text))
            {
                MessageBox.Show("CNPJ já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cnpj.BackColor = Color.Red;

            }
            else
            {
                cnpj.BackColor = Color.LimeGreen;
            }
        }

        private void CadastroFornecedor_Load(object sender, EventArgs e)
        {
            if (operacao == "CLIENT")
            {
                pictureBox2.Enabled = false;
            }
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
            SqlCommand cmd1 = new SqlCommand("select cnpj from fornecedor;", con.cone());
            SqlDataReader sdr;
            sdr = cmd1.ExecuteReader();
            while (sdr.Read())
            {
                lista_user.Add(sdr["cnpj"].ToString());
                i++;
            }
            if (lista_user.Contains(cnpj.Text) == false)
            {
                DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Resultado == DialogResult.Yes)
                {

                    try
                    {


                        Connection cones = new Connection();
                        String query = "INSERT INTO fornecedor(cnpj,forn_nome,forn_contato,forn_tel_contato1,forn_tel_contato2,forn_nome_contato,forn_nome_contato_tel,forn_email) VALUES('" + cnpj.Text + "','" + nome.Text + "','" + contato.Text + "','" + tel1.Text + "','" + tel2.Text + "','" + pessoacontato.Text + "','" + telpessoa.Text + "','" + txtemail.Text + "')";
                        SqlCommand cmd = new SqlCommand(query, cones.cone());
                        cmd.ExecuteNonQuery();
                        cones.cone().Close();
                        MessageBox.Show("Cadastro efetuado com sucesso!", "AVISO");
                        //this.Dispose();
                        ClearTextBoxes();
                        ClearComboBoxes();
                        cnpj.Focus();


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
            else
            {
                MessageBox.Show("CNPJ já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cnpj.BackColor = Color.Red;
                cnpj.Focus();

            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados inseridos serão perdidos, deseja cancelar o cadastro?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }
    }
}
