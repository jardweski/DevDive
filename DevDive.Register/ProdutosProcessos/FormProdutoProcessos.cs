using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevDive.Register.Processos;
using DevDive.Register.Produtos;

namespace DevDive.Register.ProdutosProcessos
{
    public partial class FormProdutoProcessos : Form
    {
        private readonly ControleProcesso _processoControl;
        private readonly ProdutoControle _produtoControl;
        private BindingList<Processo> _processos;
        private BindingList<ProdutoProcesso> _produtosProcessos;

        public FormProdutoProcessos(SqlConnection getData, SqlConnection getIgdData)
        {
            InitializeComponent();

            _produtoControl = new ProdutoControle(getData, getIgdData);
            _processoControl = new ControleProcesso(getData);

            _produtosProcessos = new BindingList<ProdutoProcesso>();

            CarrregarProcessos();

            CarregarProdutosCompostos();
        }

        private void CarrregarProcessos()
        {
            _processos = _processoControl.GetList();

            FormatarGrid(processosDataGridView, ETipoFormatGrid.Processo, _processos);
        }

        private void CarregarProdutosCompostos()
        {
            FormatarGrid(produtosCompostosDataGridView, ETipoFormatGrid.ProdutoComposto,
                new BindingList<ProdutoComposicao>(_produtoControl.GetListProductCompound().ToList()));
        }

        private void CarregarComposicaoProduto(ProdutoComposicao produtoComposicao)
        {
            FormatarGrid(composicaoDataGridView, ETipoFormatGrid.Composicao,
                new BindingList<ProdutoComposto>(_produtoControl.GetListCompound(produtoComposicao.Id).ToList()));

            codigoTextBox.Text = produtoComposicao.Codigo;
            descricaoTextBox.Text = produtoComposicao.Descricao;
        }

