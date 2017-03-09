using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace DevDive.Register.Processos
{
    public partial class FormProcessos : Form
    {
        private readonly ControleProcesso _controle;
        private Processo _processo;


        public FormProcessos(SqlConnection getData)
        {
            InitializeComponent();

            _processo = new Processo();

            _controle = new ControleProcesso(getData);
        }


        private void FormProcessos_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            processosDataGridView.DataSource = null;
            processosDataGridView.DataSource = _controle.GetList();
        }

        private void processosDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (processosDataGridView.CurrentRow != null)
                _processo = (Processo) processosDataGridView.CurrentRow.DataBoundItem;
            CarregarGrid();
            CarregarProcesso();
        }

        private void CarregarProcesso()
        {
            Limpar();
            if (_processo != null)
            {
                if (processosDataGridView.CurrentRow != null)
                    _processo = (Processo) processosDataGridView.CurrentRow.DataBoundItem;
                descricaoTextBox.Text = _processo.Descricao;
                custoTextBox.Text = _processo.Custo.ToString(CultureInfo.CurrentCulture);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            _processo.Descricao = descricaoTextBox.Text;
            _processo.Custo = Convert.ToDecimal(custoTextBox.Text==""?"0":custoTextBox.Text);
            _controle.Save(_processo);
            CarregarGrid();
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            if (_processo.Id == null)
                if (processosDataGridView.CurrentRow != null)
                    _processo = (Processo) processosDataGridView.CurrentRow.DataBoundItem;

            if (
                MessageBox.Show("Deseja excluir o processo?", "Exclusão de processo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                _controle.Delete(_processo);
            }

            CarregarGrid();
            CarregarProcesso();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            _processo = new Processo();
            descricaoTextBox.Text = "";
            custoTextBox.Text = "";
        }

        private void custoTextBox_Validated(object sender, EventArgs e)
        {
            decimal resultado;
            if (!decimal.TryParse(custoTextBox.Text, out resultado))
            {
                MessageBox.Show("Informe valores numéricos");
                custoTextBox.Text = "";
            }
        }
    }
}