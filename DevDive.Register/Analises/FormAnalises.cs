using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DevDive.Register.Analises
{
    public partial class FormAnalises : Form
    {
        private readonly ControleAnalise _controle;
        private Analise _analise;


        public FormAnalises(SqlConnection getData)
        {
            InitializeComponent();

            _analise = new Analise();

            _controle = new ControleAnalise(getData);
        }


        private void FormAnalises_Load(object sender, EventArgs e)
        {
            CarregarGrid();

            foreach (var item in Enum.GetValues(typeof(EMetodoAnalise)))
                comboBox1.Items.Add(item);
        }

        private void CarregarGrid()
        {
            AnalisesDataGridView.DataSource = null;
            AnalisesDataGridView.DataSource = _controle.GetList();
        }

        private void AnalisesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AnalisesDataGridView.CurrentRow != null)
                _analise = (Analise) AnalisesDataGridView.CurrentRow.DataBoundItem;
            CarregarGrid();
            CarregarProcesso();
        }

        private void CarregarProcesso()
        {
            Limpar();
            if (_analise != null)
            {
                if (AnalisesDataGridView.CurrentRow != null)
                    _analise = (Analise) AnalisesDataGridView.CurrentRow.DataBoundItem;
                descricaoTextBox.Text = _analise.Descricao;
                especificacaoTextBox.Text = _analise.Especificacao;
                radioButton1.Checked = _analise.Tipo == ETipoAnalise.FisicoQuimica;
                radioButton2.Checked = _analise.Tipo == ETipoAnalise.Microbiologica;
                comboBox1.SelectedIndex = (int) _analise.Metodo;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            _analise.Descricao = descricaoTextBox.Text;
            _analise.Especificacao = especificacaoTextBox.Text;
            _analise.Metodo = (EMetodoAnalise) comboBox1.SelectedIndex;
            _analise.Tipo = radioButton1.Checked ? ETipoAnalise.FisicoQuimica : ETipoAnalise.Microbiologica;

            if (!radioButton1.Checked && !radioButton2.Checked)
                return;

            if (comboBox1.SelectedIndex == -1)
                return;

            _controle.Save(_analise);
            CarregarGrid();
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            if (_analise.Id == null)
                if (AnalisesDataGridView.CurrentRow != null)
                    _analise = (Analise) AnalisesDataGridView.CurrentRow.DataBoundItem;

            if (
                MessageBox.Show(@"Deseja excluir a análise?", @"Exclusão de análise", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                _controle.Delete(_analise);

            CarregarGrid();
            CarregarProcesso();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            _analise = new Analise();
            descricaoTextBox.Text = "";
            especificacaoTextBox.Text = "";
        }

        private void custoTextBox_Validated(object sender, EventArgs e)
        {
        }
    }
}