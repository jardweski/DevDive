using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevDive.Register.Analises;
using DevDive.Register.Certificado.DadosDeProdutos;
using DevDive.Register.Produtos;

namespace DevDive.Register.Certificado.Impressao
{
    public partial class FormCertificadoImpressao : Form
    {
        private readonly CertificadoControle _certificadoControle;
        private BindingList<ResultadoAnalise> _resultados;
        private ControleAnalise _analiseControl;

        public FormCertificadoImpressao(SqlConnection getData, SqlConnection getIgdData)
        {
            InitializeComponent();

            _certificadoControle = new CertificadoControle(getData, getIgdData);
            _analiseControl = new ControleAnalise(getData);
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

            var produto =
                (ProdutosPedido)produtosDataGridView.Rows[e.RowIndex].DataBoundItem;
            if (produto != null)
                _resultados = _certificadoControle.GetAnaliseResult(produto.IdProduto,produto.IdSerie,produto.IdPedido);

            FormatarGrid(resultadosDataGridView, ETipoFormatGrid.ResultadoAnalise, _resultados);
        }

        private void CarregarAnalises()
        {
            
        }

        private void adicionarProcessoToolStripButton_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
           //_certificadoControle.SaveProductSerieCertificate(RepassarValores(serie.Id));
        }

        private SerieCertificado RepassarValores(int serieId)
        {

            return new SerieCertificado();
        }
    }
}