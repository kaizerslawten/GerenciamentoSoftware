using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Data.SqlClient;
using DgvFilterPopup;


namespace GerenciamentoSoftware
{
    public partial class UsuarioCadastrados : Form
    {
        public UsuarioCadastrados()
        {
            InitializeComponent();
        }

        //Variaveis utilizadas na validação da sessao
        string logado;
        string operacao;

        //Construtor que alimenta as variáveis
        public UsuarioCadastrados(string valor, string valor1)
        {
            InitializeComponent();
            logado = valor;
            operacao = valor1;

        }

        //Função que retorna o ID selecionado do GRID
        public string retornaID()
        {
            try
            {
                string a;
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                a = Convert.ToString(selectedRow.Cells["id_user"].Value);
                return a;
            }
            catch (Exception exe)
            {
                return null;
            }
        }

        //Biblioteca que atua sobre o DataGRID
        DgvFilterManager fm = new DgvFilterManager();

        //Função que Carrega os usuários logados da Ferramenta no GRID
        #region USUARIOS LOGADOS
        void carrega_logados()
        {
            DataTable dt1 = new DataTable();
            Connection con1 = new Connection();
            string contagem = "select COUNT(*) as valor from login";
            string Str1 = "select id_user,fullname as NOME,USERNAME as 'LOGIN' from login where status_logon =1";
            SqlCommand cmd = new SqlCommand(Str1, con1.cone());
            SqlCommand cmd1 = new SqlCommand(contagem, con1.cone());
            SqlDataReader read_contagem;
            read_contagem = cmd1.ExecuteReader();
            read_contagem.Read();
            sb_valor.Text = read_contagem["valor"].ToString();
            cmd.CommandTimeout = 0;
            dt1.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dt1;
            this.dataGridView2.Columns["id_user"].Visible = false;
            DataGridViewColumn column = dataGridView2.Columns[1];
            DataGridViewColumn column3 = dataGridView2.Columns[2];
            column.Width = 200;
            column3.Width = 200;

        }
        #endregion

        //Evento De Carregamento do Formulário
        #region Evento LOAD
        private void UsuarioCadastrados_Load(object sender, EventArgs e)
        {
            carrega_logados();

            if (operacao == "USER")
            {
                pictureBox13.Enabled = false;
                pictureBox1.Enabled = false;
                pictureBox12.Enabled = false;
            }
            fm.DataGridView = dataGridView1;
            panel1.Visible = false;
            panel2.Visible = false;
            // TODO: This line of code loads data into the 'tSMDataSet1.login' table. You can move, or remove it, as needed.
            DataTable dt1 = new DataTable();
            Connection con1 = new Connection();
            string contagem = "select COUNT(*) as valor from login";
            string Str1 = "select fullname as NOME,EMAIL as EMAIL,USERNAME as 'LOGIN',TELEFONES,LAST_LOGON 'ULTIMO LOGON',EMPRESA,SETOR,PERFIL,id_user from login";
            SqlCommand cmd = new SqlCommand(Str1, con1.cone());
            SqlCommand cmd1 = new SqlCommand(contagem, con1.cone());
            SqlDataReader read_contagem;
            read_contagem = cmd1.ExecuteReader();
            read_contagem.Read();
            sb_valor.Text = read_contagem["valor"].ToString();
            cmd.CommandTimeout = 0;
            dt1.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt1;
            this.dataGridView1.Columns["id_user"].Visible = false;
        }
        #endregion

        //Ação executada quando o usuário clica 2 vezes em 1 item da GRADE
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            update.atualiza_users cad = new update.atualiza_users(retornaID());
            cad.ShowDialog();
        }



        //Atualização automatica da tela quando o formulário é carregado
        private void UsuarioCadastrados_Activated(object sender, EventArgs e)
        {
            //Thread.Sleep(500);
            refresh();
        }

