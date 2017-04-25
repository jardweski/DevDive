namespace DevDive.Register.ProdutosAnalises
{ 
    partial class FormProdutoAnalises
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProdutoAnalises));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.adicionarProcessoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.produtoAnaliseDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.produtosCompostosDataGridView = new System.Windows.Forms.DataGridView();
            this.AnalisesDataGridView = new System.Windows.Forms.DataGridView();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.addAnaliseButton = new System.Windows.Forms.Button();
            this.removeAnaliseButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoAnaliseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosCompostosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnalisesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarProcessoToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(801, 31);
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
            this.adicionarProcessoToolStripButton.Click += new System.EventHandler(this.adicionarAnaliseToolStripButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Produto:";
            // 
            // produtoAnaliseDataGridView
            // 
            this.produtoAnaliseDataGridView.AllowUserToAddRows = false;
            this.produtoAnaliseDataGridView.AllowUserToDeleteRows = false;
            this.produtoAnaliseDataGridView.AllowUserToOrderColumns = true;
            this.produtoAnaliseDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.produtoAnaliseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtoAnaliseDataGridView.Location = new System.Drawing.Point(74, 241);
            this.produtoAnaliseDataGridView.MultiSelect = false;
            this.produtoAnaliseDataGridView.Name = "produtoAnaliseDataGridView";
            this.produtoAnaliseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.produtoAnaliseDataGridView.Size = new System.Drawing.Size(320, 353);
            this.produtoAnaliseDataGridView.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Analises:";
            // 
            // produtosCompostosDataGridView
            // 
            this.produtosCompostosDataGridView.AllowUserToAddRows = false;
            this.produtosCompostosDataGridView.AllowUserToDeleteRows = false;
            this.produtosCompostosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.produtosCompostosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtosCompostosDataGridView.Location = new System.Drawing.Point(74, 67);
            this.produtosCompostosDataGridView.MultiSelect = false;
            this.produtosCompostosDataGridView.Name = "produtosCompostosDataGridView";
            this.produtosCompostosDataGridView.ReadOnly = true;
            this.produtosCompostosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.produtosCompostosDataGridView.Size = new System.Drawing.Size(715, 167);
            this.produtosCompostosDataGridView.TabIndex = 10;
            this.produtosCompostosDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtosCompostosDataGridView_RowEnter);
            // 
            // AnalisesDataGridView
            // 
            this.AnalisesDataGridView.AllowUserToAddRows = false;
            this.AnalisesDataGridView.AllowUserToDeleteRows = false;
            this.AnalisesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalisesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnalisesDataGridView.Location = new System.Drawing.Point(482, 241);
            this.AnalisesDataGridView.MultiSelect = false;
            this.AnalisesDataGridView.Name = "AnalisesDataGridView";
            this.AnalisesDataGridView.ReadOnly = true;
            this.AnalisesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AnalisesDataGridView.Size = new System.Drawing.Size(307, 353);
            this.AnalisesDataGridView.TabIndex = 11;
            this.AnalisesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AnalisesDataGridView_CellDoubleClick);
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descricaoTextBox.Location = new System.Drawing.Point(149, 41);
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.ReadOnly = true;
            this.descricaoTextBox.Size = new System.Drawing.Size(640, 20);
            this.descricaoTextBox.TabIndex = 2;
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.Location = new System.Drawing.Point(77, 41);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(66, 20);
            this.codigoTextBox.TabIndex = 7;
            // 
            // addAnaliseButton
            // 
            this.addAnaliseButton.Location = new System.Drawing.Point(400, 240);
            this.addAnaliseButton.Name = "addAnaliseButton";
            this.addAnaliseButton.Size = new System.Drawing.Size(76, 42);
            this.addAnaliseButton.TabIndex = 12;
            this.addAnaliseButton.Text = "<--";
            this.addAnaliseButton.UseVisualStyleBackColor = true;
            this.addAnaliseButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // removeAnaliseButton
            // 
            this.removeAnaliseButton.Location = new System.Drawing.Point(400, 288);
            this.removeAnaliseButton.Name = "removeAnaliseButton";
            this.removeAnaliseButton.Size = new System.Drawing.Size(76, 42);
            this.removeAnaliseButton.TabIndex = 13;
            this.removeAnaliseButton.Text = "-->";
            this.removeAnaliseButton.UseVisualStyleBackColor = true;
            this.removeAnaliseButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormProdutoAnalises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 606);
            this.Controls.Add(this.removeAnaliseButton);
            this.Controls.Add(this.addAnaliseButton);
            this.Controls.Add(this.AnalisesDataGridView);
            this.Controls.Add(this.produtosCompostosDataGridView);
            this.Controls.Add(this.codigoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.produtoAnaliseDataGridView);
            this.Controls.Add(this.descricaoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProdutoAnalises";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vinculo de Analises";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoAnaliseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosCompostosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnalisesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton adicionarProcessoToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView produtoAnaliseDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView produtosCompostosDataGridView;
        private System.Windows.Forms.DataGridView AnalisesDataGridView;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.Button addAnaliseButton;
        private System.Windows.Forms.Button removeAnaliseButton;
    }
}