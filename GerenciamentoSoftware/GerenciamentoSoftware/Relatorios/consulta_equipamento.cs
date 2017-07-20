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
using System.Threading;
using DgvFilterPopup;
using System.Drawing.Printing;
using System.Diagnostics;

namespace GerenciamentoSoftware.Relatorios
{
    public partial class consulta_equipamento : Form
    {

        public consulta_equipamento()
        {
            InitializeComponent();
        }

        public CommonDialog InvokeDialog;
        private Thread InvokeThread;
        private DialogResult InvokeResult;

        public consulta_equipamento(CommonDialog dialog)
        {
            InvokeDialog = dialog;
            InvokeThread = new Thread(new ThreadStart(InvokeMethod));
            InvokeThread.SetApartmentState(ApartmentState.STA);
            InvokeResult = DialogResult.None;
            InitializeComponent();
        }

        public DialogResult Invoke()
        {
            InvokeThread.Start();
            InvokeThread.Join();
            return InvokeResult;
        }

        private void InvokeMethod()
        {
            InvokeResult = InvokeDialog.ShowDialog();

        }
        DgvFilterManager fm = new DgvFilterManager();
        private void consulta_equipamento_Load(object sender, EventArgs e)
        {
            fm.DataGridView = dataGridView1;
            /*DataTable dt = new DataTable("teste");
            //softwareBindingSource1.ResetBindings(true);
            DataSet ds = new DataSet();
            Connection con = new Connection();
            string Str = "SELECT software AS [Nome Software], versao AS Version, COUNT(software) AS [Quant] FROM software_csn GROUP BY versao, software";
            //SqlCommand cmd = new SqlCommand(Str, con.cone());            
            SqlDataAdapter da = new SqlDataAdapter(Str, con.cone());
            da.Fill(ds, "software_csn");
            dataGridView1.DataSource = ds.Tables["software_csn"];
            SqlDataReader sdr;
            SqlCommand cmd = new SqlCommand(Str, con.cone());
            cmd.CommandTimeout = 0;
            sdr = cmd.ExecuteReader();*/

            /*int i = 0;
            while (sdr.Read())
            {
                valores.AutoCompleteCustomSource.Add(sdr["nota_numero"].ToString());
                i++;
            }*/
            // TODO: This line of code loads data into the 'dataSet2_INSTALADOS.software_csn' table. You can move, or remove it, as needed.
            //DataTable dt = new DataTable();
            //softwareBindingSource1.ResetBindings(true);
            // Connection con = new Connection();
            // string Str = "Select * from software ";
            //SqlCommand cmd = new SqlCommand(Str, con.cone());
            //dt.Load(cmd.ExecuteReader());

            //softwareBindingSource1.DataSource = null;
            //softwareBindingSource1.DataSource = dt;
            //this.software_csnTableAdapter.Fill(this.dataSet2_INSTALADOS.software_csn);

            // TODO: This line of code loads data into the 'dataSet2_INSTALADOS.empresas' table. You can move, or remove it, as needed.


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

            //if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            if (DialogResult.OK == (new consulta_equipamento(sfd).Invoke()))
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
            ExtractDataToCSV(dataGridView1);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public DataSet GetDataSet(string ConnectionString, string SQL)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = SQL;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }

        private void valores_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

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

        private void button2_Click_1(object sender, EventArgs e)
        {
            ExtractDataToCSV(dataGridView1);
        }

