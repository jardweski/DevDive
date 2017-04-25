using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevDive.Register.Analises;
using DevDive.Register.Produtos;

namespace DevDive.Register.ProdutosAnalises
{
    public partial class FormProdutoAnalises : Form
    {
        private readonly ControleAnalise _analiseControl;
        private readonly ProdutoControle _produtoControl;
        private BindingList<Analise> _analises;
        private BindingList<ProdutoAnalise> _produtosAnalises;

        public FormProdutoAnalises(SqlConnection getData, SqlConnection getIgdData)
        {
            InitializeComponent();

            _produtoControl = new ProdutoControle(getData, getIgdData);
            _analiseControl = new ControleAnalise(getData);

            _produtosAnalises = new BindingList<ProdutoAnalise>();

            CarrregarAnalises();

            CarregarProdutosCompostos();
        }

        private void CarrregarAnalises()
        {
            _analises = _analiseControl.GetList();

            FormatarGrid(AnalisesDataGridView, ETipoFormatGrid.Analise, _analises);
        }

        private void CarregarProdutosCompostos()
        {
            FormatarGrid(produtosCompostosDataGridView, ETipoFormatGrid.ProdutoComposto,
                new BindingList<ProdutoComposicao>(_produtoControl.GetListProductCompound().ToList()));
        }

        private void produtosCompostosDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _produtosAnalises = new BindingList<ProdutoAnalise>();
                CarregarProdutoAnalise();
                _analises = new BindingList<Analise>();
                CarrregarAnalises();

                produtosCompostosDataGridView.Rows[e.RowIndex].Selected = true;

                var produtoComposicao =
                    (ProdutoComposicao) produtosCompostosDataGridView.Rows[e.RowIndex].DataBoundItem;
                if (produtoComposicao != null)
                    ObterProdutoAnalise(produtoComposicao.Id);
            }
        }

        private void ObterProdutoAnalise(int idProdutoComposto)
        {
            var analisesProdutos = _produtoControl.GetAnalisysProduct(idProdutoComposto);

            if (analisesProdutos != null && analisesProdutos.Any())
                foreach (var AnalisesProduto in analisesProdutos)
                foreach (DataGridViewRow dataGridViewRow in AnalisesDataGridView.Rows)
                    if (((Analise) dataGridViewRow.DataBoundItem).Id == AnalisesProduto.IdAnalise)
                        ValidaAdicionaAnalise(dataGridViewRow.Index, AnalisesProduto);
        }

        private void AnalisesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ValidaAdicionaAnalise(e.RowIndex, null);
        }

        private void ValidaAdicionaAnalise(int rowIndex, ProdutoAnalise AnalisesProduto)
        {
            if (rowIndex >= 0)
            {
                var analise = (Analise) AnalisesDataGridView.Rows[rowIndex].DataBoundItem;

                var produtoComposto = (ProdutoComposicao) produtosCompostosDataGridView.SelectedRows[0].DataBoundItem;

                if (produtoComposto == null)
                    return;

                if (analise != null)
                    AdicionarAnaliseProduto(analise, produtoComposto.Id);
            }
        }

        private void AdicionarAnaliseProduto(Analise Analise, int idProdutoComposto)
        {
            _produtosAnalises.Add(new ProdutoAnalise(idProdutoComposto)
            {
                IdAnalise = (int) Analise.Id,
                DescricaoAnalise = Analise.Descricao
            });

            _analises.Remove(Analise);

            CarregarProdutoAnalise();
            RecarregarGrids();
        }

        private void RecarregarGrids()
        {
            FormatarGrid(AnalisesDataGridView, ETipoFormatGrid.Analise, _analises);
            FormatarGrid(produtoAnaliseDataGridView, ETipoFormatGrid.ProdutoAnalise, _produtosAnalises);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AnalisesDataGridView.SelectedRows.Count > 0)
                ValidaAdicionaAnalise(AnalisesDataGridView.SelectedRows[0].Index, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (produtoAnaliseDataGridView.SelectedRows.Count > 0)
                ValidaRemoveAnalise(produtoAnaliseDataGridView.SelectedRows[0].Index);
        }

        private void ValidaRemoveAnalise(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                var produtoAnalise = (ProdutoAnalise) produtoAnaliseDataGridView.Rows[rowIndex].DataBoundItem;

                var produtoComposto = (ProdutoComposicao) produtosCompostosDataGridView.SelectedRows[0].DataBoundItem;

                if (produtoComposto == null)
                    return;

                if (produtoAnalise != null)
                    RemoverAnaliseProduto(produtoAnalise);
                RecarregarGrids();
            }
        }

        private void RemoverAnaliseProduto(ProdutoAnalise produtoAnalise)
        {
            _produtosAnalises.Remove(produtoAnalise);

            _analises.Add(new Analise
            {
                Id = produtoAnalise.IdAnalise,
                Descricao = produtoAnalise.DescricaoAnalise
            });


            CarregarProdutoAnalise();
        }

        private void CarregarProdutoAnalise()
        {
            FormatarGrid(produtoAnaliseDataGridView, ETipoFormatGrid.Analise,
                new BindingList<ProdutoAnalise>(_produtosAnalises));
        }

        private void FormatarGrid<T>(DataGridView dataGridView, ETipoFormatGrid tipo, BindingList<T> dataSource)
        {
            switch (tipo)
            {
                case ETipoFormatGrid.ProdutoAnalise:
                    produtoAnaliseDataGridView.DataSource = dataSource;
                    break;
                case ETipoFormatGrid.Analise:
                    AnalisesDataGridView.DataSource = dataSource;
                    break;
                case ETipoFormatGrid.ProdutoComposto:
                    produtosCompostosDataGridView.DataSource = dataSource;
                    break;
            }


            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoResizeColumns();
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.ResetBindings();
            dataGridView.Refresh();
        }

        private void adicionarAnaliseToolStripButton_Click(object sender, EventArgs e)
        {
            SalvarAnaliseProduto();
        }

        private void SalvarAnaliseProduto()
        {
            var idProduto = ((ProdutoComposicao) produtosCompostosDataGridView.SelectedRows[0].DataBoundItem).Id;

            var retorno = _produtoControl.SaveAnalisysProduct(idProduto, _produtosAnalises);

            if (retorno.Sucess)
                MessageBox.Show(retorno.Message);
            else
                foreach (var error in retorno.Errors)
                    MessageBox.Show(error);
        }
    }
}