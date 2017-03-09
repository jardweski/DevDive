using System.Configuration;
using System.Data.SqlClient;
using DevDive.Production;
using DevDive.Register.Processos;
using DevDive.Register.ProdutosProcessos;

namespace DevDive.Main
{
    public class DevControl
    {
        public static SqlConnection GetData()
        {
            return
                new SqlConnection(@"Server=" +
                                  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                                      .AppSettings.Settings["Servidor"].Value + ";Database=" +
                                  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                                      .AppSettings.Settings["Banco"].Value + ";User Id=sa;Password = Plx7fhsd89; ");
        }

        public static SqlConnection GetIgdData()
        {
            return
                new SqlConnection(@"Server=" +
                                  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                                      .AppSettings.Settings["Servidor"].Value +
                                  ";Database=igd;User Id=sa;Password = Plx7fhsd89; ");
        }

        public static void OpenForm(EFormType type)
        {
            switch (type)
            {
                case EFormType.Process:
                    var formProcess = new FormProcessos(GetData());
                    formProcess.Show();
                    break;
                case EFormType.ProductProcess:
                    var formProductProcess = new FormProdutoProcessos(GetData(), GetIgdData());
                    formProductProcess.Show();
                    break;
                case EFormType.ProcessMonitor:
                    var formProcessMonitor = new FormManagerRequisitions(GetData(), GetIgdData());
                    formProcessMonitor.Show();
                    break;
                case EFormType.OrdersMonitor:
                    var formOrdersMonitor = new FormManagerOrders(GetData(), GetIgdData());
                    formOrdersMonitor.Show();
                    break;
            }
        }
    }
}