        private void cbo_soft_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*DataSet ds = new DataSet();
            Connection con = new Connection();
            string Str = "select dt.Localidade,dt.NOME as Software, dt.VERSAO as Versao,count(dt.NOME)  Instalados, (case when dt.Localidade = n2.nota_empresa+' - '+n2.nota_site then n2.nota_quantidade Else '0' End) as Adquiridos  from(select software as NOME, versao as VERSAO,Hostname, case when Hostname like 'CBS%' or Hostname like '%BVR%' then 'CSN - CBS - VOLTA REDONDA' when Hostname like '%BVO%' then 'CSN - CBS - Vila Olímpia Funchal' when Hostname like '%FFO%' then 'CSN - CFN - Fortaleza' when Hostname like '%IVR%' then 'CSN - CIMENTOS  - Volta Redonda' when Hostname like '%IAA%' then 'CSN - CIMENTOS  - Arará' when Hostname like '%IQU%' then 'CSN - CIMENTOS  - Queimados' when Hostname like '%ICU%' then 'CSN - CIMENTOS  - Capuava' when Hostname like '%ISJ%' then 'CSN - CIMENTOS  - São José dos Campos' when Hostname like '%IIB%' then 'CSN - CIMENTOS  - Itaboraí' when Hostname like '%EAQ%' then 'CSN - ERSA - Ariquemes' when Hostname like '%EIO%' then 'CSN - ERSA - Itapuã do Oeste' when Hostname like '%FVO%' then 'CSN - FUNDAÇÃO CSN - Vila Olímpia - Funchal' when Hostname like '%MMA%' then 'CSN - METALIC - Maracanaú' when Hostname like '%NCP%' then 'CSN - NAMISA - Casa de Pedra' when Hostname like '%NOP%' then 'CSN - NAMISA - Ouro Preto' when Hostname like '%NIR%' then 'CSN - NAMISA - Itabirito' when Hostname like '%NIG%' then 'CSN - NAMISA - Iguatemí' when Hostname like '%PMC%' then 'CSN - PRADA DISTRIBUIÇÃO - Mogi das Cruzes' when Hostname like '%PPI%' then 'CSN - PRADA DISTRIBUIÇÃO - Piracicaba' when Hostname like '%PCO%' then 'CSN - PRADA DISTRIBUIÇÃO - Contagem' when Hostname like '%PJF%' then 'CSN - PRADA DISTRIBUIÇÃO - Juiz de Fora' when Hostname like '%PBE%' then 'CSN - PRADA DISTRIBUIÇÃO - Bebedouro' when Hostname like '%PAU%' then 'CSN - PRADA DISTRIBUIÇÃO - Araucária' when Hostname like '%RSA%' then 'CSN - PRADA EMBALAGENS - Santo Amaro' when Hostname like '%RUB%' then 'CSN - PRADA EMBALAGENS - Uberlândia' when Hostname like '%TIT%' then 'CSN - TECON - Itaguaí' when Hostname like '%TSJ%' then 'CSN - TECON - São José' when Hostname like '%TVI%' then 'CSN - TECON - Visconde de Inhaúma' when Hostname like 'ARRE%' then 'CSN - PRADA - METALURGICA - RESENDE' when Hostname like 'ARLI%' then 'CSN - PRADA - METALURGICA - LINS' when Hostname like 'ARLU%' then 'CSN - PRADA - METALURGICA - LUZIANIA' when Hostname like 'ARPE%' then 'CSN - PRADA - METALURGICA - PELOTAS' when Hostname like 'GV%' or Hostname like '%CPO%' then 'CSN - PORTO REAL' when Hostname like '%CIT%' then 'CSN - Itaguaí' when Hostname like 'CP%' or Hostname like '%CCP%' then 'CSN - CASA DE PEDRA' when Hostname like 'AR0%' or Hostname like '%CAR%' then 'CSN - ARCOS' when Hostname like '%CFL%' then 'CSN - Faria Lima' when Hostname like '%CPA%' then 'CSN - Paraná' when Hostname like '%CMC%' then 'CSN - Mogi das Cruzes' when Hostname like '%CSA%' then 'CSN - Santo Amaro' when Hostname like '%CCA%' then 'CSN - Camaçari' when Hostname like '%CSJ%' then 'CSN - São José' when Hostname like '%CVO%' then 'CSN - Vila Olímpia - Funchal' when Hostname like '%CCO%' then 'CSN - Contagem' when Hostname like '%CMO%' then 'CSN - Mooca' when Hostname like '%CJV%' then 'CSN - Joinville' when Hostname like '%CGR%' then 'CSN - Gravataí' when Hostname like '%CCR%' then 'CSN - Criciúma' when Hostname like '%CJG%' then 'CSN - Jaboatão dos Guararapes' when Hostname like '%CCX%' then 'CSN - Caxias do Sul' when Hostname like '%CAU%' then 'CSN - Araucária' when Hostname like 'RS%' or Hostname like '%CCN%' then 'CSN - CANOAS' when Hostname like '%LFO%' then 'CSN - TLSA - Fortaleza' when Hostname like '%LRE%' then 'CSN - TLSA - Recife' when Hostname like '%LSL%' then 'CSN - TLSA - São Luiz' when Hostname like '%LTE%' then 'CSN - TLSA - Teresina' when Hostname like '%LMA%' then 'CSN - TLSA - Maracanaú' when Hostname like '%LCG%' then 'CSN - TLSA - Campina Grore' when Hostname like '%LCI%' then 'CSN - TLSA - Cinco Pontas' when Hostname like '%LCT%' then 'CSN - TLSA - Crateús' when Hostname like '%LCC%' then 'CSN - TLSA - Crato' when Hostname like '%LIU%' then 'CSN - TLSA - Iguatú' when Hostname like '%LIA%' then 'CSN - TLSA - Itabaiana' when Hostname like '%LIQ%' then 'CSN - TLSA - Itaquí' when Hostname like '%LIE%' then 'CSN - TLSA - Itararé' when Hostname like '%LJP%' then 'CSN - TLSA - João Pessoa' when Hostname like '%LJZ%' then 'CSN - TLSA - Juazeiro' when Hostname like '%LLA%' then 'CSN - TLSA - Lacerda' when Hostname like '%LMA%' then 'CSN - TLSA - Maceió' when Hostname like '%LMUC%' then 'CSN - TLSA - Mucuripe' when Hostname like '%LSB%' then 'CSN - TLSA - Sobral' when Hostname like '%LSZ%' then 'CSN - TLSA - Souza'  when Hostname like 'EX%' then 'TERCEIRO' when Hostname like 'N%' and Hostname not like 'NM%' then 'CSN - Servidor' when Hostname like 'ANRA%' then 'CSN - NAMISA - ITABIRITO - RIO ACIMA' when Hostname like 'ACVJ%' then 'CSN - JOINVILE' when Hostname like 'ANSP%' then 'CSN - NAMISA - SAO PAULO' when Hostname like 'PR%' or Hostname like 'APAC%' then 'CSN - ARAUCARIA'  when Hostname like 'BA%' then 'CSN - CAMACARI' when Hostname like 'CFFO%' then 'CSN - FTL - TERESINA' when Hostname like 'ER%' then 'CSN - ERSA - ARIQUEMES'  when Hostname like 'FE%' then 'CSN - CIMENTOS - VOLTA REDONDA' when Hostname like 'FU%' then 'CSN - FUNDACAO CSN - ESCOLA TECNICA PorIA CALOGERAS' when Hostname like 'HK%' then 'CSN - ASIA - HONG KONG' when Hostname like 'IN%' then 'CSN - PRADA - DISTRIBUICAO - MOGI DAS CRUZES' when Hostname like 'ME%' then 'CSN - METALIC - MARACANAU' when Hostname like 'ANOP%' or Hostname like 'NM%' then 'CSN - NAMISA - OURO PRETO' when Hostname like 'PD%' then 'CSN - PRADA - METALURGICA - SANTO AMARO' when Hostname like 'PE%' then 'CSN - JABOATAO DOS GUARARAPES' when Hostname like 'PO%' then 'CSN - ITAGUAI'  when Hostname like 'AU%' or Hostname like 'LU%' or Hostname like 'PT%' or  Hostname like 'ES%' then 'CSN - HANDEL - AUSTRIA' when Hostname like '%FVR%' or Hostname like 'VR%' or Hostname like 'AL0%' or Hostname like 'PVR%' or Hostname like '%CVR%' or hostname like 'BH%' or Hostname like 'TVR%' or Hostname like 'VVR%' then 'CSN - VOLTA REDONDA' when Hostname like 'RJ%' or Hostname like 'ACRJ%' then 'CSN - RIO DE JANEIRO' when Hostname like 'CDI%' then 'CSN - CDI' when Hostname like 'CI%' then 'CSN - VOLTA REDONDA' when Hostname like 'SC%' then 'CSN - CRICIUMA' when Hostname like 'SP%' then 'CSN - FARIA LIMA - SEDE' when Hostname like 'TE%' then 'CSN - SEPETIBA TECON - ITAGUAI' when Hostname like 'TL%' then 'CSN - TLSA - FORTALEZA'   End  Localidade   from software_csn where Hostname like '%%' and software like '"+cbo_soft.Text+"%' and versao like '%%') dt full outer join notas as n2 on(dt.Localidade = n2.nota_empresa+' - '+n2.nota_site) where dt.Localidade like '%%' group by dt.Localidade,dt.NOME,dt.VERSAO,n2.nota_empresa,n2.nota_site,n2.nota_quantidade";            //SqlCommand cmd = new SqlCommand(Str, con.cone());            //"SELECT software AS [Nome Software], versao AS Version, COUNT(software) AS [Quant] FROM software_csn GROUP BY versao, software";
            //"select dt.Localidade,dt.NOME as Software, dt.VERSAO as Versao,count(dt.NOME)  Instalados, (case when dt.Localidade = n2.nota_empresa+' - '+n2.nota_site then n2.nota_quantidade Else '0' End) as Adquiridos  from(select software as NOME, versao as VERSAO,Hostname, case when Hostname like 'CBS%' or Hostname like '%BVR%' then 'CSN - CBS - VOLTA REDONDA' when Hostname like '%BVO%' then 'CSN - CBS - Vila Olímpia Funchal' when Hostname like '%FFO%' then 'CSN - CFN - Fortaleza' when Hostname like '%IVR%' then 'CSN - CIMENTOS  - Volta Redonda' when Hostname like '%IAA%' then 'CSN - CIMENTOS  - Arará' when Hostname like '%IQU%' then 'CSN - CIMENTOS  - Queimados' when Hostname like '%ICU%' then 'CSN - CIMENTOS  - Capuava' when Hostname like '%ISJ%' then 'CSN - CIMENTOS  - São José dos Campos' when Hostname like '%IIB%' then 'CSN - CIMENTOS  - Itaboraí' when Hostname like '%EAQ%' then 'CSN - ERSA - Ariquemes' when Hostname like '%EIO%' then 'CSN - ERSA - Itapuã do Oeste' when Hostname like '%FVO%' then 'CSN - FUNDAÇÃO CSN - Vila Olímpia - Funchal' when Hostname like '%MMA%' then 'CSN - METALIC - Maracanaú' when Hostname like '%NCP%' then 'CSN - NAMISA - Casa de Pedra' when Hostname like '%NOP%' then 'CSN - NAMISA - Ouro Preto' when Hostname like '%NIR%' then 'CSN - NAMISA - Itabirito' when Hostname like '%NIG%' then 'CSN - NAMISA - Iguatemí' when Hostname like '%PMC%' then 'CSN - PRADA DISTRIBUIÇÃO - Mogi das Cruzes' when Hostname like '%PPI%' then 'CSN - PRADA DISTRIBUIÇÃO - Piracicaba' when Hostname like '%PCO%' then 'CSN - PRADA DISTRIBUIÇÃO - Contagem' when Hostname like '%PJF%' then 'CSN - PRADA DISTRIBUIÇÃO - Juiz de Fora' when Hostname like '%PBE%' then 'CSN - PRADA DISTRIBUIÇÃO - Bebedouro' when Hostname like '%PAU%' then 'CSN - PRADA DISTRIBUIÇÃO - Araucária' when Hostname like '%RSA%' then 'CSN - PRADA EMBALAGENS - Santo Amaro' when Hostname like '%RUB%' then 'CSN - PRADA EMBALAGENS - Uberlândia' when Hostname like '%TIT%' then 'CSN - TECON - Itaguaí' when Hostname like '%TSJ%' then 'CSN - TECON - São José' when Hostname like '%TVI%' then 'CSN - TECON - Visconde de Inhaúma' when Hostname like 'ARRE%' then 'CSN - PRADA - METALURGICA - RESENDE' when Hostname like 'ARLI%' then 'CSN - PRADA - METALURGICA - LINS' when Hostname like 'ARLU%' then 'CSN - PRADA - METALURGICA - LUZIANIA' when Hostname like 'ARPE%' then 'CSN - PRADA - METALURGICA - PELOTAS' when Hostname like 'GV%' or Hostname like '%CPO%' then 'CSN - PORTO REAL' when Hostname like '%CIT%' then 'CSN - Itaguaí' when Hostname like 'CP%' or Hostname like '%CCP%' then 'CSN - CASA DE PEDRA' when Hostname like 'AR0%' or Hostname like '%CAR%' then 'CSN - ARCOS' when Hostname like '%CFL%' then 'CSN - Faria Lima' when Hostname like '%CPA%' then 'CSN - Paraná' when Hostname like '%CMC%' then 'CSN - Mogi das Cruzes' when Hostname like '%CSA%' then 'CSN - Santo Amaro' when Hostname like '%CCA%' then 'CSN - Camaçari' when Hostname like '%CSJ%' then 'CSN - São José' when Hostname like '%CVO%' then 'CSN - Vila Olímpia - Funchal' when Hostname like '%CCO%' then 'CSN - Contagem' when Hostname like '%CMO%' then 'CSN - Mooca' when Hostname like '%CJV%' then 'CSN - Joinville' when Hostname like '%CGR%' then 'CSN - Gravataí' when Hostname like '%CCR%' then 'CSN - Criciúma' when Hostname like '%CJG%' then 'CSN - Jaboatão dos Guararapes' when Hostname like '%CCX%' then 'CSN - Caxias do Sul' when Hostname like '%CAU%' then 'CSN - Araucária' when Hostname like 'RS%' or Hostname like '%CCN%' then 'CSN - CANOAS' when Hostname like '%LFO%' then 'CSN - TLSA - Fortaleza' when Hostname like '%LRE%' then 'CSN - TLSA - Recife' when Hostname like '%LSL%' then 'CSN - TLSA - São Luiz' when Hostname like '%LTE%' then 'CSN - TLSA - Teresina' when Hostname like '%LMA%' then 'CSN - TLSA - Maracanaú' when Hostname like '%LCG%' then 'CSN - TLSA - Campina Grore' when Hostname like '%LCI%' then 'CSN - TLSA - Cinco Pontas' when Hostname like '%LCT%' then 'CSN - TLSA - Crateús' when Hostname like '%LCC%' then 'CSN - TLSA - Crato' when Hostname like '%LIU%' then 'CSN - TLSA - Iguatú' when Hostname like '%LIA%' then 'CSN - TLSA - Itabaiana' when Hostname like '%LIQ%' then 'CSN - TLSA - Itaquí' when Hostname like '%LIE%' then 'CSN - TLSA - Itararé' when Hostname like '%LJP%' then 'CSN - TLSA - João Pessoa' when Hostname like '%LJZ%' then 'CSN - TLSA - Juazeiro' when Hostname like '%LLA%' then 'CSN - TLSA - Lacerda' when Hostname like '%LMA%' then 'CSN - TLSA - Maceió' when Hostname like '%LMUC%' then 'CSN - TLSA - Mucuripe' when Hostname like '%LSB%' then 'CSN - TLSA - Sobral' when Hostname like '%LSZ%' then 'CSN - TLSA - Souza'  when Hostname like 'EX%' then 'TERCEIRO' when Hostname like 'N%' and Hostname not like 'NM%' then 'CSN - Servidor' when Hostname like 'ANRA%' then 'CSN - NAMISA - ITABIRITO - RIO ACIMA' when Hostname like 'ACVJ%' then 'CSN - JOINVILE' when Hostname like 'ANSP%' then 'CSN - NAMISA - SAO PAULO' when Hostname like 'PR%' or Hostname like 'APAC%' then 'CSN - ARAUCARIA'  when Hostname like 'BA%' then 'CSN - CAMACARI' when Hostname like 'CFFO%' then 'CSN - FTL - TERESINA' when Hostname like 'ER%' then 'CSN - ERSA - ARIQUEMES'  when Hostname like 'FE%' then 'CSN - CIMENTOS - VOLTA REDONDA' when Hostname like 'FU%' then 'CSN - FUNDACAO CSN - ESCOLA TECNICA PorIA CALOGERAS' when Hostname like 'HK%' then 'CSN - ASIA - HONG KONG' when Hostname like 'IN%' then 'CSN - PRADA - DISTRIBUICAO - MOGI DAS CRUZES' when Hostname like 'ME%' then 'CSN - METALIC - MARACANAU' when Hostname like 'ANOP%' or Hostname like 'NM%' then 'CSN - NAMISA - OURO PRETO' when Hostname like 'PD%' then 'CSN - PRADA - METALURGICA - SANTO AMARO' when Hostname like 'PE%' then 'CSN - JABOATAO DOS GUARARAPES' when Hostname like 'PO%' then 'CSN - ITAGUAI'  when Hostname like 'AU%' or Hostname like 'LU%' or Hostname like 'PT%' or  Hostname like 'ES%' then 'CSN - HANDEL - AUSTRIA' when Hostname like '%FVR%' or Hostname like 'VR%' or Hostname like 'AL0%' or Hostname like 'PVR%' or Hostname like '%CVR%' or hostname like 'BH%' or Hostname like 'TVR%' or Hostname like 'VVR%' then 'CSN - VOLTA REDONDA' when Hostname like 'RJ%' or Hostname like 'ACRJ%' then 'CSN - RIO DE JANEIRO' when Hostname like 'CDI%' then 'CSN - CDI' when Hostname like 'CI%' then 'CSN - VOLTA REDONDA' when Hostname like 'SC%' then 'CSN - CRICIUMA' when Hostname like 'SP%' then 'CSN - FARIA LIMA - SEDE' when Hostname like 'TE%' then 'CSN - SEPETIBA TECON - ITAGUAI' when Hostname like 'TL%' then 'CSN - TLSA - FORTALEZA'   End  Localidade   from software_csn where Hostname like '%%' and software like 'Microsoft Silverlight%' and versao like '5.1.41212.0%') dt full outer join notas as n2 on(dt.Localidade = n2.nota_empresa+' - '+n2.nota_site) where dt.Localidade like '%%' group by dt.Localidade,dt.NOME,dt.VERSAO,n2.nota_empresa,n2.nota_site,n2.nota_quantidade"            //SqlCommand cmd = new SqlCommand(Str, con.cone());            
            SqlDataAdapter da = new SqlDataAdapter(Str, con.cone());
            da.Fill(ds, "software_csn");
            dataGridView1.DataSource = ds.Tables["software_csn"];
            SqlDataReader sdr;
            SqlCommand cmd = new SqlCommand(Str, con.cone());
            cmd.CommandTimeout = 0;
            sdr = cmd.ExecuteReader();*/



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            fm.ActivateAllFilters(false);
        }

