using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MP.Reporting.WinForms;
using MP.Forms;

namespace DevDive.Production
{
    public partial class FormManagerOrders : Form
    {
        private readonly ProductionController _controle;
        private ReportModuleProduction _reportModule;
        private ReportControl _reportControl;

        public FormManagerOrders(SqlConnection getData, SqlConnection getIgdData)
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
            ordersDataGridView.DataSource = _controle.GetListOrders();
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
                var pedido = (Orders)ordersDataGridView.Rows[e.RowIndex].DataBoundItem;
                
                if (pedido == null)
                {
                    return;
                }

                if (pedido != null && pedido.IdOrdemProducao==null && pedido.NumeroNF=="")
                {
                    if (
                        MessageBox.Show(this, "Gerar ordem de produção ?", "Aviso", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var retorno = _controle.CreateProductionOrder(pedido.IdPedido);

                        if (retorno.Sucess)
                        {
                            CarregarGrid();
                        }
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ordersDataGridView.CurrentRow != null)
            {
                var pedido = (Orders)ordersDataGridView.CurrentRow.DataBoundItem;

                if (pedido == null)
                {
                    return;
                }

                if (pedido != null && pedido.IdOrdemProducao == null && pedido.NumeroNF == "")
                {
                    if (
                        MessageBox.Show(this, "Gerar ordem de produção ?", "Aviso", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var retorno = _controle.CreateProductionOrder(pedido.IdPedido);

                        if (retorno.Sucess)
                        {
                            CarregarGrid();
                        }

                    }

                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (ordersDataGridView.CurrentRow != null)
            {
                var pedido = (Orders) ordersDataGridView.CurrentRow.DataBoundItem;
                _reportModule.ReportParameter.SetVariableValue("IdOP", pedido.IdPedido);
                _reportControl.Load(24);
                _reportControl.SetReportParameters(_reportModule.ReportParameter);
                _reportControl.ViewReport(this);

                ////Relatório de previsão de estoque
                //var f = new MP.Reporting.WinForms.FormReports(_reportModule.ReportParameter);
                //f.Show();
            }

        }
    }
}