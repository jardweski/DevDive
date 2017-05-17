using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevDive.Register.Analises;
using DevDive.Register.Certificado.DadosDeProdutos;
using DevDive.Register.Produtos;
using MP.Reporting.WinForms;

namespace DevDive.Register.Certificado.Impressao
{
    public partial class FormCertificadoImpressao : Form
    {
        private readonly CertificadoControle _certificadoControle;
        private BindingList<ResultadoAnalise> _resultados;
        private ReportModuleCertificado _reportModule;
        private ReportControl _reportControl;

        public FormCertificadoImpressao(SqlConnection getData, SqlConnection getIgdData)
        {
            InitializeComponent();

            _reportModule = ReportModuleCertificado.GetInstance();
            _reportControl = new MP.Reporting.WinForms.ReportControl();
            _certificadoControle = new CertificadoControle(getData, getIgdData);
            CarregarProdutosPedidos();
        }

        private void CarregarProdutosPedidos()
        {
            FormatarGrid(produtosDataGridView, ETipoFormatGrid.ProdutoPedido,
                new BindingList<ProdutosPedido>(_certificadoControle.GetProdutosPedidos().ToList()));
        }

        private void FormatarGrid<T>(DataGridView dataGridView, ETipoFormatGrid tipo, BindingList<T> dataSource)
        {
            switch (tipo)
            {
                case ETipoFormatGrid.ProdutoPedido:
                    produtosDataGridView.DataSource = dataSource;
                    break;
                    case ETipoFormatGrid.ResultadoAnalise:
                        resultadosDataGridView.DataSource = dataSource;
                    break;

            }


            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoResizeColumns();
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.ResetBindings();
            dataGridView.Refresh();
        }

        private void produtosDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            CarregarResultados(e.RowIndex);
        }

        private void CarregarResultados(int index)
        {
            var produto =
                (ProdutosPedido) produtosDataGridView.Rows[index].DataBoundItem;
            if (produto != null)
                _resultados = _certificadoControle.GetAnaliseResult(produto.IdProduto, produto.IdSerie, produto.IdPedido);

            FormatarGrid(resultadosDataGridView, ETipoFormatGrid.ResultadoAnalise, _resultados);
        }


        private void adicionarProcessoToolStripButton_Click(object sender, EventArgs e)
        {
            Salvar();
            if (produtosDataGridView.CurrentRow != null)
                CarregarResultados(produtosDataGridView.CurrentRow.Index);
        }

        private void Salvar()
        {
            var resultados = ((BindingList<ResultadoAnalise>) resultadosDataGridView.DataSource);

            if (resultados.Any(p=>string.IsNullOrEmpty(p.Resultado)))
            {
                return;
            }

            _certificadoControle.SaveResultado(resultados);
        }

        private SerieCertificado RepassarValores(int serieId)
        {

            return new SerieCertificado();
        }

        private void resultadosDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (resultadosDataGridView.Columns[e.ColumnIndex].Name != "Resultado" )
            {
                e.Cancel = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (produtosDataGridView.CurrentRow != null)
            {
                var resultados = ((BindingList<ResultadoAnalise>)resultadosDataGridView.DataSource);
                var resultadosString = resultados.Aggregate("",
                    (current, item) => current + (item.Id.ToString() + ","));

                _reportModule.ReportParameter.SetVariableValue("IdsResultados", resultadosString);
                _reportControl.Load(38);
                _reportControl.SetReportParameters(_reportModule.ReportParameter);
                _reportControl.ViewReport(this);
                
            }
        }
    }
}