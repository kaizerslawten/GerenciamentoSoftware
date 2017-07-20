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
using System.IO;
using System.Diagnostics;

namespace GerenciamentoSoftware.update
{
    public partial class atualiza_nota : Form
    {
        string vloi;
        string operacao;



        public atualiza_nota(string valor, string valor2)
        {
            InitializeComponent();
            vloi = valor;
            operacao = valor2;
        }

        private void cbo_soft_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string anexo;
        private void comboempresa_SelectedValueChanged(object sender, EventArgs e)
        {
            combosite.Enabled = true;
            if (comboempresa.Text == "Todos")
            {
                //combosite.Items.Clear();
                combosite.Text = "Todos";
                combosite.Enabled = false;

            }
            Connection conexao = new Connection();
            int i = 0;
            SqlDataReader sdr2;
            //SqlCommand cmd2 = new SqlCommand("select l.nome_localidade from empresas e, localidades l where e.ID_empresa = l.PK_empresa and e.nome_empresa = '" + comboempresa.Text + "' ORDER BY l.nome_localidade", conexao.cone());
            SqlCommand cmd2 = new SqlCommand("select nome_site from cadastro_localidades where empresa ='" + comboempresa.Text + "' order by nome_site", conexao.cone());

            sdr2 = cmd2.ExecuteReader();
            combosite.Items.Clear();
            while (sdr2.Read() == true)
            {
                //combosite.Items.Add(sdr2["NOME_LOCALIDADE"].ToString());
                combosite.Items.Add(sdr2["nome_site"].ToString());
                i++;
            }
        }

        private void cbo_soft_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        // private string[] pdfFiles = GetFileNames("C:\\tsm\\NOTA", "*.pdf");
        private static string[] GetFileNames(string path, string filter)
        {
            string[] files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);
            return files;
        }
        string abrir_arquivo;
        int contagem_rows;
        string notad_id;
        private void atualiza_nota_Load(object sender, EventArgs e)
        {

            if (operacao == "USER")
            {
                pictureBox1.Enabled = false;
            }
            panel3.Visible = false;
            panel4.Visible = false;
            pictureBox17.Enabled = false;
            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            SqlDataReader sdr;
            SqlDataReader sdr1;
            SqlDataReader sdr2;
            int i = 0;
            SqlCommand cmd = new SqlCommand("select distinct soft_nome from software order by soft_nome;", conexao.cone());
            SqlCommand cmd1 = new SqlCommand("select distinct forn_nome from fornecedor order by forn_nome;", conexao.cone());
            //SqlCeCommand cmd2 = new SqlCeCommand("select l.nome_localidade from empresas e, localidades l where e.ID_empresa = l.PK_empresa and e.nome_empresa = '"+comboempresa.Text+"'", conexao.cone());
            SqlCommand cmd2 = new SqlCommand("select distinct empresa from cadastro_localidades ORDER BY empresa", conexao.cone());

            comboempresa.Items.Add("Todos");
            try
            {

                //if (conexao.cone().State == ConnectionState.Closed)
                //{


                //con.Close();
                sdr = cmd.ExecuteReader();
                sdr1 = cmd1.ExecuteReader();
                sdr2 = cmd2.ExecuteReader();

                while (sdr2.Read() == true)
                {
                    comboempresa.Items.Add(sdr2["EMPRESA"].ToString());
                    i++;
                }
                i = 0;

                while (sdr.Read() == true)
                {
                    lista_pass.Add(sdr["soft_nome"].ToString());
                    //MessageBox.Show("Usuário: " + lista_user[i]);
                    //MessageBox.Show(sdr["username"].ToString());
                    cbo_soft.Items.Add(lista_pass[i]);
                    i++;
                }
                i = 0;
                while (sdr1.Read() == true)
                {
                    lista_user.Add(sdr1["forn_nome"].ToString());
                    //MessageBox.Show("Usuário: " + lista_user[i]);
                    //MessageBox.Show(sdr["username"].ToString());
                    txtforn.Items.Add(lista_user[i]);
                    i++;
                }

                // }
                conexao.cone().Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString());
            }






            DataTable dt = new DataTable();
            //softwareBindingSource1.ResetBindings(true);
            Connection con = new Connection();
            string Str = "Select * from notas where notad_id = " + vloi;