        progress2 pb = new progress2();
        void carrega_grid()
        {
            DataTable dt = new DataTable();
            string ver = "";
            string loc = "";
            string strquery = "";
            string strquery1 = "";
            //this.Refresh();Execute job 'Rel_Conformidade'

            //softwareBindingSource1.ResetBindings(true);
            Connection con = new Connection();
            //string Str = "select va.soft_nome as 'SOFTWARE PRODUCT',va.nota_tipo_lic AS 'TIPO LICENCA',va.categoria_lic as 'CATEGORIA LICENCA',va.nota_empresa AS 'EMPRESA',va.nota_site AS 'SITE',va.nota_quantidade AS 'COMPRADOS',va.Instalados AS 'INSTALADOS', va.nota_quantidade - va.Instalados as 'CONFORMIDADE' from(Select s.soft_nome ,n.nota_tipo_lic ,n.categoria_lic ,n.nota_quantidade, COUNT(ds.software) as 'Instalados',n.nota_empresa,n.nota_site from software_csn ds join software s on (s.soft_nome = ds.software and s.soft_versao = ds.versao) join notas n on (s.soft_id = n.fk_soft_id) group by s.soft_nome,n.nota_tipo_lic,n.categoria_lic,n.nota_quantidade,n.nota_empresa,n.nota_site) va";
            String Str = "SELECT  DT.[SOFTWARE PRODUCT],DT.[TIPO LICENCIAMENTO],DT.COMPRADAS,DT.INSTALADOS, DT.COMPRADAS-DT.INSTALADOS AS 'CONFORMIDADE' FROM v_Comp_Inst AS DT ORDER BY DT.[SOFTWARE PRODUCT]";

            SqlCommand cmd = new SqlCommand(Str, con.cone());
            cmd.CommandTimeout = 0;
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;

        }
        void carrega_grid_site()
        {
            DataTable dt = new DataTable();
            string ver = "";
            string loc = "";
            string strquery = "";
            string strquery1 = "";
            //this.Refresh();

            //softwareBindingSource1.ResetBindings(true);
            Connection con = new Connection();
            string Str = "SELECT     C.soft_nome AS [SOFTWARE PRODUCT], C.nota_tipo_lic AS [TIPO LICENCIAMENTO], C.nota_site AS SITE, C.nota_empresa AS EMPRESA, C.Compradas FROM         dbo.v_QTD_Compradas_empresa AS C  ";
            SqlCommand cmd = new SqlCommand(Str, con.cone());
            cmd.CommandTimeout = 0;
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;

        }

