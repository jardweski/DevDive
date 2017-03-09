using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DevDive.Register;
using DevDive.Register.Processos;
using DevDive.Register.ProdutosProcessos;

namespace DevDive.CrossCutting
{
    public class DevControl
    {
        public static SqlConnection GetData()
        {
            return
                new SqlConnection(@"Server=" + ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["Servidor"].Value + ";Database=" +
                                  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["Banco"].Value + ";User Id=sa;Password = Plx7fhsd89; ");
        }

        public static SqlConnection GetIgdData()
        {
            return new SqlConnection(@"Server=" + ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["Servidor"].Value + ";Database=igd;User Id=sa;Password = Plx7fhsd89; ");
        }

        public static void OpenForm(EFormType type)
        {
            switch (type)
            {
                case EFormType.Process:
                    var formProcess = new FormProcessos();
                    formProcess.ShowDialog();
                    break;
                case EFormType.ProductProcess:
                    var formProductProcess = new FormProdutoProcessos();
                    formProductProcess.ShowDialog();
                    break;
            }
        }
    }
}
