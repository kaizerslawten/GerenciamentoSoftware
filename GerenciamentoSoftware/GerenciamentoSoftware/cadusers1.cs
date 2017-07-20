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

using System.Collections;

namespace GerenciamentoSoftware.cadusers
{
    public partial class cadusers1 : Form
    {
        DateTime localDate = DateTime.Now;
        public cadusers1()
        {
            InitializeComponent();
        }


        private void cadusers1_Load(object sender, EventArgs e)
        {

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
            //SqlCeConnection con = new SqlCeConnection("Data Source=TSM.sdf");
            Connection cone = new Connection();
            SqlDataReader sdr;
            int i = 0;
            ArrayList lista_user = new ArrayList();
            SqlCommand cmduser = new SqlCommand("select username from login;", cone.cone());
            sdr = cmduser.ExecuteReader();
            while (sdr.Read() == true)
            {
                lista_user.Add(sdr["username"].ToString());
                //MessageBox.Show("Usuário: " + lista_user[i]);
                //MessageBox.Show(sdr["username"].ToString());
                i++;
            }
            if (lista_user.Contains(username.Text) == false)
            {
                DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Resultado == DialogResult.Yes)
                {
                    try
                    {//Gravando Informações no Banco

                        //String query = "INSERT INTO login(username, password, perfil, fullname, empresa, setor, email, telefones, data_cad) VALUES('" + username.Text + "','" + password.Text + "','" + comboBox1.Text + "','" + fullname.Text + "','" + empresa.Text + "','" + setor.Text + "','" + email.Text + "','" + tels.Text + "','" + localDate.ToString() + "')";
                        String query = "INSERT INTO login(USERNAME, PASSWORD, LAST_LOGON, PERFIL, FULLNAME, EMPRESA, SETOR, EMAIL, TELEFONES, DATA_CAD) VALUES('" + username.Text + "','" + password.Text + "',null,'" + comboBox1.Text + "','" + fullname.Text + "','" + empresa.Text + "','" + setor.Text + "','" + email.Text + "','" + tels.Text + "','" + localDate.ToString() + "');";
                        SqlCommand cmd = new SqlCommand(query, cone.cone());
                        cmd.ExecuteNonQuery();
                        cone.cone().Close();
                        MessageBox.Show(null, "Cadastro efetuado com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();


                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.ToString());
                    }

                }
                else
                {


                }
            }
            else
            {
                MessageBox.Show("Login já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.BackColor = Color.Red;
                username.Focus();

            }

        }

        private void setor_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            validaUsuario();
        }
        void validaUsuario()
        {
            ArrayList lista_user = new ArrayList();
            int i = 0;
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("select username from login;", con.cone());
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                lista_user.Add(sdr["username"].ToString());
                i++;
            }
            if (lista_user.Contains(username.Text))
            {
                MessageBox.Show("Login já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.BackColor = Color.Red;
                username.Focus();
            }
            else
            {
                username.BackColor = Color.LimeGreen;
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            validaUsuario();
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

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
            //SqlCeConnection con = new SqlCeConnection("Data Source=TSM.sdf");
            Connection cone = new Connection();
            SqlDataReader sdr;
            int i = 0;
            ArrayList lista_user = new ArrayList();
            SqlCommand cmduser = new SqlCommand("select username from login;", cone.cone());
            sdr = cmduser.ExecuteReader();
            while (sdr.Read() == true)
            {
                lista_user.Add(sdr["username"].ToString());
                //MessageBox.Show("Usuário: " + lista_user[i]);
                //MessageBox.Show(sdr["username"].ToString());
                i++;
            }
            if (lista_user.Contains(username.Text) == false)
            {
                DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Resultado == DialogResult.Yes)
                {
                    try
                    {//Gravando Informações no Banco

                        //String query = "INSERT INTO login(username, password, perfil, fullname, empresa, setor, email, telefones, data_cad) VALUES('" + username.Text + "','" + password.Text + "','" + comboBox1.Text + "','" + fullname.Text + "','" + empresa.Text + "','" + setor.Text + "','" + email.Text + "','" + tels.Text + "','" + localDate.ToString() + "')";
                        String query = "INSERT INTO login(USERNAME, PASSWORD, LAST_LOGON, PERFIL, FULLNAME, EMPRESA, SETOR, EMAIL, TELEFONES, DATA_CAD,status_logon) VALUES('" + username.Text + "','" + password.Text + "',null,'" + comboBox1.Text + "','" + fullname.Text + "','" + empresa.Text + "','" + setor.Text + "','" + email.Text + "','" + tels.Text + "','" + localDate.ToString() + "','0');";
                        SqlCommand cmd = new SqlCommand(query, cone.cone());
                        cmd.ExecuteNonQuery();
                        cone.cone().Close();
                        MessageBox.Show(null, "Cadastro efetuado com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTextBoxes();
                        ClearComboBoxes();
                        fullname.Focus();


                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.ToString());
                    }

                }
                else
                {


                }
            }
            else
            {
                MessageBox.Show("Login já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.BackColor = Color.Red;
                username.Focus();

            }
            UsuarioCadastrados user = new UsuarioCadastrados();

        }
    }
}
