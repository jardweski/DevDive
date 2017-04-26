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
        private readonly ProdutoControle _produtoControl;
        private BindingList<Serie> _series;
        private ControleAnalise _analiseControl;

        public FormCertificadoImpressao(SqlConnection getData, SqlConnection getIgdData)
        {
            InitializeComponent();

            _produtoControl = new ProdutoControle(getData, getIgdData);
            _analiseControl = new ControleAnalise(getData);
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            FormatarGrid(produtosDataGridView, ETipoFormatGrid.ProdutoComposto,
                new BindingList<ProdutoComposicao>(_produtoControl.GetListProductCompound().ToList()));
        }

        private void FormatarGrid<T>(DataGridView dataGridView, ETipoFormatGrid tipo, BindingList<T> dataSource)
        {
            switch (tipo)
            {
                case ETipoFormatGrid.ProdutoComposto:
                    produtosDataGridView.DataSource = dataSource;
                    break;
                case ETipoFormatGrid.ProdutosSerie:
                    seriesDataGridView.DataSource = dataSource;
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
                (ProdutoComposicao) produtosDataGridView.Rows[e.RowIndex].DataBoundItem;
            if (produto != null)
                _series = _produtoControl.GetSeriesProduct(produto.Id);

            FormatarGrid(seriesDataGridView, ETipoFormatGrid.ProdutosSerie, _series);
        }

        private void seriesDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var serie =
                (Serie) seriesDataGridView.Rows[e.RowIndex].DataBoundItem;
            if (serie != null)
                CarregarAnalises(_analiseControl.GetAnalisys(serie.Id));
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
            if (seriesDataGridView.CurrentRow.Index < 0)
                return;
            var serie =
                (Serie) seriesDataGridView.CurrentRow.DataBoundItem;
            _produtoControl.SaveProductSerieCertificate(RepassarValores(serie.Id));
        }

        private SerieCertificado RepassarValores(int serieId)
        {
            var serieCertificado = new SerieCertificado
            {
                Code = CodetextBox.Text,
                Batch = batchtextBox.Text,
                BotanicalSource = botanicaltextBox.Text,
                Family = familytextBox.Text,
                Origin = origintextBox.Text,
                HarvestRegion = harvesttextBox.Text,
                UsedPart = userdparttextBox.Text,
                Preservative = preservativetextBox.Text,
                Colorant = coloranttextBox.Text,
                Solvent = solventtextBox.Text,
                Carrier = carriertextBox.Text,
                DryResidue = drytextBox.Text,
                Ratio = ratiotextBox.Text,
                Irradiation = irradiationtextBox.Text,
                GMO = gmotextBox.Text,
                BSE = bsetextBox.Text,
                IdSerie = serieId
            };

            return serieCertificado;
        }
    }
}