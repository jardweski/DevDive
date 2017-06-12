using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevDive.Register.Certificado.DadosDeProdutos;
using DevDive.Register.Produtos;
using MP.Reporting.WinForms;

namespace DevDive.Register.Certificado.Impressao
{
    public partial class FormCertificadoImpressao : Form
    {
        private readonly CertificadoControle _certificadoControle;
        private readonly ReportControl _reportControl;
        private readonly ReportModuleCertificado _reportModule;
        private BindingList<ResultadoAnalise> _resultados;
        private ProdutoControle _produtoControl;

        public FormCertificadoImpressao(SqlConnection getData, SqlConnection getIgdData)
        {
            InitializeComponent();

            _reportModule = ReportModuleCertificado.GetInstance();
            _reportControl = new ReportControl();
            _certificadoControle = new CertificadoControle(getData, getIgdData);
            _produtoControl = new ProdutoControle(getData,getIgdData);
            CarregarProdutosPedidos();
        }

        private void CarregarProdutosPedidos()
        {
            FormatarGrid(produtosDataGridView, ETipoFormatGrid.ProdutoPedido,
                new BindingList<ProdutosPedido>(_certificadoControle.GetProdutosPedidos().ToList()));
        }

        private void FormatarGrid<T>(DataGridView dataGridView, ETipoFormatGrid tipo, BindingList<T> dataSource)
        {
            dataGridView.DataSource = dataSource;
            switch (tipo)
            {
                case ETipoFormatGrid.ProdutoPedido:
                    foreach (DataGridViewColumn coluna in produtosDataGridView.Columns)
                    {
                        if (coluna.Name.Contains("IdProduto") ||
                            coluna.Name.Contains("IdSerie"))
                            coluna.Visible = false;
                        if (coluna.Name.Contains("IdOrdemProducao"))
                            coluna.HeaderText = @"OP";
                        if (coluna.Name.Contains("IdPedidoDeVenda"))
                            coluna.HeaderText = @"PV";
                    }
                    break;
                case ETipoFormatGrid.ResultadoAnalise:
                    foreach (DataGridViewColumn coluna in resultadosDataGridView.Columns)
                    {
                        if (coluna.Name.Equals("IdPedido") ||
                            coluna.Name.Equals("IdSerie") ||
                            coluna.Name.Equals("Id"))
                            coluna.Visible = false;
                    }
                    break;
                case ETipoFormatGrid.AnaliseSerie:
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    currencyManager1.SuspendBinding();
                    foreach (DataGridViewRow linha in dataGridView1.Rows)
                    {
                        if (((SerieCertificado)linha.DataBoundItem).Info == "Id" ||
                            ((SerieCertificado)linha.DataBoundItem).Info == "IdSerie" ||
                            ((SerieCertificado)linha.DataBoundItem).Info == "Batch")
                        {   
                            linha.Visible = false;
                        }
                    }
                    currencyManager1.ResumeBinding();

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
            CarregarDados(e.RowIndex);
        }

        private void CarregarDados(int index)
        {
            var produto =
                (ProdutosPedido)produtosDataGridView.Rows[index].DataBoundItem;
            if (produto != null)
            {
                var teste = _produtoControl.GetSeriesCertificate((int)produto.IdSerie);
                FormatarGrid(dataGridView1,ETipoFormatGrid.AnaliseSerie,teste );
            }

            
        }

        private void CarregarResultados(int index)
        {
            var produto =
                (ProdutosPedido) produtosDataGridView.Rows[index].DataBoundItem;
            if (produto != null)
                _resultados =
                    _certificadoControle.GetAnaliseResult(produto.IdProduto, produto.IdSerie, produto.IdPedido);

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
            if (produtosDataGridView.CurrentRow != null)
            {
                var resultados = (BindingList<ResultadoAnalise>) resultadosDataGridView.DataSource;

                var dados = (BindingList<SerieCertificado>) dataGridView1.DataSource;

                var produto =
                    (ProdutosPedido)produtosDataGridView.CurrentRow.DataBoundItem;

                _certificadoControle.SaveResultado(produto, resultados.Where(p => !string.IsNullOrEmpty(p.Resultado)),dados);
            }
        }

        private SerieCertificado RepassarValores(int serieId)
        {
            return new SerieCertificado();
        }

        private void resultadosDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (resultadosDataGridView.Columns[e.ColumnIndex].Name != "Resultado")
                e.Cancel = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (produtosDataGridView.CurrentRow != null)
            {
                var resultados = (BindingList<ResultadoAnalise>) resultadosDataGridView.DataSource;
                var resultadosString = resultados.Where(p=>!string.IsNullOrEmpty(p.Resultado)).Aggregate("",
                    (current, item) => current + item.Id.ToString() + ",");

                _reportModule.ReportParameter.SetVariableValue("IdsResultados", resultadosString.Substring(0,resultadosString.Length-1));
                _reportControl.Load(38);
                _reportControl.SetReportParameters(_reportModule.ReportParameter);
                _reportControl.ViewReport(this);
            }
        }
    }
}