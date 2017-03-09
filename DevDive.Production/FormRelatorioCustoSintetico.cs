using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevDive.Production;

namespace DevDive.Main
{
    public partial class FormRelatorioCustoSintetico : Form
    {

        private ReportModuleOrdemProducaoCost _reportModule;
        private MP.Reporting.WinForms.ReportControl _reportControl;

        public FormRelatorioCustoSintetico()
        {
            InitializeComponent();
            _reportModule = ReportModuleOrdemProducaoCost.GetInstance();
            _reportControl = new MP.Reporting.WinForms.ReportControl();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _reportModule.ReportParameter.SetVariableValue("DataInicial", Convert.ToDateTime(textBox1.Text));
            _reportModule.ReportParameter.SetVariableValue("DataFinal",Convert.ToDateTime(textBox2.Text));
            _reportControl.Load(19);
            _reportControl.SetReportParameters(_reportModule.ReportParameter);
            _reportControl.ViewReport(this);
        }
    }
}
