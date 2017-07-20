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

//Extras
using System.Data.SqlClient;

namespace GerenciamentoSoftware
{

    public class Connection
    {
        string deco()
        {
            String dec = "";

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "\\config.cfg");
                byte[] b = (Convert.FromBase64String(file.ReadLine()));
                dec = Encoding.UTF8.GetString(b);
                return dec;
            }
            catch (System.IO.FileNotFoundException ex)
            {

                if (MessageBox.Show(null, "Arquivo de dados inexistente, deseja configura-lo agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    configurar con = new configurar();
                    con.ShowDialog();
                }
                else
                {

                }
                return dec;
            }
        }
        public SqlConnection cone()
        {
            //SqlCeConnection con = new SqlCeConnection("Data Source =C:\\Users\\Tivit\\Documents\\Visual Studio 2012\\Projects\\GerenciamentoSoftware\\GerenciamentoSoftware\\TSM.sdf;");
            //SqlCeConnection con = new SqlCeConnection("Data Source = TSM.sdf;");
            //SqlConnection con = new SqlConnection("Server=nspt01; Initial Catalog=TSM;User Id=sa; Password=TVT@ltiris#");
            SqlConnection con = new SqlConnection(deco());
            //SqlConnection con = new SqlConnection("Server=localhost\\MSSQLSERVER_EXPR; Initial Catalog=TSM;User Id=sa; Password=Tivit123");
            con.Open();
            return con;
        }


    }
}