        private void produtosCompostosDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var produtoComposicao = (ProdutoComposicao) produtosCompostosDataGridView.Rows[e.RowIndex].DataBoundItem;
                if (produtoComposicao != null)
                {
                    CarregarComposicaoProduto(produtoComposicao);
                }
            }
        }

        private void produtosCompostosDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _produtosProcessos = new BindingList<ProdutoProcesso>();
                CarregarProdutoProcesso();
                _processos = new BindingList<Processo>();
                CarrregarProcessos();

                produtosCompostosDataGridView.Rows[e.RowIndex].Selected = true;

                var produtoComposicao = (ProdutoComposicao) produtosCompostosDataGridView.Rows[e.RowIndex].DataBoundItem;
                if (produtoComposicao != null)
                {
                    CarregarComposicaoProduto(produtoComposicao);
                    ObterProdutoProcesso(produtoComposicao.Id);
                }
            }
        }

        private void ObterProdutoProcesso(int idProdutoComposto)
        {
            var processosProdutos = _produtoControl.GetProcessProduct(idProdutoComposto);

            if (processosProdutos != null && processosProdutos.Any())
                foreach (var processosProduto in processosProdutos)
                {
                    foreach (DataGridViewRow dataGridViewRow in processosDataGridView.Rows)
                    {
                        if (((Processo) dataGridViewRow.DataBoundItem).Id == processosProduto.IdProcesso)
                        {
                            ValidaAdicionaProcesso(dataGridViewRow.Index, processosProduto);
                        }
                    }
                }
        }

        private void processosDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ValidaAdicionaProcesso(e.RowIndex, null);
        }

        private void ValidaAdicionaProcesso(int rowIndex, ProdutoProcesso processosProduto)
        {
            if (rowIndex >= 0)
            {
                var processo = (Processo) processosDataGridView.Rows[rowIndex].DataBoundItem;

                var produtoComposto = (ProdutoComposicao) produtosCompostosDataGridView.SelectedRows[0].DataBoundItem;

                if (produtoComposto == null)
                {
                    return;
                }

                if (processo != null)
                {
                    AdicionarProcessoProduto(processo, produtoComposto.Id, processosProduto);
                }
            }
        }

        private void AdicionarProcessoProduto(Processo processo, int idProdutoComposto, ProdutoProcesso processosProduto)
        {
            var ordem = 0;
            if (_produtosProcessos.Any())
            {
                ordem = _produtosProcessos.Max(p => p.Ordem);
            }

            _produtosProcessos.Add(new ProdutoProcesso(idProdutoComposto, _produtoControl)
            {
                IdProcesso = (int) processo.Id,
                CustoProcesso = processo.Custo,
                DescricaoProcesso = processo.Descricao,
                Ordem = ordem + 1,
                Quantidade = processosProduto?.Quantidade ?? 0,
                Tempo = processosProduto?.Tempo ?? 0
            });

            _processos.Remove(processo);

            CarregarProdutoProcesso();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (processosDataGridView.SelectedRows.Count > 0)
            {
                ValidaAdicionaProcesso(processosDataGridView.SelectedRows[0].Index, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (produtoProcessoDataGridView.SelectedRows.Count > 0)
            {
                ValidaRemoveProcesso(produtoProcessoDataGridView.SelectedRows[0].Index);
            }
        }

        private void ValidaRemoveProcesso(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                var produtoProcesso = (ProdutoProcesso) produtoProcessoDataGridView.Rows[rowIndex].DataBoundItem;

                var produtoComposto = (ProdutoComposicao) produtosCompostosDataGridView.SelectedRows[0].DataBoundItem;

                if (produtoComposto == null)
                {
                    return;
                }

                if (produtoProcesso != null)
                {
                    RemoverProcessoProduto(produtoProcesso, produtoComposto.Id);
                }
            }
        }

        private void RemoverProcessoProduto(ProdutoProcesso produtoProcesso, int idProdutoComposto)
        {
            var ordem = 0;
            if (_produtosProcessos.Any())
            {
                ordem = _produtosProcessos.Max(p => p.Ordem);
            }

            _produtosProcessos.Remove(produtoProcesso);

            _processos.Add(new Processo
            {
                Id = produtoProcesso.IdProcesso,
                Descricao = produtoProcesso.DescricaoProcesso,
                Custo = produtoProcesso.CustoProcesso
            });

            AjustarOrdem();

            CarregarProdutoProcesso();
        }

        private void CarregarProdutoProcesso()
        {
            FormatarGrid(produtoProcessoDataGridView, ETipoFormatGrid.ProdutoProcesso,
                new BindingList<ProdutoProcesso>(_produtosProcessos.OrderBy(p => p.Ordem).ToList()));
        }

        private void FormatarGrid<T>(DataGridView dataGridView, ETipoFormatGrid tipo, BindingList<T> dataSource)
        {
            switch (tipo)
            {
                case ETipoFormatGrid.ProdutoProcesso:
                    produtoProcessoDataGridView.DataSource = dataSource;
                    break;
                case ETipoFormatGrid.Processo:
                    processosDataGridView.DataSource = dataSource;
                    break;
                case ETipoFormatGrid.Composicao:
                    composicaoDataGridView.DataSource = dataSource;
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

        private void AjustarOrdem()
        {
            var ordem = 0;
            foreach (DataGridViewRow row in produtoProcessoDataGridView.Rows)
            {
                if (row.Index == 0)
                {
                    continue;
                }

                ((ProdutoProcesso) row.DataBoundItem).Ordem = ordem + 1;
                ordem++;
            }
        }

        private void produtoProcessoDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ValidaRemoveProcesso(produtoProcessoDataGridView.SelectedRows[0].Index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoverProdutoProcesso(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoverProdutoProcesso(1);
        }

        private void MoverProdutoProcesso(int upDown)
        {
            //UP
            if (upDown == 0)
            {
                var ordem = ((ProdutoProcesso) produtoProcessoDataGridView.SelectedRows[0].DataBoundItem).Ordem;
                if (ordem - 1 == 0)
                {
                    return;
                }
                var ordemSubs = _produtosProcessos.First(p => p.Ordem == ordem - 1);
                ((ProdutoProcesso) produtoProcessoDataGridView.SelectedRows[0].DataBoundItem).Ordem = ordem - 1;
                ordemSubs.Ordem = ordem;
            }
            //DOWN
            else
            {
                var ordem = ((ProdutoProcesso) produtoProcessoDataGridView.SelectedRows[0].DataBoundItem).Ordem;
                if (ordem + 1 > _produtosProcessos.Count)
                {
                    return;
                }
                var ordemSubs = _produtosProcessos.First(p => p.Ordem == ordem + 1);
                ((ProdutoProcesso) produtoProcessoDataGridView.SelectedRows[0].DataBoundItem).Ordem = ordem + 1;
                ordemSubs.Ordem = ordem;
            }

            CarregarProdutoProcesso();
        }

        private void adicionarProcessoToolStripButton_Click(object sender, EventArgs e)
        {
            SalvarProcessoProduto();
        }

        private void SalvarProcessoProduto()
        {
            var idProduto = ((ProdutoComposicao) produtosCompostosDataGridView.SelectedRows[0].DataBoundItem).Id;

            var retorno = _produtoControl.SaveProcessProduct(idProduto, _produtosProcessos);

            if (retorno.Sucess)
            {
                MessageBox.Show(retorno.Message);
            }
            else
            {
                foreach (var error in retorno.Errors)
                {
                    MessageBox.Show(error);
                }
            }
        }

        private void produtoProcessoDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (produtoProcessoDataGridView.Columns[e.ColumnIndex].Name != "Quantidade" &&
                produtoProcessoDataGridView.Columns[e.ColumnIndex].Name != "Tempo")
            {
                e.Cancel = true;
            }
        }
    }
}