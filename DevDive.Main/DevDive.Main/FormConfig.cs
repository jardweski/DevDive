using System;
using System.Configuration;
using System.Windows.Forms;

namespace DevDive.Main
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            CarregarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            var config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            servidorTextBox.Text = config.AppSettings.Settings["Servidor"].Value;
            bancoTextBox.Text = config.AppSettings.Settings["Banco"].Value;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SalvarConfiguracoes();
        }

        private void SalvarConfiguracoes()
        {
            var config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Banco"].Value = bancoTextBox.Text;
            config.AppSettings.Settings["Servidor"].Value = servidorTextBox.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void servidorTextBox_Validated(object sender, EventArgs e)
        {
            SalvarConfiguracoes();
        }

        private void bancoTextBox_Validated(object sender, EventArgs e)
        {
            SalvarConfiguracoes();
        }
    }
}