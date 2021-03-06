﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using DgvFilterPopup;
using System.IO;
using System.Data.SqlClient;
using System.Collections;

namespace GerenciamentoSoftware.Relatorios
{
    public partial class software_empresa : Form
    {
        public software_empresa()
        {
            InitializeComponent();
        }
        public CommonDialog InvokeDialog;
        private Thread InvokeThread;
        private DialogResult InvokeResult;

        public software_empresa(CommonDialog dialog)
        {
            InvokeDialog = dialog;
            InvokeThread = new Thread(new ThreadStart(InvokeMethod));
            InvokeThread.SetApartmentState(ApartmentState.STA);
            InvokeResult = DialogResult.None;
            InitializeComponent();
        }
        DgvFilterManager fm = new DgvFilterManager();

        private void ExtractDataToCSV1(DataGridView dgv)
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
        public DialogResult Invoke()
        {
            InvokeThread.Start();
            InvokeThread.Join();
            return InvokeResult;
        }

        void carrega_grid()
        {
            DataTable dt = new DataTable();
            string ver = "";
            string loc = "";
            string strquery = "";
            string strquery1 = "";
            //this.Refresh();
            if (equip.Text != "")
            {

                //softwareBindingSource1.ResetBindings(true);
                Connection con = new Connection();
                string Str = "select * from software_csn where Hostname like '" + equip.Text + "%'";
                SqlCommand cmd = new SqlCommand(Str, con.cone());
                cmd.CommandTimeout = 0;
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show(null, "Escolha ou digite o nome do Equipamento!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InvokeMethod()
        {
            InvokeResult = InvokeDialog.ShowDialog();

        }

        private void software_empresa_Load(object sender, EventArgs e)
        {
            fm.DataGridView = dataGridView1;

            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            SqlDataReader sdr1;


            int i = 0;


            SqlCommand cmd2 = new SqlCommand("select distinct hostname from software_csn", conexao.cone());

            //comboempresa.Items.Add("Todos");


            sdr1 = cmd2.ExecuteReader();


            /*while (sdr1.Read() == true)
            {
                comboempresa.Items.Add(sdr1["NOME_EMPRESA"].ToString());
                i++;
            }*/

            while (sdr1.Read() == true)
            {
                lista_pass.Add(sdr1["hostname"].ToString());
                //MessageBox.Show("Usuário: " + lista_user[i]);
                //MessageBox.Show(sdr["username"].ToString());
                equip.Items.Add(lista_pass[i]);
                i++;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread grid = new Thread(prog);
            grid.Start();
            carrega_grid();
            grid.Abort();
        }
        progress2 pb = new progress2();
        void prog()
        {
            pb.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExtractDataToCSV1(dataGridView1);
        }
    }
}
