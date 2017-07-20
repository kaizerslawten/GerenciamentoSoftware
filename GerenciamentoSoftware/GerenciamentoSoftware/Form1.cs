using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace GerenciamentoSoftware
{
    public partial class frmGerenciamento : Form
    {
        string perfil;
        string last_logon;
        string user;
        public frmGerenciamento()
        {
            InitializeComponent();
        }

        public frmGerenciamento(string valor, string valor1, string valor2)
        {
            InitializeComponent();
            user = valor2;
            perfil = valor;
            last_logon = valor1;


        }
        //Método que verifica se existe um formulário aberto e encerra
        private void FecharFormulariosFilhos()
        {
            // percorre todos os formulários abertos
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                // se o formulário for filho
                if (Application.OpenForms[i].IsMdiChild)
                {
                    Application.OpenForms[i].Close();
                }
            }
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SoftwaresCadastrados soff_cad = new SoftwaresCadastrados();
            soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void alterarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //NotasCadastradas tela_nota = new NotasCadastradas();
            //tela_nota.ShowDialog();
            NotasCadastradas soff_cad = new NotasCadastradas(perfil);
            soff_cad.TopLevel = false;
            soff_cad.AutoScroll = true;
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void nomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.ConsultaSoftwareNome tela_nome = new Consultas.ConsultaSoftwareNome();
            tela_nome.ShowDialog();
        }

        private void listaDeRestriçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.ConsultaSoftwareRestricao filho_consultasoftrestricao = new Consultas.ConsultaSoftwareRestricao();
            filho_consultasoftrestricao.ShowDialog();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.ConsultaSoftwareCategoria filho_consultasoftcat = new Consultas.ConsultaSoftwareCategoria();
            filho_consultasoftcat.ShowDialog();
        }

        private void numeroDaNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.ConsultaNotaNumero filho_consultanotanumero = new Consultas.ConsultaNotaNumero();
            filho_consultanotanumero.ShowDialog();

        }

        private void localidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult Resultado = MessageBox.Show("Deseja realizar uma nova consulta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (Resultado == DialogResult.Yes)
            //{
            Consultas.ConsultaNotaLocalidade filho_consultanotalocal = new Consultas.ConsultaNotaLocalidade();
            filho_consultanotalocal.ShowDialog();
            // }

        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Deseja realmente deslogar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            TelaLogin tela = new TelaLogin();
            if (Resultado == DialogResult.Yes)
            {
                this.Visible = false;
                tela.Refresh();
                tela.ShowDialog();


            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FornecedoresCadastrados soff_cad = new FornecedoresCadastrados();
            soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();

        }

        private void nomeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void frmGerenciamento_Load(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(panel3);
            panel3.Dock = DockStyle.Top;
            if (perfil == "ADM")
            {

                label2.Text = "ADMINISTRADOR";
                cadastrousers.Visible = true;
                configurarBancoToolStripMenuItem.Visible = false;

            }
            if (perfil == "CLIENT")
            {

                //configurarBancoToolStripMenuItem.Visible = false;
                pictureBox1.Enabled = false;
            }

            if (perfil == "USER")
            {

                //configurarBancoToolStripMenuItem.Visible = false;
                pictureBox1.Enabled = false;
            }

            label3.Text = last_logon;
            label5.Text = user;
            logado.Text = user;



        }

        string valida_sessao()
        {
            //Verificando a sessão
            Connection con1 = new Connection();
            string Str1 = "select count(*) as cont from login where status_logon =1 and USERNAME ='" + user + "'";
            SqlCommand cmd = new SqlCommand(Str1, con1.cone());
            SqlDataReader read_contagem;
            read_contagem = cmd.ExecuteReader();
            read_contagem.Read();

            return read_contagem["cont"].ToString();
        }

        private void cadastrousers_Click(object sender, EventArgs e)
        {
            UsuarioCadastrados cadastro = new UsuarioCadastrados();
            cadastro.ShowDialog();
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //progressBar1.Show();

            /*bgw = new BackgroundWorker();
            //bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);            
            bgw.RunWorkerAsync();*/
            Relatorios.consulta_equipamento cons = new Relatorios.consulta_equipamento();
            cons.ShowDialog();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void complianceLicençasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.consulta_equipamento cons = new Relatorios.consulta_equipamento();
            cons.ShowDialog();

        }

        private void configurarBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Directory.GetCurrentDirectory() + "\\config.exe");
        }

        private void softwarePorEquipamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.software_empresa tela = new Relatorios.software_empresa();
            tela.ShowDialog();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NotasCadastradas tela_nota = new NotasCadastradas();
            //tela_nota.ShowDialog();
            NotasCadastradas soff_cad = new NotasCadastradas(perfil);
            soff_cad.TopLevel = false;
            soff_cad.AutoScroll = true;
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoftwaresCadastrados soff_cad = new SoftwaresCadastrados();
            soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FornecedoresCadastrados soff_cad = new FornecedoresCadastrados();
            soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UsuarioCadastrados cadastro = new UsuarioCadastrados();
            cadastro.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(panel3);
            panel3.Dock = DockStyle.Top;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            LocalidadesCadastradas soff_cad = new LocalidadesCadastradas();
            soff_cad.ShowDialog();
            /*soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            NotasCadastradas soff_cad = new NotasCadastradas(perfil);
            soff_cad.TopLevel = false;
            soff_cad.AutoScroll = true;
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SoftwaresCadastrados soff_cad = new SoftwaresCadastrados(perfil);
            soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FornecedoresCadastrados soff_cad = new FornecedoresCadastrados(perfil);
            soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            LocalidadesCadastradas soff_cad = new LocalidadesCadastradas(perfil);
            soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UsuarioCadastrados soff_cad = new UsuarioCadastrados(user, perfil);
            soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Deseja realmente deslogar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            TelaLogin tela = new TelaLogin();
            if (Resultado == DialogResult.Yes)
            {
                this.Visible = false;
                tela.Refresh();
                tela.ShowDialog();
            }
        }

        private void frmGerenciamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection cones = new Connection();
            String query = "update login set status_logon = 0 where username = '" + user + "'";
            SqlCommand cmd = new SqlCommand(query, cones.cone());
            cmd.ExecuteNonQuery();
            cones.cone().Close();
            Application.Exit();
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();

            buttonToolTip.ToolTipTitle = "Ajuda";

            buttonToolTip.UseFading = true;

            buttonToolTip.UseAnimation = true;

            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;



            buttonToolTip.ShowAlways = false;
            buttonToolTip.AutomaticDelay = 500;

            buttonToolTip.AutoPopDelay = 5000;

            buttonToolTip.InitialDelay = 500;

            buttonToolTip.ReshowDelay = 100;



            buttonToolTip.SetToolTip(pictureBox7, "Cadastro de Notas Fiscais de Compra");
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();

            buttonToolTip.ToolTipTitle = "Ajuda";

            buttonToolTip.UseFading = true;

            buttonToolTip.UseAnimation = true;

            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;



            buttonToolTip.ShowAlways = false;


            buttonToolTip.AutomaticDelay = 500;
            buttonToolTip.AutoPopDelay = 5000;

            buttonToolTip.InitialDelay = 100;

            //buttonToolTip.ReshowDelay = 500;



            buttonToolTip.SetToolTip(pictureBox8, "Cadastro de Softwares");
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();

            buttonToolTip.ToolTipTitle = "Ajuda";

            buttonToolTip.UseFading = true;

            buttonToolTip.UseAnimation = true;

            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;



            buttonToolTip.ShowAlways = false;


            buttonToolTip.AutomaticDelay = 500;
            buttonToolTip.AutoPopDelay = 5000;

            buttonToolTip.InitialDelay = 100;

            //buttonToolTip.ReshowDelay = 500;



            buttonToolTip.SetToolTip(pictureBox6, "Cadastro de Notas de Fornecedores");
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();

            buttonToolTip.ToolTipTitle = "Ajuda";

            buttonToolTip.UseFading = true;

            buttonToolTip.UseAnimation = true;

            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;



            buttonToolTip.ShowAlways = false;


            buttonToolTip.AutomaticDelay = 500;
            buttonToolTip.AutoPopDelay = 5000;

            buttonToolTip.InitialDelay = 100;

            //buttonToolTip.ReshowDelay = 500;



            buttonToolTip.SetToolTip(pictureBox5, "Cadastro de Localidades");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();

            buttonToolTip.ToolTipTitle = "Ajuda";

            buttonToolTip.UseFading = true;

            buttonToolTip.UseAnimation = true;

            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;



            buttonToolTip.ShowAlways = false;


            buttonToolTip.AutomaticDelay = 500;
            buttonToolTip.AutoPopDelay = 5000;

            buttonToolTip.InitialDelay = 100;

            //buttonToolTip.ReshowDelay = 500;



            buttonToolTip.SetToolTip(pictureBox1, "Cadastro de Localidades");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            /*Relatorios.consulta_equipamento soff_cad = new Relatorios.consulta_equipamento();
            soff_cad.TopLevel = false;
            //soff_cad.AutoScroll = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(soff_cad);
            soff_cad.Dock = DockStyle.Top;
            soff_cad.Show();
             */

            String dec = File.ReadLines(Directory.GetCurrentDirectory() + "\\config.cfg").ElementAt(2);
            if (dec == "0")
            {
                MessageBox.Show(null, "Report Server não disponivel!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                System.Diagnostics.Process.Start("cmd", "/c start " + dec);
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();

            buttonToolTip.ToolTipTitle = "Ajuda";

            buttonToolTip.UseFading = true;

            buttonToolTip.UseAnimation = true;

            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;



            buttonToolTip.ShowAlways = false;


            buttonToolTip.AutomaticDelay = 500;
            buttonToolTip.AutoPopDelay = 5000;

            buttonToolTip.InitialDelay = 100;

            //buttonToolTip.ReshowDelay = 500;



            buttonToolTip.SetToolTip(pictureBox2, "Relatórios Gerenciais");
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();

            buttonToolTip.ToolTipTitle = "Ajuda";

            buttonToolTip.UseFading = true;

            buttonToolTip.UseAnimation = true;

            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;



            buttonToolTip.ShowAlways = false;


            buttonToolTip.AutomaticDelay = 500;
            buttonToolTip.AutoPopDelay = 5000;

            buttonToolTip.InitialDelay = 100;

            //buttonToolTip.ReshowDelay = 500;



            buttonToolTip.SetToolTip(pictureBox10, "Ajuda sobre a ferramenta GST");
        }

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();

            buttonToolTip.ToolTipTitle = "Ajuda";

            buttonToolTip.UseFading = true;

            buttonToolTip.UseAnimation = true;

            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;



            buttonToolTip.ShowAlways = false;


            buttonToolTip.AutomaticDelay = 500;
            buttonToolTip.AutoPopDelay = 5000;

            buttonToolTip.InitialDelay = 100;

            //buttonToolTip.ReshowDelay = 500;



            buttonToolTip.SetToolTip(pictureBox9, "Logoff");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(panel3);
            panel3.Dock = DockStyle.Top;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ajuda cad = new ajuda();
            cad.ShowDialog();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();

            buttonToolTip.ToolTipTitle = "Ajuda";

            buttonToolTip.UseFading = true;

            buttonToolTip.UseAnimation = true;

            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;



            buttonToolTip.ShowAlways = false;

            buttonToolTip.AutoPopDelay = 5000;

            buttonToolTip.InitialDelay = 500;

            buttonToolTip.ReshowDelay = 100;



            buttonToolTip.SetToolTip(pictureBox3, "Página Inicial");
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void frmGerenciamento_Activated(object sender, EventArgs e)
        {
            bool sessao;
            if (valida_sessao() != "1")
            {
                sessao = false;
                this.Visible = false;
                MessageBox.Show(null, "Sessão invalida!\n Por favor efetue um novo login!", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TelaLogin tela = new TelaLogin();
                tela.Refresh();
                tela.ShowDialog();
            }
        }

        private void frmGerenciamento_Shown(object sender, EventArgs e)
        {

        }

    }
}
