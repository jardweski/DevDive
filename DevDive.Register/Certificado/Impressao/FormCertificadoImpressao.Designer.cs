using DevDive.Register.Certificado.DadosDeProdutos;

namespace DevDive.Register.Certificado.Impressao
{
    partial class FormCertificadoImpressao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCertificadoImpressao));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.adicionarProcessoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.produtosDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.resultadosDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarProcessoToolStripButton,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(967, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // adicionarProcessoToolStripButton
            // 
            this.adicionarProcessoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.adicionarProcessoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("adicionarProcessoToolStripButton.Image")));
            this.adicionarProcessoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adicionarProcessoToolStripButton.Name = "adicionarProcessoToolStripButton";
            this.adicionarProcessoToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.adicionarProcessoToolStripButton.Text = "Adicionar processo";
            this.adicionarProcessoToolStripButton.Click += new System.EventHandler(this.adicionarProcessoToolStripButton_Click);
            // 
            // produtosDataGridView
            // 
            this.produtosDataGridView.AllowUserToAddRows = false;
            this.produtosDataGridView.AllowUserToDeleteRows = false;
            this.produtosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.produtosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtosDataGridView.Location = new System.Drawing.Point(74, 34);
            this.produtosDataGridView.MultiSelect = false;
            this.produtosDataGridView.Name = "produtosDataGridView";
            this.produtosDataGridView.ReadOnly = true;
            this.produtosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.produtosDataGridView.Size = new System.Drawing.Size(881, 237);
            this.produtosDataGridView.TabIndex = 10;
            this.produtosDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtosDataGridView_RowEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Produtos:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 277);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 48;
            this.label18.Text = "Analises:";
            // 
            // resultadosDataGridView
            // 
            this.resultadosDataGridView.AllowUserToAddRows = false;
            this.resultadosDataGridView.AllowUserToDeleteRows = false;
            this.resultadosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultadosDataGridView.Location = new System.Drawing.Point(74, 277);
            this.resultadosDataGridView.MultiSelect = false;
            this.resultadosDataGridView.Name = "resultadosDataGridView";
            this.resultadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultadosDataGridView.Size = new System.Drawing.Size(881, 237);
            this.resultadosDataGridView.TabIndex = 50;
            this.resultadosDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.resultadosDataGridView_CellBeginEdit);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "Imprimir certificado";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // FormCertificadoImpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 531);
            this.Controls.Add(this.resultadosDataGridView);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.produtosDataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCertificadoImpressao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dados de produtos para certificado";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton adicionarProcessoToolStripButton;
        private System.Windows.Forms.DataGridView produtosDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView resultadosDataGridView;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}