            SqlCommand cmdp = new SqlCommand(Str, con.cone());
            SqlDataReader sdrp;
            SqlDataReader sdrv;
            SqlDataReader sdrpsoft;
            SqlDataReader sdrpforn;

            sdrp = cmdp.ExecuteReader();

            sdrp.Read();


            string Str1 = "Select soft_nome from software where soft_id = " + sdrp["fk_soft_id"].ToString();
            string Str2 = "Select forn_nome from fornecedor where cnpj = '" + sdrp["fk_cnpj"].ToString() + "'";
            SqlCommand cmdpsoft = new SqlCommand(Str1, con.cone());
            SqlCommand cmdpforn = new SqlCommand(Str2, con.cone());
            sdrpsoft = cmdpsoft.ExecuteReader();
            sdrpsoft.Read();
            sdrpforn = cmdpforn.ExecuteReader();
            sdrpforn.Read();

            cbo_soft.Text = sdrpsoft["soft_nome"].ToString();
            txtPO.Text = sdrp["nota_numero"].ToString();
            txtqtd.Text = sdrp["nota_quantidade"].ToString();
            dateTimePicker1.Text = sdrp["nota_data_compra"].ToString();

            /*if (sdrp["nota_validade"].ToString() == "")
            {
                dateTimePicker2.CustomFormat = " ";
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                
            }*/
            dateTimePicker2.Text = sdrp["nota_validade"].ToString();

            NF.Text = sdrp["nota_nf"].ToString();
            comboempresa.Text = sdrp["nota_empresa"].ToString();
            combosite.Text = sdrp["nota_site"].ToString();
            txtDesc.Text = sdrp["nota_desc"].ToString();
            cbotiplic.Text = sdrp["nota_tipo_lic"].ToString();
            cboup.Text = sdrp["nota_upgrade_versao"].ToString();
            txtforn.Text = sdrpforn["forn_nome"].ToString();
            txtresp.Text = sdrp["nota_resp_compra"].ToString();
            txtanalista.Text = sdrp["nota_analista"].ToString();
            txtgerente.Text = sdrp["nota_gerencia_compra"].ToString();
            cod_pro.Text = sdrp["cod_produto"].ToString();
            cst.Text = sdrp["cst"].ToString();
            qtd.Text = sdrp["quantidade"].ToString();
            valor_total.Text = sdrp["valor_total"].ToString();
            valor_icms.Text = sdrp["valor_icms"].ToString();
            ncm.Text = sdrp["ncm_sh"].ToString();
            ali_icms.Text = sdrp["aliquota_icms"].ToString();
            cfop.Text = sdrp["cfop"].ToString();
            unidade.Text = sdrp["unidade"].ToString();
            valor_unitario.Text = sdrp["valor_unitario"].ToString();
            base_icms.Text = sdrp["base_icms"].ToString();
            valor_ipi.Text = sdrp["valor_ipi"].ToString();
            ali_ipi.Text = sdrp["aliquota_ipi"].ToString();
            categoria_lic.Text = sdrp["categoria_lic"].ToString();
            notad_id = sdrp["notad_id"].ToString();


            if (sdrp["arquivo"].ToString() != "")
            {
                dataGridView1.Rows.Add(sdrp["arquivo"].ToString());
                contagem_rows = 1;

            }
            else
            {
                contagem_rows = 2;
            }
            abrir_arquivo = sdrp["arquivo"].ToString();


            Connection conexao1 = new Connection();
            int io = 0;
            SqlDataReader sdr2x;
            //SqlCommand cmd2 = new SqlCommand("select l.nome_localidade from empresas e, localidades l where e.ID_empresa = l.PK_empresa and e.nome_empresa = '" + comboempresa.Text + "' ORDER BY l.nome_localidade", conexao.cone());
            SqlCommand cmd2x = new SqlCommand("select soft_versao from software where soft_id = " + sdrp["fk_soft_id"].ToString(), conexao1.cone());
            //SqlCommand cmd2x = new SqlCommand("select soft_versao from oftware where soft_nome ='" + cbo_soft.Text + "'", conexao1.cone());

