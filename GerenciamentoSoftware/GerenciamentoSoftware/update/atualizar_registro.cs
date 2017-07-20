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
    public partial class atualizar_registro : Form
    {
        static string vloi;

        public atualizar_registro()
        {
            InitializeComponent();
        }
        string operacao;
        public atualizar_registro(string valor, string valor2)
        {
            InitializeComponent();
            vloi = valor;
            operacao = valor2;
        }

        private void atualizar_registro_Load(object sender, EventArgs e)
        {
            if (operacao == "CLIENT")
            {
                pictureBox7.Enabled = false;
            }
            DataTable dt = new DataTable();
            //softwareBindingSource1.ResetBindings(true);
            Connection con = new Connection();
            string Str = "Select * from software where soft_id = " + vloi;
            SqlCommand cmd = new SqlCommand(Str, con.cone());
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            campoNomeSoftware.Text = sdr["soft_nome"].ToString();
            campoNomeExec.Text = sdr["soft_nomeExecutavel"].ToString();
            campoVersao.Text = sdr["soft_versao"].ToString();
            campoSO.Text = sdr["soft_SO"].ToString();
            campoFabricante.Text = sdr["soft_fabricante"].ToString();
            campoDescricao.Text = sdr["soft_descricao"].ToString();
            campoUso.Text = sdr["soft_uso"].ToString();
            campoCategoria.Text = sdr["soft_categoria"].ToString();
            campoStatus.Text = sdr["soft_status"].ToString();
            campoMotivo.Text = sdr["soft_motivo_restricao"].ToString();
            campoSolicitanteHomolog.Text = sdr["soft_solicitante"].ToString();
            campoAnalistaTI.Text = sdr["soft_analista_ti"].ToString();
            campoResponsavelLic.Text = sdr["soft_responsavel_licenca"].ToString();
            campoNormativo.Text = sdr["soft_normativo"].ToString();
            campoIncidente.Text = sdr["soft_homolog_inc"].ToString();
            campoDataHomolog.Text = sdr["soft_homolog_data"].ToString();
            campoDataAtualizacao.Text = sdr["soft_data_atualizacao"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(vloi);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(vloi);
        }

        private void btn_cadsoftware_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Confirma as atualizações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {//Gravando Informações no Banco

                    Connection cones = new Connection();
                    String query = "update software set soft_nome='" + campoNomeSoftware.Text + "', soft_nomeExecutavel='" + campoNomeExec.Text + "',soft_versao='" + campoVersao.Text + "',soft_SO='" + campoSO.Text + "',soft_fabricante='" + campoFabricante.Text + "',soft_descricao='" + campoDescricao.Text + "',soft_uso='" + campoUso.Text + "',soft_categoria='" + campoCategoria.Text + "',soft_status='" + campoStatus.Text + "',soft_motivo_restricao='" + campoMotivo.Text + "',soft_solicitante='" + campoSolicitanteHomolog.Text + "',soft_analista_ti='" + campoAnalistaTI.Text + "',soft_responsavel_licenca='" + campoResponsavelLic.Text + "',soft_normativo='" + campoNormativo.Text + "',soft_homolog_inc='" + campoIncidente.Text + "',soft_homolog_data='" + campoDataHomolog.Text + "',soft_data_atualizacao='" + campoDataAtualizacao.Text + "' where soft_id = " + vloi;
                    SqlCommand cmd = new SqlCommand(query, cones.cone());

                    cmd.ExecuteNonQuery();
                    cones.cone().Close();
                    MessageBox.Show(null, "Cadastro atualizado com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_cancelcadsoftware_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados atualizados não serão salvos, deseja cancelar a atualização?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void campoUso_SelectedIndexChanged(object sender, EventArgs e)
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Confirma as atualizações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {//Gravando Informações no Banco

                    Connection cones = new Connection();
                    String query = "update software set soft_nome='" + campoNomeSoftware.Text + "', soft_nomeExecutavel='" + campoNomeExec.Text + "',soft_versao='" + campoVersao.Text + "',soft_SO='" + campoSO.Text + "',soft_fabricante='" + campoFabricante.Text + "',soft_descricao='" + campoDescricao.Text + "',soft_uso='" + campoUso.Text + "',soft_categoria='" + campoCategoria.Text + "',soft_status='" + campoStatus.Text + "',soft_motivo_restricao='" + campoMotivo.Text + "',soft_solicitante='" + campoSolicitanteHomolog.Text + "',soft_analista_ti='" + campoAnalistaTI.Text + "',soft_responsavel_licenca='" + campoResponsavelLic.Text + "',soft_normativo='" + campoNormativo.Text + "',soft_homolog_inc='" + campoIncidente.Text + "',soft_homolog_data='" + campoDataHomolog.Text + "',soft_data_atualizacao='" + campoDataAtualizacao.Text + "' where soft_id = " + vloi;
                    SqlCommand cmd = new SqlCommand(query, cones.cone());

                    cmd.ExecuteNonQuery();
                    cones.cone().Close();
                    MessageBox.Show(null, "Cadastro atualizado com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados atualizados não serão salvos, deseja cancelar a atualização?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

