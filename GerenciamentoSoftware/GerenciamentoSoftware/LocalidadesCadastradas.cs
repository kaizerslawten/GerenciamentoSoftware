using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DgvFilterPopup;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;

namespace GerenciamentoSoftware
{
    public partial class LocalidadesCadastradas : Form
    {
        public LocalidadesCadastradas()
        {
            InitializeComponent();
        }
        public string retornaID()
        {
            try
            {

                string a;
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                a = Convert.ToString(selectedRow.Cells["id_localidade"].Value);
                return a;
            }
            catch (Exception exe)
            {
                return null;
            }
        }

        string operacao;
        public LocalidadesCadastradas(string valor)
        {
            InitializeComponent();
            operacao = valor;
        }

        DgvFilterManager fm = new DgvFilterManager();
        private void LocalidadesCadastradas_Load(object sender, EventArgs e)
        {

            if (operacao == "USER")
            {
                pictureBox13.Enabled = false;
                pictureBox12.Enabled = false;
            }

            fm.DataGridView = dataGridView1;
            // TODO: This line of code loads data into the 'tSMDataSet1.login' table. You can move, or remove it, as needed.
            DataTable dt1 = new DataTable();
            Connection con1 = new Connection();
            string Str = "select id_localidade,nome_site as 'NOME DO SITE',empresa as 'EMPRESA',endereco as 'ENDERECO',cidade as 'CIDADE',estado as 'ESTADO', cnpj as 'CNPJ' from cadastro_localidades";
            SqlCommand cmd = new SqlCommand(Str, con1.cone());
            cmd.CommandTimeout = 0;
            dt1.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt1;
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 200;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 200;
            DataGridViewColumn column2 = dataGridView1.Columns[5];
            column2.Width = 144;
            this.dataGridView1.Columns["id_localidade"].Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            update.atualiza_localidade cad = new update.atualiza_localidade(retornaID(), operacao);
            cad.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            CadastroFornecedor cad = new CadastroFornecedor();
            cad.ShowDialog();
        }
        void refresh()
        {
            DataTable dt1 = new DataTable();
            Connection con1 = new Connection();
            string Str1 = "select id_localidade,nome_site as 'NOME DO SITE',empresa as 'EMPRESA',endereco as 'ENDERECO',cidade as 'CIDADE',estado as 'ESTADO', cnpj as 'CNPJ' from cadastro_localidades";
            SqlCommand cmd1 = new SqlCommand(Str1, con1.cone());
            cmd1.CommandTimeout = 0;
            dt1.Load(cmd1.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt1;
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 200;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 200;
            DataGridViewColumn column2 = dataGridView1.Columns[5];
            column2.Width = 144;
            this.dataGridView1.Columns["id_localidade"].Visible = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
            refresh();
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

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            cadastro_localidades cad = new cadastro_localidades(operacao);
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
                    a = Convert.ToString(selectedRow.Cells["id_localidade"].Value);
                    //MessageBox.Show(a);
                    Connection cones = new Connection();
                    string Str = "Select count(*) from cadastro_localidades where id_localidade = " + a;
                    //string Str = "select count(*) from(Select cnpj from fornecedor where id_forn = " + a + ") ds, no";
                    SqlCommand cmd = new SqlCommand(Str, cones.cone());
                    int exist = (int)cmd.ExecuteScalar();
                    if (exist > 0)
                    {
                        MessageBox.Show("Existem notas relacionadas a esta Localidade, a mesma não pode ser removida", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        String query = "delete from cadastro_localidades where id_localidade = " + a;

                        SqlCommand cmd1 = new SqlCommand(query, cones.cone());
                        cmd1.ExecuteNonQuery();
                        cones.cone().Close();
                        //MessageBox.Show("Dados removidos com sucesso!" + valor + valor2);
                        MessageBox.Show(null, "Localidade removida do cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DataGridView dv = new DataGridView();
                    }

                }
                catch (Exception exe)
                {

                    MessageBox.Show("Existem notas relacionadas a esta localidade, a mesma não pode ser removida", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(null, "Não existem registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
            refresh();
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
            //if (DialogResult.OK == (new consulta_equipamento(sfd).Invoke()))
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
    }
}
