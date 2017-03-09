namespace DevDive.Register.ProdutosProcessos
{
    partial class FormProdutoProcessos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProdutoProcessos));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.adicionarProcessoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.composicaoDataGridView = new System.Windows.Forms.DataGridView();
            this.produtoProcessoDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.produtosCompostosDataGridView = new System.Windows.Forms.DataGridView();
            this.processosDataGridView = new System.Windows.Forms.DataGridView();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.composicaoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoProcessoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosCompostosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarProcessoToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1352, 31);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Produto:";
            // 
            // composicaoDataGridView
            // 
            this.composicaoDataGridView.AllowUserToAddRows = false;
            this.composicaoDataGridView.AllowUserToDeleteRows = false;
            this.composicaoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.composicaoDataGridView.Location = new System.Drawing.Point(77, 67);
            this.composicaoDataGridView.MultiSelect = false;
            this.composicaoDataGridView.Name = "composicaoDataGridView";
            this.composicaoDataGridView.ReadOnly = true;
            this.composicaoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.composicaoDataGridView.Size = new System.Drawing.Size(734, 252);
            this.composicaoDataGridView.TabIndex = 3;
            // 
            // produtoProcessoDataGridView
            // 
            this.produtoProcessoDataGridView.AllowUserToAddRows = false;
            this.produtoProcessoDataGridView.AllowUserToDeleteRows = false;
            this.produtoProcessoDataGridView.AllowUserToOrderColumns = true;
            this.produtoProcessoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.produtoProcessoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtoProcessoDataGridView.Location = new System.Drawing.Point(77, 325);
            this.produtoProcessoDataGridView.MultiSelect = false;
            this.produtoProcessoDataGridView.Name = "produtoProcessoDataGridView";
            this.produtoProcessoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.produtoProcessoDataGridView.Size = new System.Drawing.Size(653, 275);
            this.produtoProcessoDataGridView.TabIndex = 4;
            this.produtoProcessoDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.produtoProcessoDataGridView_CellBeginEdit);
            this.produtoProcessoDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtoProcessoDataGridView_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Processos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Composição:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "UP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 42);
            this.button2.TabIndex = 9;
            this.button2.Text = "DOWN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // produtosCompostosDataGridView
            // 
            this.produtosCompostosDataGridView.AllowUserToAddRows = false;
            this.produtosCompostosDataGridView.AllowUserToDeleteRows = false;
            this.produtosCompostosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.produtosCompostosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtosCompostosDataGridView.Location = new System.Drawing.Point(817, 41);
            this.produtosCompostosDataGridView.MultiSelect = false;
            this.produtosCompostosDataGridView.Name = "produtosCompostosDataGridView";
            this.produtosCompostosDataGridView.ReadOnly = true;
            this.produtosCompostosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.produtosCompostosDataGridView.Size = new System.Drawing.Size(530, 278);
            this.produtosCompostosDataGridView.TabIndex = 10;
            this.produtosCompostosDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtosCompostosDataGridView_CellDoubleClick);
            this.produtosCompostosDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtosCompostosDataGridView_RowEnter);
            // 
            // processosDataGridView
            // 
            this.processosDataGridView.AllowUserToAddRows = false;
            this.processosDataGridView.AllowUserToDeleteRows = false;
            this.processosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processosDataGridView.Location = new System.Drawing.Point(817, 325);
            this.processosDataGridView.MultiSelect = false;
            this.processosDataGridView.Name = "processosDataGridView";
            this.processosDataGridView.ReadOnly = true;
            this.processosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.processosDataGridView.Size = new System.Drawing.Size(530, 275);
            this.processosDataGridView.TabIndex = 11;
            this.processosDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.processosDataGridView_CellDoubleClick);
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.Location = new System.Drawing.Point(149, 41);
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.ReadOnly = true;
            this.descricaoTextBox.Size = new System.Drawing.Size(662, 20);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(735, 325);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 42);
            this.button3.TabIndex = 12;
            this.button3.Text = "<--";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(735, 373);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 42);
            this.button4.TabIndex = 13;
            this.button4.Text = "-->";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormProdutoProcessos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 612);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.processosDataGridView);
            this.Controls.Add(this.produtosCompostosDataGridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.codigoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.produtoProcessoDataGridView);
            this.Controls.Add(this.composicaoDataGridView);
            this.Controls.Add(this.descricaoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProdutoProcessos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vinculo de processos";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.composicaoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoProcessoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosCompostosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton adicionarProcessoToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView composicaoDataGridView;
        private System.Windows.Forms.DataGridView produtoProcessoDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView produtosCompostosDataGridView;
        private System.Windows.Forms.DataGridView processosDataGridView;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}