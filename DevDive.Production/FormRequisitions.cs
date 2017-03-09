using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevDive.Production
{
    public partial class FormRequisitions : Form
    {
        private ProductionController _controle;
        public BindingList<Product> Produtos { get; set; }
        public BindingList<int> Requisicoes { get; set; }

        public FormRequisitions(ProductionController controle)
        {
            InitializeComponent();

            Produtos = new BindingList<Product>();
            Requisicoes = new BindingList<int>();
            _controle = controle;
        }


        private void FormRequisitions_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            requisitionsDataGridView.DataSource = null;
            requisitionsDataGridView.DataSource = _controle.GetRequisitions();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ConfirmarRequisicoes();
        }

        private void ConfirmarRequisicoes()
        {
            Validate();

            var requisicoes = (BindingList<Requisitions>)requisitionsDataGridView.DataSource;

            if (requisicoes.Any(p => p.Checked))
            {
                foreach (var requisicao in requisicoes.Where(p => p.Checked).ToList())
                {
                    foreach (var produto in _controle.getProductsRequisition(requisicao.Id))
                    {
                        Produtos.Add(produto);
                    }
                    Requisicoes.Add(requisicao.Id);
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void requisitionsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex!=0)
            {
                e.Cancel = true;
            }
        }
    }
}
