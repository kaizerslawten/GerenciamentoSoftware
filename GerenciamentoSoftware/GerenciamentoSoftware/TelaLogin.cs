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
using System.Runtime.InteropServices; // DllImport
using System.Security.Principal; // WindowsImpersonationContext
using System.Security.Permissions; // PermissionSetAttribute

namespace GerenciamentoSoftware
{
    public partial class TelaLogin : Form
    {

        //static SqlCeConnection con = new SqlCeConnection("Data Source=TSM.sdf");

        static SqlCommand cmd;
        static SqlCommand cmd1;
        static SqlCommand cmd2;
        static SqlDataReader sdr;
        static SqlDataReader sdr2;
        static SqlDataReader str1;


        public TelaLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Teste Impersonation
        /// </summary>

        //Função de Login
        #region FUNÇÃO DE LOGIN
        public void login()
        {
            Connection con = new Connection();
            DateTime localDate = DateTime.Now;

            ArrayList lista_user = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            int i = 0;
            txt_usuario_login.Text.ToUpper();

            cmd = new SqlCommand("select username from login;", con.cone());
            cmd1 = new SqlCommand("select password from login;", con.cone());
            cmd2 = new SqlCommand("select * from login where username = '" + txt_usuario_login.Text + "'", con.cone());



            //con.Close();
            sdr = cmd.ExecuteReader();
            str1 = cmd1.ExecuteReader();
            sdr2 = cmd2.ExecuteReader();
            sdr2.Read();


            while (sdr.Read() == true)
            {
                lista_user.Add(sdr["username"].ToString());
                //MessageBox.Show("Usuário: " + lista_user[i]);
                //MessageBox.Show(sdr["username"].ToString());
                i++;
            }
            i = 0;
            while (str1.Read() == true)
            {

                lista_pass.Add(str1["password"].ToString());
                //MessageBox.Show("Senha: " + lista_pass[i]);
                //MessageBox.Show(sdr["username"].ToString());
                i++;
            }



            //MessageBox.Show(lista_user.Count.ToString());


            if (lista_user.Contains(txt_usuario_login.Text) == true)
            {
                //lista_user;lista_user.IndexOf(txt_usuario_login.Text)

                if (lista_pass[lista_user.IndexOf(txt_usuario_login.Text)].ToString() == txt_usuario_senha.Text)
                {
                    Connection cones = new Connection();
                    String query = "update login set last_logon ='" + localDate.ToString() + "',status_logon =1 where username='" + txt_usuario_login.Text + "'";
                    SqlCommand cmd3 = new SqlCommand(query, cones.cone());
                    cmd3.ExecuteNonQuery();
                    cones.cone().Close();
                    //this.Hide();
                    frmGerenciamento frmp = new frmGerenciamento(sdr2["perfil"].ToString(), sdr2["last_logon"].ToString(), sdr2["username"].ToString());
                    frmp.Closed += (s, args) => this.Close();
                    frmp.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show(null, "Falha no login, verifique senha ou usuário!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.cone().Close();
            }




            else
            {
                MessageBox.Show("Falha no login, verifique usuário ou senha!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*this.Hide();
            frmGerenciamento frmp = new frmGerenciamento();
            frmp.Closed += (s, args) => this.Close();
            frmp.Show();
             */
            //this.Visible = false;
            con.cone().Close();
        }
        #endregion
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            //DialogResult Resultado = MessageBox.Show("Gostaria de Sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // if (Resultado == DialogResult.Yes)
            // {
            Application.Exit();
            //}
        }



        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                login();
            }
            catch (System.IO.FileNotFoundException ex)
            {

                if (MessageBox.Show(null, "Arquivo de dados inexistente, deseja configura-lo agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    configurar con = new configurar();
                    con.ShowDialog();
                }
                else
                {
                }
            }
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tsmDataSet1.notas' table. You can move, or remove it, as needed.
            //this.notasTableAdapter.Fill(this.tsmDataSet1.notas);



        }



        private void txt_usuario_senha_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                login();
            }
        }




    }
}
