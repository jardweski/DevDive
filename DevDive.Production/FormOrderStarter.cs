using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevDive.Register.Processos;

namespace DevDive.Production
{
    public partial class FormOrderStarter : Form
    {
        private readonly ProductionController _controle;
        private readonly ProductionOrder _ordemProducao;
        private BindingList<ProcessProduction> _processos;
        private BindingList<Product> _produtosFinais;
        private BindingList<int> _requisicoesSelecionadas;
        private ReportModuleProduction _reportModule;
        private MP.Reporting.WinForms.ReportControl _reportControl;

        public FormOrderStarter(ProductionOrder ordemProducao, ProductionController controle)
        {
            InitializeComponent();

            _ordemProducao = ordemProducao;

            _controle = controle;

            _requisicoesSelecionadas = new BindingList<int>();
            
            _reportModule = ReportModuleProduction.GetInstance();
            _reportControl = new MP.Reporting.WinForms.ReportControl();

            CarregarOrdemProducao();
            CarregarProdutosFinais();
            CarregarRequisicoes();
        }

        private void CarregarRequisicoes()
        {
            PreencherRequisicoes(_controle.GetProductsRequisitionsOrder(_ordemProducao.Id, out _requisicoesSelecionadas));
        }

        private void CarregarProdutosFinais()
        {
            _produtosFinais = _controle.GetFinalProducts(_ordemProducao.Id);
            finalProductsDataGridView.DataSource = null;
            finalProductsDataGridView.DataSource = _produtosFinais;
            var dataGridViewColumn = finalProductsDataGridView.Columns["Quantidade"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.DefaultCellStyle.Format = "###,##0.00####";

            var dataGridViewColumn2 = finalProductsDataGridView.Columns["Id"];
            if (dataGridViewColumn2 != null)
                dataGridViewColumn2.Visible = false;
        }

        private void CarregarOrdemProducao()
        {
            lblOrdemProducao.Text = _ordemProducao.Id.ToString("00000");
            lblData.Text = _ordemProducao.DataLancamento.ToString("dd/MM/yyyy");
            lblSituacao.Text = _ordemProducao.SituacaoDescricao;

            iniciarToolStripButton.Enabled = _ordemProducao.Situacao == 0;
            encerrarToolStripButton.Enabled = _ordemProducao.Situacao == 1;

            lblDataConfirmacao.Text = _ordemProducao.DataConfirmacao?.ToString();
        }

        private void finalProductsDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (finalProductsDataGridView.CurrentRow != null)
            {
                var produtoFinal = (Product) finalProductsDataGridView.CurrentRow.DataBoundItem;
                if (produtoFinal != null)
                {
                    CarregarComposicaoProduto(produtoFinal);
                    ObterProcessos(produtoFinal);
                    CarregarProcessos();
                }
            }
        }

