using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using DgvFilterPopup;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using GridPrintPreviewLib;

namespace GerenciamentoSoftware
{
    public partial class FornecedoresCadastrados : Form
    {

        public FornecedoresCadastrados()
        {
            InitializeComponent();
        }

        string operacao;
        public FornecedoresCadastrados(string valor)
        {
            InitializeComponent();
            operacao = valor;
        }


        void refresh()
        {
            DataTable dt1 = new DataTable();
            Connection con1 = new Connection();
            string Str1 = "select id_forn,cnpj as CNPJ,forn_nome as NOME,forn_email as EMAIL,forn_tel_contato1 as TELEFONE from fornecedor";
            SqlCommand cmd1 = new SqlCommand(Str1, con1.cone());
            cmd1.CommandTimeout = 0;
            dt1.Load(cmd1.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt1;
            this.dataGridView1.Columns["id_forn"].Visible = false;
        }
        public string retornaID()
        {
            try
            {
                string a;
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                a = Convert.ToString(selectedRow.Cells["id_forn"].Value);
                return a;
            }
            catch (Exception exe)
            {
                return null;
            }
        }
        DgvFilterManager fm = new DgvFilterManager();
        private void FornecedoresCadastrados_Load(object sender, EventArgs e)
        {
            if (operacao == "USER")
            {
                pictureBox13.Enabled = false;
                pictureBox12.Enabled = false;
            }

            fm.DataGridView = dataGridView1;
            DataTable dt1 = new DataTable();
            Connection con1 = new Connection();
            string contagem = "select COUNT(*) as valor from fornecedor";
            string Str1 = "select id_forn,cnpj as CNPJ,forn_nome as NOME,forn_email as EMAIL,forn_tel_contato1 as TELEFONE from fornecedor";
            SqlCommand cmd = new SqlCommand(Str1, con1.cone());
            SqlCommand cmd1 = new SqlCommand(contagem, con1.cone());
            cmd.CommandTimeout = 0;
            SqlDataReader read_contagem;
            read_contagem = cmd1.ExecuteReader();
            read_contagem.Read();
            sb_valor.Text = read_contagem["valor"].ToString();
            dt1.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt1;
            /*DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 200;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 200;
            DataGridViewColumn column2 = dataGridView1.Columns[5];
            column2.Width = 144;*/
            this.dataGridView1.Columns["id_forn"].Visible = false;








        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            update.atualiza_forn cad = new update.atualiza_forn(retornaID(), operacao);
            cad.ShowDialog();
        }

        private void FornecedoresCadastrados_Activated(object sender, EventArgs e)
        {
            refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroFornecedor cad = new CadastroFornecedor();
            cad.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult Resultado = MessageBox.Show("Caso remova fornecedores associados, notas podem ser removidas automaticamente,\n VOCÊ REALMENTE DESEJA REMOVER ESTE FORNECEDOR?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                try
                {
                    string a;
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    a = Convert.ToString(selectedRow.Cells["id_forn"].Value);

                    try
                    {
                        Connection cones = new Connection();
                        string Str = "Select count(*) from notas where fk_cnpj = (Select cnpj from fornecedor where id_forn = " + a + ")";
                        //string Str = "select count(*) from(Select cnpj from fornecedor where id_forn = " + a + ") ds, no";
                        SqlCommand cmd = new SqlCommand(Str, cones.cone());
                        int exist = (int)cmd.ExecuteScalar();
                        if (exist > 0)
                        {
                            MessageBox.Show("Existem notas relacionadas a este Fornecedor, o mesmo não pode ser removido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            Connection cones1 = new Connection();
                            String query = "delete from fornecedor where id_forn = " + a;

                            SqlCommand cmd1 = new SqlCommand(query, cones1.cone());
                            cmd1.ExecuteNonQuery();
                            cones1.cone().Close();
                            //MessageBox.Show("Dados removidos com sucesso!" + valor + valor2);
                            MessageBox.Show(null, "Fornecedor removido do cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            DataGridView dv = new DataGridView();
                        }


                        //MessageBox.Show(a);


                    }
                    catch (Exception exe)
                    {

                        MessageBox.Show("Existem notas relacionadas a este fornecedor, o mesmo não pode ser removido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show(null, "Não existem registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

            }
        }




        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
            refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            CadastroFornecedor cad = new CadastroFornecedor(operacao);
            cad.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            try
            {





                try
                {

                    string a;
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    a = Convert.ToString(selectedRow.Cells["id_forn"].Value);
                    //MessageBox.Show(a);
                    Connection cones = new Connection();
                    string Str = "Select count(*) from notas where fk_cnpj = (Select cnpj from fornecedor where id_forn = " + a + ")";
                    //string Str = "select count(*) from(Select cnpj from fornecedor where id_forn = " + a + ") ds, no";
                    SqlCommand cmd = new SqlCommand(Str, cones.cone());
                    int exist = (int)cmd.ExecuteScalar();
                    if (exist > 0)
                    {
                        MessageBox.Show("Existem notas relacionadas a este Fornecedor, o mesmo não pode ser removido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        String query = "delete from fornecedor where id_forn = " + a;

                        SqlCommand cmd1 = new SqlCommand(query, cones.cone());
                        cmd1.ExecuteNonQuery();
                        cones.cone().Close();
                        //MessageBox.Show("Dados removidos com sucesso!" + valor + valor2);
                        MessageBox.Show(null, "Fornecedor removido do cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DataGridView dv = new DataGridView();
                    }

                }
                catch (Exception exe)
                {

                    MessageBox.Show("Existem notas relacionadas a este fornecedor, o mesmo não pode ser removido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(null, "Não existem registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            CadastroNota cad = new CadastroNota();
            cad.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            CadastroSoftware cad = new CadastroSoftware();
            cad.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cadastro_localidades cad = new cadastro_localidades();
            cad.ShowDialog();
        }

        private void ExtractDataToCSV(DataGridView dgv)
        {
            // Don't save if no data is returned
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            // Column headers
            string columnsHeader = "";
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                columnsHeader += dgv.Columns[i].HeaderText + ",";
            }
            sb.Append(columnsHeader + Environment.NewLine);
            // Go through each cell in the datagridview
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                // Make sure it's not an empty row.
                if (!dgvRow.IsNewRow)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        // Append the cells data followed by a comma to delimit.

                        sb.Append(dgvRow.Cells[c].Value + ",");
                    }
                    // Add a new line in the text file.
                    sb.Append(Environment.NewLine);
                }
            }
            // Load up the save file dialog with the default option as saving as a .csv file.


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            //SaveFileDialog dlg = new SaveFileDialog();


            //sfd.ShowDialog();

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //if (DialogResult.OK == (new (sfd).Invoke()))
            {
                // If they've selected a save location...
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                {

                    // Write the stringbuilder text to the the file.
                    sw.WriteLine(sb.ToString());


                    MessageBox.Show(null, "Arquivo Salvo com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var caminho = Path.GetDirectoryName(sfd.FileName);
                    System.Diagnostics.Process.Start("explorer", caminho);


                }
            }
            else
            {

            }
            //this.Close();


        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ExtractDataToCSV(dataGridView1);
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create rectangle for drawing.
            float x = 150.0F;
            float y = 150.0F;
            float width = 200.0F;
            float height = 50.0F;
            RectangleF drawRect = new RectangleF(x, y, width, height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            String drawString = "Sample Text";




            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect);
            e.Graphics.DrawImage(bm, 0, 0);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            PrintDialog pdi = new PrintDialog();
            pdi.Document = pd;
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
            else
            {

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
            refresh();
        }



    }
}
