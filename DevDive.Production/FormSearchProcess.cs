using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevDive.Register.Processos;

namespace DevDive.Production
{
    public partial class FormSearchProcess : Form
    {
        private readonly ControleProcesso _controle;
        public Processo Processo { get; set; }

        public FormSearchProcess(SqlConnection getData, SqlConnection getIgdData)
        {
            InitializeComponent();

            _controle = new ControleProcesso(getData);
        }

        private void FormSearchProcess_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        private void CarregarGrid()
        {
            processosDataGridView.DataSource = null;
            processosDataGridView.DataSource = _controle.GetList();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (processosDataGridView.CurrentRow==null)
            {
                return;
            }

            try
            {
                Processo = (Processo)processosDataGridView.CurrentRow.DataBoundItem;
                DialogResult = DialogResult.Yes;
            }
            catch (Exception)
            {
                return;
            }
        }

        
    }
}
