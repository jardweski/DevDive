using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MP.Reporting.WinForms;

namespace DevDive.Production
{
    public partial class FormManagerRequisitions : Form
    {
        private readonly ProductionController _controle;

        private ReportModuleProduction _reportModule;
        private ReportControl _reportControl;

        public FormManagerRequisitions(SqlConnection getData, SqlConnection getIgdData)
        {
            InitializeComponent();

            _controle = new ProductionController(getData, getIgdData);

            _reportModule = ReportModuleProduction.GetInstance();
            _reportControl = new MP.Reporting.WinForms.ReportControl();
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            ordersDataGridView.DataSource = null;
            ordersDataGridView.DataSource = _controle.GetList();

            var dataGridViewColumn1 = ordersDataGridView.Columns["Situacao"];
            if (dataGridViewColumn1 != null)
                dataGridViewColumn1.Visible = false;

            var dataGridViewColumn2 = ordersDataGridView.Columns["SituacaoDescricao"];
            if (dataGridViewColumn2 != null)
                dataGridViewColumn2.HeaderText = "Situação";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var ordemProducao = (ProductionOrder)ordersDataGridView.Rows[e.RowIndex].DataBoundItem;
                
                if (ordemProducao == null)
                {
                    return;
                }

                if (ordemProducao != null)
                {
                    ExibirOrdemProducao(ordemProducao);
                }
            }
        }

        private void ExibirOrdemProducao(ProductionOrder ordemProducao)
        {
            var orderForm = new FormOrderStarter(ordemProducao,_controle);
            if (orderForm.ShowDialog() == DialogResult.Yes)
            {
                CarregarGrid();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ordersDataGridView.CurrentRow != null)
            {
                var ordemProducao = (ProductionOrder)ordersDataGridView.CurrentRow.DataBoundItem;

                if (ordemProducao == null)
                {
                    return;
                }

                if (ordemProducao != null)
                {
                    ExibirOrdemProducao(ordemProducao);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Relatório da ordem de produção
            if(ordersDataGridView.CurrentRow != null)
            {
                var pedido = (ProductionOrder)ordersDataGridView.CurrentRow.DataBoundItem;
                _reportModule.ReportParameter.SetVariableValue("IdOP", pedido.Id);
                _reportControl.Load(23);
                _reportControl.SetReportParameters(_reportModule.ReportParameter);
                _reportControl.ViewReport(this);

                ////Relatório de previsão de estoque
                //var f = new MP.Reporting.WinForms.FormReports(_reportModule.ReportParameter);
                //f.Show();
            }
        }
    }
}