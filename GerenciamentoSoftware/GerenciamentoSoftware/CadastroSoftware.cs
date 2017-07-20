using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Extras
using System.Data.SqlClient;
using System.Collections;


namespace GerenciamentoSoftware
{
    public partial class CadastroSoftware : Form
    {
        static string vloi;
        public CadastroSoftware()
        {
            InitializeComponent();
        }

        string operacao;
        public CadastroSoftware(string valor)
        {
            InitializeComponent();
            operacao = valor;
            //vloi = valor;

        }

        //static SqlCeConnection con = new SqlCeConnection("Data Source=TSM.sdf");


        //Variáveis utilizadas na busca de informações no banco de dados
        /*SqlCommand comando = new SqlCommand();
        SqlDataReader leitor;
        SqlCommand comando2 = new SqlCommand();
        SqlDataReader leitor2;
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        //Conexao com o Banco de dados
        SqlConnection conectar = new SqlConnection("Data Source = C:\\Users\\Tivit\\Documents\\Visual Studio 2012\\Projects\\GerenciamentoSoftware\\GerenciamentoSoftware\\TSM.sdf;");
        */
        //Botão de cancelar


        private void btn_cancelcadsoftware_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados inseridos serão perdidos, deseja cancelar o cadastro?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }

        }

        //Botão de cadastrar
        private void btn_cadsoftware_Click(object sender, EventArgs e)
        {
            //Instanciando Classe de Conexão    


            //Query de Inserção capturando os campos do formulário

            DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {//Gravando Informações no Banco

                    Connection cones = new Connection();
                    String query = "INSERT INTO software(soft_nome, soft_nomeExecutavel, soft_versao, soft_SO, soft_fabricante, soft_descricao, soft_uso, soft_categoria, soft_status, soft_motivo_restricao, soft_solicitante, soft_analista_ti, soft_responsavel_licenca, soft_normativo, soft_homolog_inc, soft_homolog_data, soft_data_atualizacao) VALUES('" + campoNomeSoftware.Text + "','" + campoNomeExec.Text + "','" + campoVersao.Text + "','" + campoSO.Text + "','" + campoFabricante.Text + "','" + campoDescricao.Text + "','" + campoUso.Text + "','" + campoCategoria.Text + "','" + campoStatus.Text + "','" + campoMotivo.Text + "','" + campoSolicitanteHomolog.Text + "','" + campoAnalistaTI.Text + "','" + campoResponsavelLic.Text + "','" + campoNormativo.Text + "','" + campoIncidente.Text + "','" + campoDataHomolog.Text + "','" + campoDataAtualizacao.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, cones.cone());
                    cmd.ExecuteNonQuery();
                    cones.cone().Close();
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

        private void CadastroSoftware_Load(object sender, EventArgs e)
        {
            if (operacao == "CLIENT")
            {
                pictureBox2.Enabled = false;
            }

            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            SqlDataReader sdr1;
            SqlDataReader sdr2;

            int i = 0;
            SqlCommand cmd3 = new SqlCommand("select soft_nome,soft_versao from software order by soft_nome", conexao.cone());
            SqlCommand cmd2 = new SqlCommand("select distinct software from lista_de_software order by software", conexao.cone());

            //comboempresa.Items.Add("Todos");

            //sdr2 = cmd3.ExecuteReader();
            sdr1 = cmd2.ExecuteReader();


            /*while (sdr2.Read() == true)
            {
                lista_user.Add(sdr2["soft_nome"].ToString() +" - "+ sdr2["soft_versao"].ToString());
                campoNomeSoftware.Items.Add(lista_user[i]);
                i++;
            }

            i = 0;*/

            while (sdr1.Read() == true)
            {
                lista_pass.Add(sdr1["software"].ToString());
                //MessageBox.Show("Usuário: " + lista_user[i]);
                //MessageBox.Show(sdr["username"].ToString());
                campoNomeSoftware.Items.Add(lista_pass[i]);
                i++;
            }
            //Busca no servidor a lista de software cadastrados
            /*conectar.Open();
            comando.CommandText = "select soft_nome from software";
            comando.Connection = conectar;
            leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                campoNomeSoftware.Items.Add(leitor[0]);
            }

            /*if (campoNomeSoftware.Text != "") 
            {
                string campoNomeSoft = "'" + campoNomeSoftware.SelectedText + "'";
                comando2.Connection = conectar;
                comando2.CommandText = "select soft_nomeExecutavel, soft_versao, soft_SO, soft_fabricante, soft_descricao, soft_uso, soft_categoria, soft_status, soft_motivo_restricao, soft_solicitante, soft_analista_ti, soft_responsavel_licenca, soft_normativo, soft_homolog_inc, soft_homolog_data, soft_data_atualizacao from software where soft_nome = " + campoNomeSoft.Trim() + "";
                comando2.Connection = conectar;
                leitor2 = comando2.ExecuteReader();
                bool temp = false;

                while (leitor2.Read())
                {
                    campoNomeExec.Text = leitor2.GetString(0);
                    campoVersao.Text = leitor2.GetString(1);
                    campoSO.Text = leitor2.GetString(2);
                    campoFabricante.Text = leitor2.GetString(3);
                    campoDescricao.Text = leitor2.GetString(4);
                    campoUso.Text = leitor2.GetString(5);
                    campoCategoria.Text = leitor2.GetString(6);
                    campoStatus.Text = leitor2.GetString(7);
                    campoMotivo.Text = leitor2.GetString(8);
                    campoSolicitanteHomolog.Text = leitor2.GetString(9);
                    campoAnalistaTI.Text = leitor2.GetString(10);
                    campoResponsavelLic.Text = leitor2.GetString(11);
                    campoNormativo.Text = leitor2.GetString(12);
                    campoIncidente.Text = leitor2.GetString(13);
                    campoDataHomolog.Text = leitor2.GetString(14);
                    campoDataAtualizacao.Text = leitor2.GetString(15);
                    temp = true;
                }
            }


            //conectar.Open();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from software", conectar);
            da.Fill(ds, "software");
            conectar.Close();*/

        }

        private void campoNomeSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show(vloi);


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void campoUso_TextChanged(object sender, EventArgs e)
        {
            if (campoUso.Text == "Restrito")
            {
                campoMotivo.Enabled = true;
                campoMotivo.Text = "";
                //campoMotivo.Focus();
            }
            if (campoUso.Text == "Geral")
            {
                campoMotivo.Enabled = false;
                campoMotivo.Text = "NÃO HÁ";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CadastroNota cad = new CadastroNota();
            cad.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cadsoftware_Click_1(object sender, EventArgs e)
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
            //Instanciando Classe de Conexão    


            //Query de Inserção capturando os campos do formulário

            DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {//Gravando Informações no Banco

                    Connection cones = new Connection();
                    String query = "INSERT INTO software(soft_nome, soft_nomeExecutavel, soft_versao, soft_SO, soft_fabricante, soft_descricao, soft_uso, soft_categoria, soft_status, soft_motivo_restricao, soft_solicitante, soft_analista_ti, soft_responsavel_licenca, soft_normativo, soft_homolog_inc, soft_homolog_data, soft_data_atualizacao) VALUES('" + campoNomeSoftware.Text + "','" + campoNomeExec.Text + "','" + campoVersao.Text + "','" + campoSO.Text + "','" + campoFabricante.Text + "','" + campoDescricao.Text + "','" + campoUso.Text + "','" + campoCategoria.Text + "','" + campoStatus.Text + "','" + campoMotivo.Text + "','" + campoSolicitanteHomolog.Text + "','" + campoAnalistaTI.Text + "','" + campoResponsavelLic.Text + "','" + campoNormativo.Text + "','" + campoIncidente.Text + "','" + campoDataHomolog.Text + "','" + campoDataAtualizacao.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, cones.cone());
                    cmd.ExecuteNonQuery();
                    cones.cone().Close();
                    MessageBox.Show(null, "Cadastro efetuado com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                    ClearComboBoxes();
                    campoNomeSoftware.Focus();

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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            CadastroNota cad = new CadastroNota();
            cad.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void campoUso_TextChanged_1(object sender, EventArgs e)
        {
            if (campoUso.Text == "Restrito")
            {
                campoMotivo.Enabled = true;
                campoMotivo.Text = "";
                //campoMotivo.Focus();
            }
            if (campoUso.Text == "Geral")
            {
                campoMotivo.Enabled = false;
                campoMotivo.Text = "NÃO HÁ";
            }
        }

        private void campoNomeSoftware_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            SqlDataReader sdr1;
            SqlDataReader sdr2;

            int i = 0;
            SqlCommand cmd2 = new SqlCommand("select versao from lista_de_software where software ='" + campoNomeSoftware.Text + "'", conexao.cone());

            //comboempresa.Items.Add("Todos");

            //sdr2 = cmd3.ExecuteReader();
            sdr1 = cmd2.ExecuteReader();


            /*while (sdr2.Read() == true)
            {
                lista_user.Add(sdr2["soft_nome"].ToString() +" - "+ sdr2["soft_versao"].ToString());
                campoNomeSoftware.Items.Add(lista_user[i]);
                i++;
            }

            i = 0;*/
            campoVersao.Items.Clear();
            campoFabricante.Items.Clear();
            campoVersao.Text = "";
            campoFabricante.Text = "";
            while (sdr1.Read() == true)
            {
                lista_pass.Add(sdr1["versao"].ToString());

                //MessageBox.Show("Usuário: " + lista_user[i]);
                //MessageBox.Show(sdr["username"].ToString());
                campoVersao.Items.Add(lista_pass[i]);

                i++;
            }
        }

        private void campoVersao_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            SqlDataReader sdr1;
            SqlDataReader sdr2;

            int i = 0;
            SqlCommand cmd2 = new SqlCommand("select fabricante from lista_de_software where software ='" + campoNomeSoftware.Text + "' and versao ='" + campoVersao.Text + "'", conexao.cone());

            //comboempresa.Items.Add("Todos");

            //sdr2 = cmd3.ExecuteReader();
            sdr1 = cmd2.ExecuteReader();


            /*while (sdr2.Read() == true)
            {
                lista_user.Add(sdr2["soft_nome"].ToString() +" - "+ sdr2["soft_versao"].ToString());
                campoNomeSoftware.Items.Add(lista_user[i]);
                i++;
            }

            i = 0;*/

            campoFabricante.Text = "";
            while (sdr1.Read() == true)
            {

                campoFabricante.Items.Add(sdr1["fabricante"].ToString());
                i++;
            }
        }
    }
}