        //Função de Atualização do GRID
        public void refresh()
        {
            DataTable dt1 = new DataTable();
            Connection con1 = new Connection();
            string Str1 = "select fullname as NOME,EMAIL as EMAIL,USERNAME as 'LOGIN',TELEFONES,LAST_LOGON 'ULTIMO LOGON',EMPRESA,SETOR,PERFIL,id_user from login";
            SqlCommand cmd1 = new SqlCommand(Str1, con1.cone());
            cmd1.CommandTimeout = 0;
            dt1.Load(cmd1.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt1;
            this.dataGridView1.Columns["id_user"].Visible = false;
        }

        //Cadastrar novo usuário
        private void button1_Click(object sender, EventArgs e)
        {
            cadusers.cadusers1 cad = new cadusers.cadusers1();
            cad.ShowDialog();
        }

        private void UsuarioCadastrados_Enter(object sender, EventArgs e)
        {

        }





        //Botão atualizar GRADE
        private void button4_Click(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
            refresh();
        }


        private void pictureBox13_Click(object sender, EventArgs e)
        {
            cadusers.cadusers1 cad = new cadusers.cadusers1();
            cad.ShowDialog();
        }


        //Função que Remove usuários
        #region REMOVE USUÁRIOS
        private void pictureBox12_Click(object sender, EventArgs e)
        {

            try
            {

                string a;
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                a = Convert.ToString(selectedRow.Cells["id_user"].Value);
                //MessageBox.Show(a);
                Connection cones = new Connection();
                String query = "delete from login where id_user = " + a;
                SqlCommand cmd = new SqlCommand(query, cones.cone());
                cmd.ExecuteNonQuery();
                cones.cone().Close();
                //MessageBox.Show("Dados removidos com sucesso!" + valor + valor2);
                MessageBox.Show(null, "Usuário removido do cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataGridView dv = new DataGridView();



                try
                {



                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.ToString());
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(null, "Não existem registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fm.ActivateAllFilters(false);
            refresh();
        }
        #endregion

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            CadastroSoftware cad = new CadastroSoftware();
            cad.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            CadastroNota cad = new CadastroNota();
            cad.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            CadastroFornecedor cad = new CadastroFornecedor();
            cad.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cadastro_localidades cad = new cadastro_localidades();
            cad.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox1.Focus();
        }

        //Função que Reseta senha de usuários
        #region RESET DE SENHA
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            if (textBox1.Text == "")
            {
                MessageBox.Show(null, "Por favor digite o Incidente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show(null, "Por favor digite o Login!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show(null, "Por favor digite a Senha!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            else
            {
                Connection con1 = new Connection();

                string Str1 = "select count(username) as userexists from login where USERNAME = '" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(Str1, con1.cone());
                SqlDataReader read_contagem;
                read_contagem = cmd.ExecuteReader();
                read_contagem.Read();
                if ((int)read_contagem["userexists"] != 1)
                {
                    MessageBox.Show(null, "Login não cadastrado favor verificar!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox2.Focus();
                }

                else
                {
                    Connection cones = new Connection();
                    String query = "update login set password = '" + textBox3.Text + "' where username = '" + textBox2.Text + "'";
                    String query2 = "insert into reset_senha values('" + logado + "','" + textBox2.Text + "','" + textBox1.Text + "','" + localDate.ToString() + "')";
                    SqlCommand cmd1 = new SqlCommand(query, cones.cone());
                    SqlCommand cmd2 = new SqlCommand(query2, cones.cone());
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cones.cone().Close();
                    MessageBox.Show(null, "Senha resetada com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox1.Focus();
                }
            }
        }
        #endregion

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(logado)
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
            refresh();
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }


        //botao para desconectar usuários logados
        #region DESCONECTAR USUARIOS
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {

                string a;
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                a = Convert.ToString(selectedRow.Cells["id_user"].Value);
                //MessageBox.Show(a);
                Connection cones = new Connection();
                String query = "update login set status_logon = 0 where id_user = " + a;
                SqlCommand cmd = new SqlCommand(query, cones.cone());
                cmd.ExecuteNonQuery();
                cones.cone().Close();
                //MessageBox.Show("Dados removidos com sucesso!" + valor + valor2);
                MessageBox.Show(null, "Usuário desconectado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                carrega_logados();

                try
                {



                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.ToString());
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(null, "Não existem registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}

