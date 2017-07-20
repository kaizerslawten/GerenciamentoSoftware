using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using DgvFilterPopup;
using System.Drawing.Printing;
using System.IO;

namespace GerenciamentoSoftware
{
    public partial class SoftwaresCadastrados : Form
    {
        public static string a;


        public string retornaID()
        {
            try
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                a = Convert.ToString(selectedRow.Cells["soft_id"].Value);
                return a;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string rt
        {

            get { return a + "Teste!"; }
        }
        public SoftwaresCadastrados()
        {
            InitializeComponent();


        }
        string operacao;
        public SoftwaresCadastrados(string valor)
        {
            InitializeComponent();
            operacao = valor;
        }




        DgvFilterManager fm = new DgvFilterManager();
        private void SoftwaresCadastrados_Load(object sender, EventArgs e)
        {

            if (operacao == "USER")
            {
                pictureBox13.Enabled = false;
                pictureBox12.Enabled = false;
            }
            fm.DataGridView = dataGridView1;
            // TODO: This line of code loads data into the 'tSMDataSet.software' table. You can move, or remove it, as needed.
            DataTable dt1 = new DataTable();
            Connection con1 = new Connection();
            string contagem = "select COUNT(*) as valor from software";
            string Str1 = "Select soft_id, soft_nome as NOME,soft_versao as VERSAO,soft_nomeExecutavel as EXECUTAVEL,soft_SO as 'SISTEMA OPERACIONAL',soft_fabricante as FABRICANTE from software";
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
            // TODO: This line of code loads data into the 'tSMDataSet.software' table. You can move, or remove it, as needed.
            //this.softwareTableAdapter.Fill(this.tSMDataSet.software);
            // TODO: This line of code loads data into the 'tSMDataSet.software' table. You can move, or remove it, as needed.




            this.dataGridView1.Columns["soft_id"].Visible = false;
            // TODO: This line of code loads data into the 'tSMDataSet.software' table. You can move, or remove it, as needed.
            DataGridViewColumn column = dataGridView1.Columns[1];
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column.Width = 250;
            column2.Width = 150;
            column4.Width = 250;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroSoftware cad = new CadastroSoftware(retornaID());
            cad.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {


            try
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                a = Convert.ToString(selectedRow.Cells["soft_id"].Value);

                //MessageBox.Show(a);

                try
                {

                    Connection cones = new Connection();
                    string Str = "Select count(*) from notas where fk_soft_id = " + a;
                    SqlCommand cmd = new SqlCommand(Str, cones.cone());
                    int exist = (int)cmd.ExecuteScalar();
                    if (exist > 0)
                    {
                        MessageBox.Show("Existem notas relacionadas a este software, o mesmo não pode ser removido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        String query2 = "delete from software where soft_id = " + a;
                        SqlCommand cmd2 = new SqlCommand(query2, cones.cone());
                        int valor2 = cmd2.ExecuteNonQuery();
                        cones.cone().Close();
                        //MessageBox.Show("Dados removidos com sucesso!" + valor + valor2);
                        MessageBox.Show("Software removido do cadastro!");

                        DataGridView dv = new DataGridView();
                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Existem notas relacionadas a este software, o mesmo não pode ser removido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(null, "Não existem registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }


        public string str1
        {
            get
            {
                return a;
            }
        }
        private void SoftwaresCadastrados_Activated(object sender, EventArgs e)
        {
            refresh();
        }
        void refresh()
        {
            DataTable dt1 = new DataTable();
            Connection con1 = new Connection();
            string Str1 = "Select soft_id, soft_nome as NOME,soft_versao as VERSAO,soft_nomeExecutavel as EXECUTAVEL,soft_SO as 'SISTEMA OPERACIONAL',soft_fabricante as FABRICANTE from software";
            SqlCommand cmd1 = new SqlCommand(Str1, con1.cone());
            cmd1.CommandTimeout = 0;
            dt1.Load(cmd1.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt1;
            DataGridViewColumn column = dataGridView1.Columns[1];
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column.Width = 250;
            column2.Width = 150;
            column4.Width = 250;
            this.dataGridView1.Columns["soft_id"].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            update.atualizar_registro cad = new update.atualizar_registro(retornaID(), operacao);
            cad.ShowDialog();

        }





        private void button4_Click(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            CadastroNota nota = new CadastroNota();
            nota.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {


            try
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                a = Convert.ToString(selectedRow.Cells["soft_id"].Value);

                //MessageBox.Show(a);

                try
                {

                    Connection cones = new Connection();
                    string Str = "Select count(*) from notas where fk_soft_id = " + a;
                    SqlCommand cmd = new SqlCommand(Str, cones.cone());
                    int exist = (int)cmd.ExecuteScalar();
                    if (exist > 0)
                    {
                        MessageBox.Show("Existem notas relacionadas a este software, o mesmo não pode ser removido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        String query2 = "delete from software where soft_id = " + a;
                        SqlCommand cmd2 = new SqlCommand(query2, cones.cone());
                        int valor2 = cmd2.ExecuteNonQuery();
                        cones.cone().Close();
                        //MessageBox.Show("Dados removidos com sucesso!" + valor + valor2);
                        MessageBox.Show("Software removido do cadastro!");

                        DataGridView dv = new DataGridView();
                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Existem notas relacionadas a este software, o mesmo não pode ser removido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            CadastroSoftware cad = new CadastroSoftware(operacao);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                //MessageBox.Show("Impressão cancelada!");
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
            refresh();
        }

    }
}
