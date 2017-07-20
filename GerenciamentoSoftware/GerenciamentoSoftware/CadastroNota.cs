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
using System.IO;
using System.Collections;

namespace GerenciamentoSoftware
{
    public partial class CadastroNota : Form
    {
        public CadastroNota()
        {
            InitializeComponent();
        }
        string fk_soft_id;
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

            DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    //Gravando Informações no Banco
                    string coleta_data = "";
                    Connection cones = new Connection();
                    if (dateTimePicker2.Text == " ")
                    {
                        coleta_data = "NULL";
                    }
                    else
                    {
                        coleta_data = dateTimePicker2.Text;
                    }
                    String query = "INSERT INTO notas(nota_numero,nota_quantidade,nota_data_compra,nota_desc,nota_tipo_lic,nota_upgrade_versao,nota_resp_compra,nota_analista,nota_empresa,nota_site,nota_gerencia_compra,fk_soft_id,fk_cnpj,nota_nf,nota_validade) select '" + txtPO.Text + "','" + txtqtd.Text + "','" + dateTimePicker1.Text + "','" + txtDesc.Text + "','" + cbotiplic.Text + "','" + cboup.Text + "','" + txtresp.Text + "','" + txtanalista.Text + "','" + comboempresa.Text + "','" + combosite.Text + "','" + txtgerente.Text + "',s.soft_id,f.cnpj,'" + NF.Text + "','" + coleta_data + "' from software s, fornecedor f where s.soft_id = " + lista_pk[lista_pass.IndexOf(cbo_soft.Text)] + " and f.cnpj = '" + lista_userpk[lista_user.IndexOf(txtforn.Text)] + "'";
                    SqlCommand cmd = new SqlCommand(query, cones.cone()); //lista_pk[cbo_soft.SelectedIndex]
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

        private void btn_cancelcadnota_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Os dados inseridos serão perdidos, deseja cancelar o cadastro?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        string arquivo_anexo;
        string operacao;
        public CadastroNota(string valor)
        {
            InitializeComponent();
            operacao = valor;
        }

