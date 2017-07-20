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


namespace GerenciamentoSoftware.cadusers
{
    public partial class usuarios_cad : Form
    {
        public usuarios_cad()
        {
            InitializeComponent();
        }
        public string retornaID()
        {
            string a;
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            a = Convert.ToString(selectedRow.Cells["id_user"].Value);
            return a;
        }
        private void usuarios_cad_Load(object sender, EventArgs e)
        {

        }

        private void usuarios_cad_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tSMDataSet11.login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.tSMDataSet11.login);

        }

        private void usuarios_cad_Activated(object sender, EventArgs e)
        {
            refresh();
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            //softwareBindingSource1.ResetBindings(true);
            Connection con = new Connection();
            string Str = "Select * from login";
            SqlCommand cmd = new SqlCommand(Str, con.cone());
            dt.Load(cmd.ExecuteReader());
            loginBindingSource.DataSource = null;
            loginBindingSource.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //update.cadusers1 cad = new update.atualizar_registro(retornaID());

            //cad.ShowDialog();

        }
    }
}
