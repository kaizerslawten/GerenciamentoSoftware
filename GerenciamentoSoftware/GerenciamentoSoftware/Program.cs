using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;

namespace GerenciamentoSoftware
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new frmGerenciamento());
                if (args[0] == "admin")
                {
                    configurar con = new configurar();
                    con.ShowDialog();//Process.Start(Directory.GetCurrentDirectory() + "\\config.exe");
                }

            }
            catch (System.IndexOutOfRangeException ex)
            {
                Application.Run(new TelaLogin());
                //Application.Run(new relaciona_notas());
                //Application.Run(new frmGerenciamento());
                //Application.Run(new CadastroNota());
                //Application.Run(new LocalidadesCadastradas());

            }
            //Application.Run(new CadastroNota());
            //Application.Run(new cadusers.cadusers1());
            //Application.Run(new UsuarioCadastrados());
            //Application.Run(new FornecedoresCadastrados());
            //Application.Run(new Relatorios.consulta_equipamento());
            //Application.Run(new update.atualiza_nota());

        }
    }
}