            sdr2x = cmd2x.ExecuteReader();
            sdr2x.Read();
            cbo_versao.Text = sdr2x["soft_versao"].ToString();
        }

        private void btn_cadnota_Click(object sender, EventArgs e)
        {

            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_userpk = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            ArrayList lista_pk = new ArrayList();
            SqlDataReader sdr;
            SqlDataReader sdr1;
            int i = 0;
            SqlCommand cmd2 = new SqlCommand("select * from fornecedor;", conexao.cone());
            SqlCommand cmd1 = new SqlCommand("select * from software;", conexao.cone());
            sdr = cmd1.ExecuteReader();
            sdr1 = cmd2.ExecuteReader();

            while (sdr.Read() == true)
            {
                lista_pass.Add(sdr["soft_nome"].ToString());
                lista_pk.Add(sdr["soft_id"].ToString());
                i++;
            }
            i = 0;
            while (sdr1.Read() == true)
            {
                lista_user.Add(sdr1["forn_nome"].ToString());
                lista_userpk.Add(sdr1["cnpj"].ToString());
                i++;
            }
            conexao.cone().Close();

            DialogResult Resultado = MessageBox.Show("Confirma as atualizações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {

                try
                {
                    //Gravando Informações no Banco

                    Connection cones = new Connection();
                    SqlDataReader sdrp;
                    SqlDataReader sdr1p;
                    SqlCommand cmd1p = new SqlCommand("select cnpj from fornecedor where forn_nome = '" + txtforn.Text + "';", cones.cone());
                    SqlCommand cmd2p = new SqlCommand("select soft_id from software where soft_nome = '" + cbo_soft.Text + "';", cones.cone());
                    sdrp = cmd1p.ExecuteReader();
                    sdrp.Read();
                    var valorcnpj = sdrp["cnpj"].ToString();
                    sdr1p = cmd2p.ExecuteReader();
                    sdr1p.Read();
                    var valorsoft_id = sdr1p["soft_id"].ToString();
                    cones.cone().Close();

                    String query = "update notas set nota_numero='" + txtPO.Text + "',nota_quantidade='" + txtqtd.Text + "',nota_data_compra='" + dateTimePicker1.Text + "',nota_desc='" + txtDesc.Text + "',nota_tipo_lic='" + cbotiplic.Text + "',nota_upgrade_versao='" + cboup.Text + "',nota_resp_compra='" + txtresp.Text + "',nota_analista='" + txtanalista.Text + "',nota_empresa='" + comboempresa.Text + "',nota_site='" + combosite.Text + "',nota_gerencia_compra='" + txtgerente.Text + "',fk_soft_id='" + fk_soft_id + "',fk_cnpj='" + valorcnpj + "',nota_nf ='" + NF.Text + "',nota_validade ='" + dateTimePicker2.Text + "',cod_produto ='" + cod_pro.Text + "',cst ='" + cst.Text + "',quantidade ='" + qtd.Text + "',valor_total ='" + valor_total.Text + "',valor_icms ='" + valor_icms.Text + "',ncm_icms ='" + ncm.Text + "',aliquota_icms ='" + ali_icms.Text + "',cfop ='" + cfop.Text + "',unidade ='" + unidade.Text + "',valor_unitario ='" + valor_unitario.Text + "',base_icms ='" + base_icms.Text + "',valor_ipi ='" + valor_ipi.Text + "',aliquota_ipi ='" + ali_ipi.Text + "' where notad_id = " + vloi;
                    SqlCommand cmd = new SqlCommand(query, cones.cone()); //lista_pk[cbo_soft.SelectedIndex]
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

        private void btn_cancelcadnota_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados inseridos serão perdidos, deseja cancelar o cadastro?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            relaciona_notas rel = new relaciona_notas(NF.Text);
            rel.ShowDialog();
        }

        private void rectangleShape5_Click(object sender, EventArgs e)
        {

        }
        string fk_soft_id;
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            relaciona_notas rel = new relaciona_notas(notad_id);
            rel.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();
            int val1 = rnd.Next(1000, 9999);

            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_userpk = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            ArrayList lista_pk = new ArrayList();
            SqlDataReader sdr;
            SqlDataReader sdr1;
            int i = 0;
            SqlCommand cmd2 = new SqlCommand("select * from fornecedor;", conexao.cone());
            SqlCommand cmd1 = new SqlCommand("select * from software;", conexao.cone());
            sdr = cmd1.ExecuteReader();
            sdr1 = cmd2.ExecuteReader();

            while (sdr.Read() == true)
            {
                lista_pass.Add(sdr["soft_nome"].ToString());
                lista_pk.Add(sdr["soft_id"].ToString());
                i++;
            }
            i = 0;
            while (sdr1.Read() == true)
            {
                lista_user.Add(sdr1["forn_nome"].ToString());
                lista_userpk.Add(sdr1["cnpj"].ToString());
                i++;
            }
            conexao.cone().Close();

            DialogResult Resultado = MessageBox.Show("Confirma as atualizações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {

                try
                {
                    //Gravando Informações no Banco

                    Connection cones = new Connection();
                    SqlDataReader sdrp;
                    SqlDataReader sdr1p;
                    SqlCommand cmd1p = new SqlCommand("select cnpj from fornecedor where forn_nome = '" + txtforn.Text + "';", cones.cone());
                    SqlCommand cmd2p = new SqlCommand("select soft_id from software where soft_nome = '" + cbo_soft.Text + "';", cones.cone());
                    sdrp = cmd1p.ExecuteReader();
                    sdrp.Read();
                    var valorcnpj = sdrp["cnpj"].ToString();
                    sdr1p = cmd2p.ExecuteReader();
                    sdr1p.Read();
                    var valorsoft_id = sdr1p["soft_id"].ToString();
                    cones.cone().Close();

                    //Coletando o ID do software baseado na seleção de nome e versão
                    Connection conexao1 = new Connection();
                    SqlDataReader sdrx;
                    //SqlCommand cmd2 = new SqlCommand("select l.nome_localidade from empresas e, localidades l where e.ID_empresa = l.PK_empresa and e.nome_empresa = '" + comboempresa.Text + "' ORDER BY l.nome_localidade", conexao.cone());
                    SqlCommand cmda2 = new SqlCommand("select soft_id from software where soft_nome ='" + cbo_soft.Text + "' and soft_versao = '" + cbo_versao.Text + "'", conexao1.cone());
                    sdrx = cmda2.ExecuteReader();
                    sdrx.Read();
                    fk_soft_id = sdrx["soft_id"].ToString();
                    conexao1.cone().Close();
                    ////

                    string campo_arquivo = "";
                    String dec = File.ReadLines(Directory.GetCurrentDirectory() + "\\config.cfg").ElementAt(1);


                    String query2 = "update notas set nota_numero='" + txtPO.Text + "',nota_quantidade='" + txtqtd.Text + "',nota_data_compra='" + dateTimePicker1.Text + "',nota_desc='" + txtDesc.Text + "',nota_tipo_lic='" + cbotiplic.Text + "',nota_upgrade_versao='" + cboup.Text + "',nota_resp_compra='" + txtresp.Text + "',nota_analista='" + txtanalista.Text + "',nota_empresa='" + comboempresa.Text + "',nota_site='" + combosite.Text + "',nota_gerencia_compra='" + txtgerente.Text + "',fk_soft_id='" + fk_soft_id + "',fk_cnpj='" + valorcnpj + "',nota_nf ='" + NF.Text + "',nota_validade ='" + dateTimePicker2.Text + "',cod_produto ='" + cod_pro.Text + "',cst ='" + cst.Text + "',quantidade ='" + qtd.Text + "',valor_total ='" + valor_total.Text + "',valor_icms ='" + valor_icms.Text + "',ncm_sh ='" + ncm.Text + "',aliquota_icms ='" + ali_icms.Text + "',cfop ='" + cfop.Text + "',unidade ='" + unidade.Text + "',valor_unitario ='" + valor_unitario.Text + "',base_icms ='" + base_icms.Text + "',valor_ipi ='" + valor_ipi.Text + "',aliquota_ipi ='" + ali_ipi.Text + "',categoria_lic ='" + categoria_lic.Text + "'" + " where notad_id = " + vloi;
                    if (contagem_rows == 1)
                    {
                        SqlCommand cmd = new SqlCommand(query2, cones.cone());
                        cmd.ExecuteNonQuery();
                    }

                    if (contagem_rows == 0)
                    {

                        string extension;
                        extension = Path.GetExtension(arquivo_anexo);
                        System.IO.StreamReader file = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "\\config.cfg");
                        //byte[] b = (Convert.FromBase64String(File.ReadLines(sv.FileName).ElementAt(1).ToString()));

                        try
                        {
                            campo_arquivo = dec + "\\NOTA\\NOTA-" + NF.Text + "-" + val1 + extension;
                            File.Copy(arquivo_anexo, campo_arquivo, true);
                            MessageBox.Show(null, "Arquivo e nota salvos com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.Rows.Clear();

                        }

                        catch (System.IO.DirectoryNotFoundException ex)
                        {
                            MessageBox.Show(null, "Compartilhamento não está disponivel!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        String query = "update notas set nota_numero='" + txtPO.Text + "',nota_quantidade='" + txtqtd.Text + "',nota_data_compra='" + dateTimePicker1.Text + "',nota_desc='" + txtDesc.Text + "',nota_tipo_lic='" + cbotiplic.Text + "',nota_upgrade_versao='" + cboup.Text + "',nota_resp_compra='" + txtresp.Text + "',nota_analista='" + txtanalista.Text + "',nota_empresa='" + comboempresa.Text + "',nota_site='" + combosite.Text + "',nota_gerencia_compra='" + txtgerente.Text + "',fk_soft_id='" + fk_soft_id + "',fk_cnpj='" + valorcnpj + "',nota_nf ='" + NF.Text + "',nota_validade ='" + dateTimePicker2.Text + "',cod_produto ='" + cod_pro.Text + "',cst ='" + cst.Text + "',quantidade ='" + qtd.Text + "',valor_total ='" + valor_total.Text + "',valor_icms ='" + valor_icms.Text + "',ncm_sh ='" + ncm.Text + "',aliquota_icms ='" + ali_icms.Text + "',cfop ='" + cfop.Text + "',unidade ='" + unidade.Text + "',valor_unitario ='" + valor_unitario.Text + "',base_icms ='" + base_icms.Text + "',valor_ipi ='" + valor_ipi.Text + "',aliquota_ipi ='" + ali_ipi.Text + "',categoria_lic ='" + categoria_lic.Text + "',arquivo = '" + campo_arquivo + "' where notad_id = " + vloi;
                        SqlCommand cmd = new SqlCommand(query, cones.cone());
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand(query2, cones.cone());
                        cmd.ExecuteNonQuery();
                    }


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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados inseridos serão perdidos, deseja cancelar o cadastro?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_userpk = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            ArrayList lista_pk = new ArrayList();
            SqlDataReader sdr;
            SqlDataReader sdr1;
            int i = 0;
            SqlCommand cmd2 = new SqlCommand("select * from fornecedor;", conexao.cone());
            SqlCommand cmd1 = new SqlCommand("select * from software;", conexao.cone());
            sdr = cmd1.ExecuteReader();
            sdr1 = cmd2.ExecuteReader();

            while (sdr.Read() == true)
            {
                lista_pass.Add(sdr["soft_nome"].ToString());
                lista_pk.Add(sdr["soft_id"].ToString());
                i++;
            }
            i = 0;
            while (sdr1.Read() == true)
            {
                lista_user.Add(sdr1["forn_nome"].ToString());
                lista_userpk.Add(sdr1["cnpj"].ToString());
                i++;
            }
            conexao.cone().Close();

            DialogResult Resultado = MessageBox.Show("Confirma as atualizações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {

                try
                {
                    //Gravando Informações no Banco

                    Connection cones = new Connection();
                    SqlDataReader sdrp;
                    SqlDataReader sdr1p;
                    SqlCommand cmd1p = new SqlCommand("select cnpj from fornecedor where forn_nome = '" + txtforn.Text + "';", cones.cone());
                    SqlCommand cmd2p = new SqlCommand("select soft_id from software where soft_nome = '" + cbo_soft.Text + "';", cones.cone());
                    sdrp = cmd1p.ExecuteReader();
                    sdrp.Read();
                    var valorcnpj = sdrp["cnpj"].ToString();
                    sdr1p = cmd2p.ExecuteReader();
                    sdr1p.Read();
                    var valorsoft_id = sdr1p["soft_id"].ToString();
                    cones.cone().Close();

                    String query = "update notas set nota_numero='" + txtPO.Text + "',nota_quantidade='" + txtqtd.Text + "',nota_data_compra='" + dateTimePicker1.Text + "',nota_desc='" + txtDesc.Text + "',nota_tipo_lic='" + cbotiplic.Text + "',nota_upgrade_versao='" + cboup.Text + "',nota_resp_compra='" + txtresp.Text + "',nota_analista='" + txtanalista.Text + "',nota_empresa='" + comboempresa.Text + "',nota_site='" + combosite.Text + "',nota_gerencia_compra='" + txtgerente.Text + "',fk_soft_id='" + fk_soft_id + "',fk_cnpj='" + valorcnpj + "',nota_nf ='" + NF.Text + "',nota_validade ='" + dateTimePicker2.Text + "',cod_produto ='" + cod_pro.Text + "',cst ='" + cst.Text + "',quantidade ='" + qtd.Text + "',valor_total ='" + valor_total.Text + "',valor_icms ='" + valor_icms.Text + "',ncm_sh ='" + ncm.Text + "',aliquota_icms ='" + ali_icms.Text + "',cfop ='" + cfop.Text + "',unidade ='" + unidade.Text + "',valor_unitario ='" + valor_unitario.Text + "',base_icms ='" + base_icms.Text + "',valor_ipi ='" + valor_ipi.Text + "',aliquota_ipi ='" + ali_ipi.Text + "' where notad_id = " + vloi;
                    SqlCommand cmd = new SqlCommand(query, cones.cone()); //lista_pk[cbo_soft.SelectedIndex]
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

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboup_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cboup.Text)
            {
                case "NAO":
                    pictureBox17.Enabled = false;
                    break;
                case "NÃO":
                    pictureBox17.Enabled = false;
                    break;
                case "SIM":
                    pictureBox17.Enabled = true;
                    break;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            /*Random rnd = new Random();
            int val1 = rnd.Next(1000, 9999);
            OpenFileDialog sv = new OpenFileDialog();

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string extension, path1;
                extension = Path.GetExtension(sv.FileName);
                path1 = Path.GetFullPath(sv.FileName);
                System.IO.StreamReader file = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "\\config.cfg");
                //byte[] b = (Convert.FromBase64String(File.ReadLines(sv.FileName).ElementAt(1).ToString()));

                String dec = File.ReadLines(Directory.GetCurrentDirectory() + "\\config.cfg").ElementAt(1);
                //MessageBox.Show(dec);
                //File.Move(sv.FileName, path1+"\\"+NF.Text +"."+ extension);
                File.Copy(sv.FileName, dec + "\\NOTA\\NOTA-"+val1.ToString()+"-" + NF.Text + extension);
                MessageBox.Show(null, "Anexo Salvo com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //file = Right(arr(i), Len(arr(i)) - InStrRev(arr(i), "\"))
            }
            */

            /*
            OpenFileDialog sv = new OpenFileDialog();

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string extension;
                extension = Path.GetExtension(sv.FileName);                
                System.IO.StreamReader file = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "\\config.cfg");
                //byte[] b = (Convert.FromBase64String(File.ReadLines(sv.FileName).ElementAt(1).ToString()));
                String dec = File.ReadLines(Directory.GetCurrentDirectory() + "\\config.cfg").ElementAt(1);
                MessageBox.Show(dec);
                //File.Move(sv.FileName, path1+"\\"+NF.Text +"."+ extension);
                //File.Copy(sv.FileName, dec + "\\NOTA\\NOTA-" + NF.Text + extension);
                //file = Right(arr(i), Len(arr(i)) - InStrRev(arr(i), "\"))

                try
                {
                    File.Copy(sv.FileName, dec + "\\NOTA\\NOTA-" + NF.Text + extension);
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    MessageBox.Show(null, "Compartilhamento não está disponivel!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }*/
            //panel4.Visible = true;
        }

        private void cbo_soft_SelectedValueChanged_1(object sender, EventArgs e)
        {
            Connection conexao = new Connection();
            int i = 0;
            SqlDataReader sdr2;
            //SqlCommand cmd2 = new SqlCommand("select l.nome_localidade from empresas e, localidades l where e.ID_empresa = l.PK_empresa and e.nome_empresa = '" + comboempresa.Text + "' ORDER BY l.nome_localidade", conexao.cone());
            //SqlCommand cmd2 = new SqlCommand("select soft_id from software where soft_nome ='"+cbo_soft.Text+"' and soft_versao = '"+cbo_versao.Text+"'", conexao.cone());
            SqlCommand cmd2 = new SqlCommand("select soft_versao from software where soft_nome ='" + cbo_soft.Text + "'", conexao.cone());

            sdr2 = cmd2.ExecuteReader();
            cbo_versao.Items.Clear();
            while (sdr2.Read() == true)
            {
                //combosite.Items.Add(sdr2["NOME_LOCALIDADE"].ToString());
                cbo_versao.Items.Add(sdr2["soft_versao"].ToString());
                i++;
            }
        }

        private void pictureBox14_Click_2(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void valor_unitario_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //formata com o ponto de milhar
                valor_unitario.Text = string.Format("{0,0:#,##0}", int.Parse(valor_unitario.Text));

                //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
                //por isso na proxima linha conto quantos caractes tem no textbox
                int cont = valor_unitario.TextLength;

                //Aqui eu coloco o cursor sempre depois do ultimo caractere
                valor_unitario.SelectionStart = cont;
                valor_unitario.SelectionLength = 0;
            }
            catch (Exception)
            {
            }
        }

        private void valor_icms_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //formata com o ponto de milhar
                valor_icms.Text = string.Format("{0,0:#,##0}", int.Parse(valor_icms.Text));

                //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
                //por isso na proxima linha conto quantos caractes tem no textbox
                int cont = valor_icms.TextLength;

                //Aqui eu coloco o cursor sempre depois do ultimo caractere
                valor_icms.SelectionStart = cont;
                valor_icms.SelectionLength = 0;
            }
            catch (Exception)
            {
            }
        }

        private void valor_total_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void valor_ipi_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //formata com o ponto de milhar
                valor_ipi.Text = string.Format("{0,0:#,##0}", int.Parse(valor_ipi.Text));

                //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
                //por isso na proxima linha conto quantos caractes tem no textbox
                int cont = valor_ipi.TextLength;

                //Aqui eu coloco o cursor sempre depois do ultimo caractere
                valor_ipi.SelectionStart = cont;
                valor_ipi.SelectionLength = 0;
            }
            catch (Exception)
            {
            }
        }

        private void valor_unitario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (valor_unitario.Text == "")
                {
                }
                else
                {
                    double s = Convert.ToInt32(double.Parse(qtd.Text));
                    double vs = Convert.ToInt32(double.Parse(valor_unitario.Text));
                    double t = s * vs;
                    valor_total.Text = Convert.ToInt32(t).ToString();
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(null, "Verifique os valores!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void valor_total_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //formata com o ponto de milhar
                valor_total.Text = string.Format("{0,0:#,##0}", int.Parse(valor_total.Text));

                //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
                //por isso na proxima linha conto quantos caractes tem no textbox
                int cont = valor_total.TextLength;

                //Aqui eu coloco o cursor sempre depois do ultimo caractere
                valor_total.SelectionStart = cont;
                valor_total.SelectionLength = 0;
            }
            catch (Exception)
            {
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            OpenFileDialog sv = new OpenFileDialog();

            if (sv.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Add(sv.FileName);
                //notas.Add(cbo_nota.Text);
                contagem_rows = 0;

            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            int indi = 0;
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                //MessageBox.Show(notas[item.Index].ToString());
                dataGridView1.Rows.RemoveAt(item.Index);
                //notas.RemoveAt(item.Index + 1);
                contagem_rows = 1;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }
        string arquivo_anexo = "";
        private void pictureBox5_Click(object sender, EventArgs e)
        {

            OpenFileDialog sv = new OpenFileDialog();

            if (sv.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Add(sv.FileName);
                arquivo_anexo = sv.FileName;
                contagem_rows = 0;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int indi = 0;
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {

                //dataGridView1.SelectedRows[item.Index].ToString();
                //dataGridView1.Rows.RemoveAt(item.Index);

                //MessageBox.Show(dataGridView1.SelectedRows[item.Index].Cells[0].Value.ToString());
                //notas.RemoveAt(item.Index + 1);
                DialogResult Resultado = MessageBox.Show("Realmente deseja remover o Anexo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                dataGridView1.Rows.RemoveAt(item.Index);
                contagem_rows = 1;
                Connection cones = new Connection();
                SqlCommand cmd1p = new SqlCommand("update notas set arquivo='' where notad_id=" + vloi, cones.cone());
                if (Resultado == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(dataGridView1.SelectedRows[item.Index].Cells[0].Value.ToString());
                       
                        cmd1p.ExecuteNonQuery();
                        //arquivo_anexo = "";
                        MessageBox.Show(null, "Anexo Removido com sucesso", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Arquivo anexo inexistente!");
                        cmd1p.ExecuteNonQuery();
                    }
                    
                }

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (abrir_arquivo != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(abrir_arquivo);
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show(null, "Arquivo inexistente \n Por Favor clique em remover e depois em atualizar para salvar a alteração.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
