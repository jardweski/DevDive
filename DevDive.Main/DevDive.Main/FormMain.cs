using System;
using System.Configuration;
using System.Windows.Forms;

namespace DevDive.Main
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            var config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var conf = new FormConfig())
                conf.ShowDialog(this);
        }

        private void processosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevControl.OpenForm(EFormType.Process);
        }

        private void vinculoDeProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevControl.OpenForm(EFormType.ProductProcess);
        }

        private void monitorarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevControl.OpenForm(EFormType.ProcessMonitor);
        }

        private void acompanharPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevControl.OpenForm(EFormType.OrdersMonitor);
        }

        private void produçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevControl.OpenForm(EFormType.Analisys);
        }

        private void vinculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevControl.OpenForm(EFormType.ProductAnalisys);
        }
    }
}