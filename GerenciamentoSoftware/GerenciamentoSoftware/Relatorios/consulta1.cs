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

namespace GerenciamentoSoftware.Relatorios
{
    public partial class consulta1 : Form
    {
        public consulta1()
        {
            InitializeComponent();
        }

        private void consulta1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tSMDataSet.software' table. You can move, or remove it, as needed.

            this.softwareTableAdapter.Fill(this.tSMDataSet.software);
            ExtractDataToCSV(dataGridView1);
            //this.Hide();

            // TODO: This line of code loads data into the 'tSMDataSet2_fornecedor.fornecedor' table. You can move, or remove it, as needed.

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
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