        private void CarregarProcessos()
        {
            processDataGridView.DataSource = null;
            processDataGridView.DataSource = _processos;
            processDataGridView.ReadOnly = false;

            var dataGridViewColumn = processDataGridView.Columns["Id"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;

            var dataGridViewColumn3 = processDataGridView.Columns["Quantidade"];
            if (dataGridViewColumn3 != null)
                dataGridViewColumn3.Visible = false;

            var dataGridViewColumn2 = processDataGridView.Columns["Tempo"];
            if (dataGridViewColumn2 != null)
            {
                dataGridViewColumn2.DefaultCellStyle.Format = "###,##0.00####";
                dataGridViewColumn2.ReadOnly = false;
            }

            var dataGridViewColumn4 = processDataGridView.Columns["TempoUtilizado"];
            if (dataGridViewColumn4 != null)
                dataGridViewColumn4.DefaultCellStyle.Format = "###,##0.00####";
        }

        private void ObterProcessos(Product produto)
        {
            _processos = _controle.GetProcessProduct(produto, _ordemProducao.Id);
        }

        private void CarregarComposicaoProduto(Product produtoFinal)
        {
            var composicoes = _controle.GetCompositions(_ordemProducao.Id, produtoFinal);
            compositionDataGridView.DataSource = null;
            compositionDataGridView.DataSource = composicoes;

            var dataGridViewColumn = compositionDataGridView.Columns["Quantidade"];
            if (dataGridViewColumn != null)
            {
                dataGridViewColumn.DefaultCellStyle.Format = "###,##0.00####";
                dataGridViewColumn.HeaderText = @"Qtde.";
            }

            var dataGridViewColumn2 = compositionDataGridView.Columns["Id"];
            if (dataGridViewColumn2 != null)
                dataGridViewColumn2.Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IniciarProducao();
        }

        private void IniciarProducao()
        {
            if (_controle.OrderHasStarted(_ordemProducao.Id))
            {
                MessageBox.Show(@"Ordem de produção já iniciada!", @"Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            if (_requisicoesSelecionadas == null || !_requisicoesSelecionadas.Any())
                if (MessageBox.Show(
                    @"Não há nenhuma requisição de material para essa ordem de produção, deseja continuar ?",
                    @"Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) !=
                    DialogResult.Yes)
                    return;

            if (MessageBox.Show(@"Iniciar ordem de produção?", @"Pergunta", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                return;

            MessageBox.Show(this, _controle.SaveOrder(_ordemProducao.Id, _requisicoesSelecionadas,_processos).Message, "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            _controle.StartOrder(_ordemProducao.Id);
            DialogResult = DialogResult.Yes;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            EncerrarOrdemProducao();
        }

        private void EncerrarOrdemProducao()
        {
            if (_processos.Any(p => p.TempoUtilizado == null))
            {
                MessageBox.Show(@"Tempo de processo não informado!", @"Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(@"Finalizar ordem de produção?", @"Pergunta", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                return;
            MessageBox.Show(this, _controle.SaveOrder(_ordemProducao.Id, _requisicoesSelecionadas,_processos).Message, "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (var produtoFinal in _produtosFinais)
            {
                _controle.FinishOrder(_ordemProducao.Id, produtoFinal.Id, produtoFinal.Quantidade, _processos);
            }
            DialogResult = DialogResult.Yes;
        }

        private void processDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ExibirPesquisaRequisicoes();
        }

        private void ExibirPesquisaRequisicoes()
        {
            var orderForm = new FormRequisitions(_controle);
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                PreencherRequisicoes(orderForm.Produtos);
            }
            _requisicoesSelecionadas = orderForm.Requisicoes;
        }

        private void PreencherRequisicoes(BindingList<Product> produtos)
        {
            usedCompositionDataGridView.DataSource = null;
            usedCompositionDataGridView.DataSource = produtos;

            var dataGridViewColumn = usedCompositionDataGridView.Columns["Quantidade"];
            if (dataGridViewColumn != null)
            {
                dataGridViewColumn.DefaultCellStyle.Format = "###,##0.00####";
                dataGridViewColumn.HeaderText = @"Qtde.";
            }

            var dataGridViewColumn2 = usedCompositionDataGridView.Columns["Id"];
            if (dataGridViewColumn2 != null)
                dataGridViewColumn2.Visible = false;
        }

        private void processDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (processDataGridView.Columns[e.ColumnIndex].Name != "TempoUtilizado" &&
                processDataGridView.Columns[e.ColumnIndex].Name != "Tempo" &&
                processDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() == "0")
            {
                e.Cancel = true;
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(this, _controle.SaveOrder(_ordemProducao.Id, _requisicoesSelecionadas,_processos).Message, "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            //Relatório da Ordem de Produção
        }

        private void relatórioDeCustosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Relatório de Custos
            if(_ordemProducao != null)
            {
                _reportModule.ReportParameter.SetVariableValue("IdOP", _ordemProducao.Id);
                _reportControl.Load(23);
                _reportControl.SetReportParameters(_reportModule.ReportParameter);
                _reportControl.ViewReport(this);

                ////Relatório de previsão de estoque
                //var f = new MP.Reporting.WinForms.FormReports(_reportModule.ReportParameter);
                //f.Show();
            }
        }

        private void previsãoDoEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Relatório de previsão de compras
            if (_ordemProducao != null)
            {
                _reportModule.ReportParameter.SetVariableValue("IdOP", _ordemProducao.IdPedido);
                _reportControl.Load(24);
                _reportControl.SetReportParameters(_reportModule.ReportParameter);
                _reportControl.ViewReport(this);

                ////Relatório de previsão de estoque
                //var f = new MP.Reporting.WinForms.FormReports(_reportModule.ReportParameter);
                //f.Show();
            }
        }

        private void addProcessToolStripButton_Click(object sender, EventArgs e)
        {
            ExibirProcessos();
        }

        private void ExibirProcessos()
        {
            var orderForm = new FormSearchProcess(_controle._getData, _controle._getIgdData);
            if (orderForm.ShowDialog() == DialogResult.Yes)
            {
                AdicionarProcesso(orderForm.Processo);
            }
        }

        private void AdicionarProcesso(Processo processo)
        {
            if (_processos.All(p => p.Id != processo.Id))
            {
                _processos.Add(new ProcessProduction
                {
                    Descricao = processo.Descricao,
                    Id = (int) processo.Id,
                    Ordem = _processos.Count == 0 ? 1 : _processos.Max(p => p.Ordem) + 1
                });

                CarregarProcessos();
            }
        }
    }
}