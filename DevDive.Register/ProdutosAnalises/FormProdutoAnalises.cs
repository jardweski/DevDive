using System;
using System.Collections.Generic;
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

                RecarregarGrids();
            }
        }

        private void ObterProdutoAnalise(int idProdutoComposto)
        {
            var analisesProdutos = _produtoControl.GetAnalisysProduct(idProdutoComposto);

            if (analisesProdutos != null)
            {
                var produtoAnalises = analisesProdutos as IList<ProdutoAnalise> ?? analisesProdutos.ToList();

                if (!produtoAnalises.Any())
                    return;

                foreach (var analisesProduto in produtoAnalises)
                foreach (DataGridViewRow dataGridViewRow in AnalisesDataGridView.Rows)
                    if (((Analise) dataGridViewRow.DataBoundItem).Id == analisesProduto.IdAnalise)
                        ValidaAdicionaAnalise(dataGridViewRow.Index);
            }
        }

        private void AnalisesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ValidaAdicionaAnalise(e.RowIndex);
        }

        private void ValidaAdicionaAnalise(int rowIndex)
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

        private void AdicionarAnaliseProduto(Analise analise, int idProdutoComposto)
        {
            if (analise.Id != null)
                _produtosAnalises.Add(new ProdutoAnalise(idProdutoComposto)
                {
                    IdAnalise = (int) analise.Id,
                    DescricaoAnalise = analise.Descricao,
                    Especificacao = analise.Especificacao,
                    Tipo = analise.Tipo,
                    Metodo = analise.Metodo
                });

            _analises.Remove(analise);

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
                ValidaAdicionaAnalise(AnalisesDataGridView.SelectedRows[0].Index);
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
                    foreach (DataGridViewColumn coluna in produtoAnaliseDataGridView.Columns)
                        if (coluna.Name.Contains("Id") || coluna.Name.Contains("Resultado"))
                            coluna.Visible = false;
                    break;
                case ETipoFormatGrid.Analise:
                    AnalisesDataGridView.DataSource = dataSource;
                    foreach (DataGridViewColumn coluna in AnalisesDataGridView.Columns)
                        if (coluna.Name.Contains("Id"))
                            coluna.Visible = false;
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

        private void FormProdutoAnalises_Load(object sender, EventArgs e)
        {

        }

        private void SSS(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}