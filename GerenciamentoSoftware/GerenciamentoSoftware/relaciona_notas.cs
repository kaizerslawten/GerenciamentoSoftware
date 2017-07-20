using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoSoftware
{
    public partial class relaciona_notas : Form
    {
        public relaciona_notas()
        {
            InitializeComponent();
        }

        static string vloi;
        public relaciona_notas(string valor)
        {
            InitializeComponent();
            vloi = valor;

        }
        string query_list = "select (select nota_nf from notas where notad_id = nota_rel) as 'NF',s.soft_nome as 'SOFTWARE',n.nota_data_compra as 'DATA',relacionamento_nota.id_rel from relacionamento_nota, notas n join software s on (s.soft_id = n.fk_soft_id) where n.notad_id = nota_rel and id_nota = '";

        ArrayList notas = new ArrayList();
        private void relaciona_notas_Load(object sender, EventArgs e)
        {
            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_pass = new ArrayList();
            SqlDataReader sdr1;
            SqlDataReader sdr2;


            int i = 0;

            SqlCommand cmd2 = new SqlCommand("SELECT  distinct s.soft_nome as SOFTWARE FROM notas AS n INNER JOIN software AS s ON n.fk_soft_id = s.soft_id", conexao.cone());

            //comboempresa.Items.Add("Todos");


            sdr1 = cmd2.ExecuteReader();

            while (sdr1.Read() == true)
            {
                lista_pass.Add(sdr1["SOFTWARE"].ToString());
                //MessageBox.Show("Usuário: " + lista_user[i]);
                //MessageBox.Show(sdr["username"].ToString());
                cbo_soft.Items.Add(lista_pass[i]);
                i++;
            }
            conexao.cone().Close();

            DataTable dt = new DataTable();
            string Str = query_list + vloi + "'";

            //string Str = "select s.soft_nome as SOFTWARE,n.nota_nf AS NOTA,n.nota_data_compra AS DATA from notas n join software s on (s.soft_id = n.fk_soft_id) join relacionamento_nota r on (r.nota_rel = n.nota_nf) where r.id_nota = '444f'";
            SqlCommand cmd = new SqlCommand(Str, conexao.cone());
            cmd.CommandTimeout = 0;
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            DataGridViewColumn column = dataGridView1.Columns[0];
            DataGridViewColumn column3 = dataGridView1.Columns[1];
            DataGridViewColumn column5 = dataGridView1.Columns[2];
            DataGridViewColumn column6 = dataGridView2.Columns[0];
            DataGridViewColumn column7 = dataGridView2.Columns[1];
            dataGridView1.Columns[3].Visible = false;
            column6.Width = 150;
            column7.Width = 500;
            column5.Width = 160;
            column.Width = 200;
            column3.Width = 200;
            //dataGridView2.Columns[3].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (cbo_nota.Text == "")
            {
                MessageBox.Show(null, "Escolha a nota a relacionar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                dataGridView2.Rows.Add(cbo_nota.Text, cbo_soft.Text);
                notas.Add(cbo_nota.Text);
            }

        }

        private void cbo_nota_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbo_soft_SelectedValueChanged(object sender, EventArgs e)
        {
            cbo_nota.Items.Clear();
            cbo_nota.Text = "";
            Connection conexao = new Connection();
            ArrayList lista_user = new ArrayList();
            ArrayList lista_pass = new ArrayList();

            SqlDataReader sdr2;


            int i = 0;


            SqlCommand cmd3 = new SqlCommand("select n.nota_nf as NF from notas n join software s on (s.soft_id = n.fk_soft_id) where s.soft_nome = '" + cbo_soft.Text + "'", conexao.cone());
            //comboempresa.Items.Add("Todos");

            sdr2 = cmd3.ExecuteReader();


            while (sdr2.Read() == true)
            {
                if (sdr2["NF"].ToString() == vloi)
                {

                }
                else
                {
                    cbo_nota.Items.Add(sdr2["NF"].ToString());
                }

                i++;
            }
            i = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int indi = 0;
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                //MessageBox.Show(notas[item.Index].ToString());
                dataGridView2.Rows.RemoveAt(item.Index);
                notas.RemoveAt(item.Index + 1);



            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(notas[0].ToString());

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {

                string a;
                int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                a = Convert.ToString(selectedRow.Cells["NOTA"].Value);

                Connection cones = new Connection();
                String query = "delete from relacionamento_nota where id_nota = '" + vloi + "' and nota_rel = '" + a + "'";
                SqlCommand cmd = new SqlCommand(query, cones.cone());
                cmd.ExecuteNonQuery();
                cones.cone().Close();

                DataTable dt = new DataTable();
                string Str = query_list + vloi + "'";
                //string Str = "select s.soft_nome as SOFTWARE,n.nota_nf AS NOTA,n.nota_data_compra AS DATA from notas n join software s on (s.soft_id = n.fk_soft_id) join relacionamento_nota r on (r.nota_rel = n.nota_nf) where r.id_nota = '444f'";
                SqlCommand cmd1 = new SqlCommand(Str, cones.cone());
                cmd1.CommandTimeout = 0;
                dt.Load(cmd1.ExecuteReader());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                DataGridViewColumn column = dataGridView1.Columns[0];
                DataGridViewColumn column3 = dataGridView1.Columns[1];
                DataGridViewColumn column5 = dataGridView1.Columns[2];
                column5.Width = 160;
                column.Width = 200;
                column3.Width = 200;
                //MessageBox.Show("Dados removidos com sucesso!" + valor + valor2);
                MessageBox.Show(null, "Relacionamento removido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {



                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.ToString());
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(null, "Não existem registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Connection cones = new Connection();
            //String query = "insert into relacionamento_nota values('" + vloi + "','" + notas + "'";
            //SqlCommand cmd = new SqlCommand(query, cones.cone());
            //cmd.ExecuteNonQuery();
            //cones.cone().Close();

            for (int i = 0; i < notas.Count; i++)
            {
                String query = "insert into relacionamento_nota values('" + vloi + "','" + notas[i] + "')";
                SqlCommand cmd = new SqlCommand(query, cones.cone());
                cmd.ExecuteNonQuery();
                cones.cone().Close();
            }
            DataTable dt = new DataTable();
            string Str = query_list + vloi + "'";
            //string Str = "select s.soft_nome as SOFTWARE,n.nota_nf AS NOTA,n.nota_data_compra AS DATA from notas n join software s on (s.soft_id = n.fk_soft_id) join relacionamento_nota r on (r.nota_rel = n.nota_nf) where r.id_nota = '444f'";
            SqlCommand cmd1 = new SqlCommand(Str, cones.cone());
            cmd1.CommandTimeout = 0;
            dt.Load(cmd1.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            DataGridViewColumn column = dataGridView1.Columns[0];
            DataGridViewColumn column3 = dataGridView1.Columns[1];
            DataGridViewColumn column5 = dataGridView1.Columns[2];
            column5.Width = 160;
            column.Width = 200;
            column3.Width = 200;
            notas.Clear();
            dataGridView2.Rows.Clear();
            MessageBox.Show(null, "Relacionamento Adicionado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            int indi = 0;
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                //MessageBox.Show(notas[item.Index].ToString());
                dataGridView2.Rows.RemoveAt(item.Index);
                notas.RemoveAt(item.Index + 1);



            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            if (cbo_nota.Text == "")
            {
                MessageBox.Show(null, "Escolha a nota a relacionar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Connection cone = new Connection();
                string Str = "select notad_id from notas join software s on (s.soft_id = fk_soft_id) where nota_nf = '" + cbo_nota.Text + "' and s.soft_nome = '" + cbo_soft.Text + "'";
                SqlCommand cmd = new SqlCommand(Str, cone.cone());
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();

                int i = 0;
                dataGridView2.Rows.Add(cbo_nota.Text, cbo_soft.Text);
                notas.Add(sdr["notad_id"].ToString());
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {

                string a;
                int selectedrowindex = dataGridView1.SelectedCells[1].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                a = Convert.ToString(selectedRow.Cells["id_rel"].Value);

                Connection cones = new Connection();
                //String query = "delete from relacionamento_nota where id_nota = '" + vloi + "' and nota_rel = (select distinct notad_id from notas where nota_nf = '" + a + "')";
                String query = "delete from relacionamento_nota where id_rel = " + a;

                SqlCommand cmd = new SqlCommand(query, cones.cone());
                cmd.ExecuteNonQuery();


                DataTable dt = new DataTable();
                //string Str = "select s.soft_nome as SOFTWARE,n.nota_nf AS NOTA,n.nota_data_compra AS DATA from notas n join software s on (s.soft_id = n.fk_soft_id) join relacionamento_nota r on (r.nota_rel = n.notad_id) where r.id_nota = '" + vloi + "'";
                string Str = query_list + vloi + "'";
                //string Str = "select s.soft_nome as SOFTWARE,n.nota_nf AS NOTA,n.nota_data_compra AS DATA from notas n join software s on (s.soft_id = n.fk_soft_id) join relacionamento_nota r on (r.nota_rel = n.nota_nf) where r.id_nota = '444f'";
                SqlCommand cmd1 = new SqlCommand(Str, cones.cone());
                cmd1.CommandTimeout = 0;
                dt.Load(cmd1.ExecuteReader());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                DataGridViewColumn column = dataGridView1.Columns[0];
                DataGridViewColumn column3 = dataGridView1.Columns[1];
                DataGridViewColumn column5 = dataGridView1.Columns[2];
                column5.Width = 160;
                column.Width = 200;
                column3.Width = 200;
                //MessageBox.Show("Dados removidos com sucesso!" + valor + valor2);
                MessageBox.Show(null, "Relacionamento removido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {



                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.ToString());
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(null, "Não existem registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Connection cones = new Connection();
            //String query = "insert into relacionamento_nota values('" + vloi + "','" + notas + "'";
            //SqlCommand cmd = new SqlCommand(query, cones.cone());
            //cmd.ExecuteNonQuery();
            //cones.cone().Close();

            for (int i = 0; i < notas.Count; i++)
            {
                String query = "insert into relacionamento_nota values('" + vloi + "','" + notas[i] + "')";
                SqlCommand cmd = new SqlCommand(query, cones.cone());
                cmd.ExecuteNonQuery();
                cones.cone().Close();
            }
            DataTable dt = new DataTable();
            string Str = query_list + vloi + "'";
            //string Str = "select s.soft_nome as SOFTWARE,n.nota_nf AS NOTA,n.nota_data_compra AS DATA from notas n join software s on (s.soft_id = n.fk_soft_id) join relacionamento_nota r on (r.nota_rel = n.nota_nf) where r.id_nota = '444f'";
            SqlCommand cmd1 = new SqlCommand(Str, cones.cone());
            cmd1.CommandTimeout = 0;
            dt.Load(cmd1.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            DataGridViewColumn column = dataGridView1.Columns[0];
            DataGridViewColumn column3 = dataGridView1.Columns[1];
            DataGridViewColumn column5 = dataGridView1.Columns[2];
            column5.Width = 160;
            column.Width = 200;
            column3.Width = 200;
            notas.Clear();
            dataGridView2.Rows.Clear();
            MessageBox.Show(null, "Relacionamento Adicionado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