        private void CadastroNota_Load(object sender, EventArgs e)
        {
            if (operacao == "USER")
            {
                pictureBox2.Enabled = false;
            }
            panel3.Visible = false;
            panel4.Visible = false;
            pictureBox17.Enabled = false;
            //dateTimePicker2.CustomFormat = " ";
            //dateTimePicker2.Format = DateTimePickerFormat.Custom;
            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            SqlDataReader sdr;
            SqlDataReader sdr1;
            SqlDataReader sdr2;

            int i = 0;
            SqlCommand cmd = new SqlCommand("select distinct soft_nome from software where soft_categoria = 'Comercial' order by soft_nome;", conexao.cone());
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
                MessageBox.Show(null, "Existem campos em branco favor verificar!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cbo_soft_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboempresa_SelectedValueChanged(object sender, EventArgs e)
        {


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        }

        private void cboup_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboup.Text == "SIM")
            {
                relaciona_notas tela = new relaciona_notas(NF.Text);
                tela.ShowDialog();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape6_Click(object sender, EventArgs e)
        {

        }

        private void cboup_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cboup.SelectedItem.Equals("SIM"))
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void rectangleShape7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
            SqlCommand cmd1 = new SqlCommand("select distinct* from software;", conexao.cone());
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

            DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    //Gravando Informações no Banco
                    string coleta_data = "";
                    Connection cones = new Connection();
                    if (dateTimePicker2.Text == " ")
                    {
                        coleta_data = "NULL";
                    }
                    else
                    {
                        coleta_data = dateTimePicker2.Text;
                    }
                    String query = "INSERT INTO notas(nota_numero,nota_quantidade,nota_data_compra,nota_desc,nota_tipo_lic,nota_upgrade_versao,nota_resp_compra,nota_analista,nota_empresa,nota_site,nota_gerencia_compra,fk_soft_id,fk_cnpj,nota_nf,nota_validade) select '" + txtPO.Text + "','" + txtqtd.Text + "','" + dateTimePicker1.Text + "','" + txtDesc.Text + "','" + cbotiplic.Text + "','" + cboup.Text + "','" + txtresp.Text + "','" + txtanalista.Text + "','" + comboempresa.Text + "','" + combosite.Text + "','" + txtgerente.Text + "',s.soft_id,f.cnpj,'" + NF.Text + "','" + coleta_data + "' from software s, fornecedor f where s.soft_id = " + lista_pk[lista_pass.IndexOf(cbo_soft.Text)] + " and f.cnpj = '" + lista_userpk[lista_user.IndexOf(txtforn.Text)] + "'";
                    SqlCommand cmd = new SqlCommand(query, cones.cone()); //lista_pk[cbo_soft.SelectedIndex]
                    cmd.ExecuteNonQuery();
                    cones.cone().Close();

                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.ToString());
                }

            }
            else
            {

            }
            relaciona_notas rel = new relaciona_notas(NF.Text);
            rel.ShowDialog();

        }

        private void treeview1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            /*DiselectParentNodes(e.Node.Parent);
            DiselectChildNodes(e.Node.Nodes);*/

        }

        private void DiselectParentNodes(TreeNode parent)
        {
            while (parent != null)
            {
                if (parent.Checked)
                    parent.Checked = false;
                parent = parent.Parent;
            }
        }

        private void DiselectChildNodes(TreeNodeCollection childes)
        {
            foreach (TreeNode oneChild in childes)
            {
                if (oneChild.Checked)
                    oneChild.Checked = false;
                DiselectChildNodes(oneChild.Nodes);
            }
        }

        private void rectangleShape4_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            relaciona_notas rel = new relaciona_notas();
            rel.ShowDialog();

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

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
        private void pictureBox2_Click_1(object sender, EventArgs e)
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

            DialogResult Resultado = MessageBox.Show("Confirma as informações?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);




            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    //Gravando Informações no Banco
                    string coleta_data = "";
                    Connection cones = new Connection();
                    if (dateTimePicker2.Text == " ")
                    {
                        coleta_data = "NULL";
                    }
                    else
                    {
                        coleta_data = dateTimePicker2.Text;
                    }

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

                    if (arquivo_anexo != "")
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
                    }
                    String query = "INSERT INTO notas(nota_numero,nota_quantidade,nota_data_compra,nota_desc,nota_tipo_lic,nota_upgrade_versao,nota_resp_compra,nota_analista,nota_empresa,nota_site,nota_gerencia_compra,fk_soft_id,fk_cnpj,nota_nf,nota_validade,cod_produto,cst,quantidade,valor_total,valor_icms,ncm_sh,aliquota_icms,cfop,unidade,valor_unitario,base_icms,valor_ipi,aliquota_ipi,categoria_lic,arquivo) select '" + txtPO.Text + "','" + txtqtd.Text + "','" + dateTimePicker1.Text + "','" + txtDesc.Text + "','" + cbotiplic.Text + "','" + cboup.Text + "','" + txtresp.Text + "','" + txtanalista.Text + "','" + comboempresa.Text + "','" + combosite.Text + "','" + txtgerente.Text + "',s.soft_id,f.cnpj,'" + NF.Text + "','" + coleta_data + "','" + cod_pro.Text + "','" + cst.Text + "','" + qtd.Text + "','" + Convert.ToInt32(double.Parse(total.Text)).ToString() + "','" + Convert.ToInt32(double.Parse(valor_icms.Text)).ToString() + "','" + ncm.Text + "','" + ali_icms.Text + "','" + cfop.Text + "','" + unidade.Text + "','" + Convert.ToInt32(double.Parse(valor_unitario.Text)).ToString() + "','" + base_icms.Text + "','" + Convert.ToInt32(double.Parse(valor_ipi.Text)).ToString() + "','" + ali_ipi.Text + "','" + categoria_lic.Text + "','" + campo_arquivo + "' from software s, fornecedor f where s.soft_id = " + fk_soft_id + " and f.cnpj = '" + lista_userpk[lista_user.IndexOf(txtforn.Text)] + "'";

                    SqlCommand cmd = new SqlCommand(query, cones.cone()); //lista_pk[cbo_soft.SelectedIndex]
                    cmd.ExecuteNonQuery();
                    cones.cone().Close();
                    ClearTextBoxes();
                    ClearComboBoxes();
                    txtPO.Focus();

                }
                catch (Exception exe)
                {
                    MessageBox.Show(null, "Existem campos em branco favor verificar!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {

            }


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_Leave(object sender, EventArgs e)
        {

        }

        private void textBox8_Leave(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            relaciona_notas rel = new relaciona_notas(NF.Text);
            rel.ShowDialog();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            cadastro_localidades cad = new cadastro_localidades();
            cad.ShowDialog();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            CadastroFornecedor cad = new CadastroFornecedor();
            cad.ShowDialog();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            CadastroSoftware cad = new CadastroSoftware();
            cad.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void cboup_SelectedValueChanged_2(object sender, EventArgs e)
        {
            switch (cboup.Text)
            {
                case "NAO":
                    pictureBox17.Enabled = false;
                    break;
                case "SIM":
                    pictureBox17.Enabled = true;
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void valor_unitario_Leave(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            double val = Convert.ToInt64(int.Parse(valor_unitario.Text));
            MessageBox.Show(val.ToString());
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

        private void total_KeyUp(object sender, KeyEventArgs e)
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
                    total.Text = Convert.ToInt32(t).ToString();
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(null, "Verifique os valores!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void total_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //formata com o ponto de milhar
                total.Text = string.Format("{0,0:#,##0}", int.Parse(total.Text));

                //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
                //por isso na proxima linha conto quantos caractes tem no textbox
                int cont = total.TextLength;

                //Aqui eu coloco o cursor sempre depois do ultimo caractere
                total.SelectionStart = cont;
                total.SelectionLength = 0;
            }
            catch (Exception)
            {
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            /*Random rnd = new Random();
            int val1 = rnd.Next(1000, 9999);
            OpenFileDialog sv = new OpenFileDialog();

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string extension,path1;
                //MessageBox.Show(sv.FileName);
                extension =  Path.GetExtension(sv.FileName);
                path1 = Path.GetFullPath(sv.FileName);
                System.IO.StreamReader file = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "\\config.cfg");
                //byte[] b = (Convert.FromBase64String(File.ReadLines(sv.FileName).ElementAt(1).ToString()));

                String dec = File.ReadLines(Directory.GetCurrentDirectory() + "\\config.cfg").ElementAt(1);
                //MessageBox.Show(dec);
                //File.Move(sv.FileName, path1+"\\"+NF.Text +"."+ extension);
                File.Copy(sv.FileName, dec + "\\NOTA\\NOTA-" + val1.ToString() + "-" + NF.Text + extension);
                MessageBox.Show(null, "Anexo Salvo com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //file = Right(arr(i), Len(arr(i)) - InStrRev(arr(i), "\"))
            }*/
            panel4.Visible = true;

        }

        private void cbo_soft_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection conexao = new Connection();
            int i = 0;
            SqlDataReader sdr2;
            //SqlCommand cmd2 = new SqlCommand("select l.nome_localidade from empresas e, localidades l where e.ID_empresa = l.PK_empresa and e.nome_empresa = '" + comboempresa.Text + "' ORDER BY l.nome_localidade", conexao.cone());
            //SqlCommand cmd2 = new SqlCommand("select soft_id from software where soft_nome ='"+cbo_soft.Text+"' and soft_versao = '"+cbo_versao.Text+"'", conexao.cone());
            SqlCommand cmd2 = new SqlCommand("select soft_versao from software where soft_nome ='" + cbo_soft.Text + "'", conexao.cone());

            sdr2 = cmd2.ExecuteReader();
            cbo_versao.Text = "";
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

        private void total_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void base_icms_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboempresa_SelectedValueChanged_1(object sender, EventArgs e)
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click_2(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog sv = new OpenFileDialog();

            if (sv.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Add(sv.FileName);
                arquivo_anexo = sv.FileName;
                //notas.Add(cbo_nota.Text);

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int indi = 0;
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                //MessageBox.Show(notas[item.Index].ToString());
                dataGridView1.Rows.RemoveAt(item.Index);
                arquivo_anexo = "";
                //notas.RemoveAt(item.Index + 1);
            }
        }

        private void rectangleShape3_Click_1(object sender, EventArgs e)
        {

        }


    }
}