        void carrega_grid_categoria()
        {
            DataTable dt = new DataTable();
            string ver = "";
            string loc = "";
            string strquery = "";
            string strquery1 = "";
            //this.Refresh();

            //softwareBindingSource1.ResetBindings(true);
            Connection con = new Connection();
            string Str = "SELECT DT.[CATEGORIA LICENCIAMENTO], DT.[SOFTWARE PRODUCT],DT.COMPRADOS,DT.INSTALADOS, DT.COMPRADOS-DT.INSTALADOS AS 'CONFORMIDADE' FROM v_Comp_Inst_CatLic AS DT ORDER BY DT.[SOFTWARE PRODUCT]";
            SqlCommand cmd = new SqlCommand(Str, con.cone());
            cmd.CommandTimeout = 0;
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;

        }


        void carrega_grid_empresa()
        {
            DataTable dt = new DataTable();
            string ver = "";
            string loc = "";
            string strquery = "";
            string strquery1 = "";
            //this.Refresh();

            //softwareBindingSource1.ResetBindings(true);
            Connection con = new Connection();
            string Str = "select empresa AS 'EMPRESA', software_product as 'SOFTWARE PRODUCT',tipo_licenca AS 'TIPO DE LICENCA',comprado AS 'COMPRADOS',instalado AS 'INSTALADOS',conformidade AS 'CONFORMIDADE' from relatorio_conformidade";
            SqlCommand cmd = new SqlCommand(Str, con.cone());
            cmd.CommandTimeout = 0;
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;

        }

        [STAThread]

        private void button3_Click(object sender, EventArgs e)
        {
            Thread grid = new Thread(prog);
            grid.Start();
            carrega_grid();
            grid.Abort();
            //MessageBox.Show("Testes");



        }
        void prog()
        {
            pb.ShowDialog();
        }



        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ExtractDataToCSV(dataGridView1);
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

        private void label5_Click(object sender, EventArgs e)
        {
            Thread grid = new Thread(prog);
            grid.Start();
            carrega_grid_site();
            grid.Abort();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Thread grid = new Thread(prog);
            grid.Start();
            carrega_grid();
            grid.Abort();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Thread grid = new Thread(prog);
            grid.Start();
            carrega_grid_categoria();
            grid.Abort();
        }

        private void CCCC_Click(object sender, EventArgs e)
        {
            String dec = File.ReadLines(Directory.GetCurrentDirectory() + "\\config.cfg").ElementAt(2);
            if (dec == "0")
            {
                MessageBox.Show(null, "Report Server não disponivel!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                System.Diagnostics.Process.Start("cmd", "/c start " + dec);
            }
        }

    }
}
