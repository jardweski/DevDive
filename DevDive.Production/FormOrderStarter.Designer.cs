namespace DevDive.Production
{
    partial class FormOrderStarter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrderStarter));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.iniciarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.encerrarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ordemDeProduçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDeCustosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previsãoDoEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.compositionDataGridView = new System.Windows.Forms.DataGridView();
            this.processDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usedCompositionDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOrdemProducao = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDataConfirmacao = new System.Windows.Forms.Label();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.addProcessToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalProductsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositionDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usedCompositionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.iniciarToolStripButton,
            this.encerrarToolStripButton,
            this.addProcessToolStripButton,
            this.toolStripButton3,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // iniciarToolStripButton
            // 
            this.iniciarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.iniciarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("iniciarToolStripButton.Image")));
            this.iniciarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.iniciarToolStripButton.Name = "iniciarToolStripButton";
            this.iniciarToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.iniciarToolStripButton.Text = "Iniciar produção";
            this.iniciarToolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // encerrarToolStripButton
            // 
            this.encerrarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.encerrarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("encerrarToolStripButton.Image")));
            this.encerrarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.encerrarToolStripButton.Name = "encerrarToolStripButton";
            this.encerrarToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.encerrarToolStripButton.Text = "Encerrar produção";
            this.encerrarToolStripButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton3.Text = "Pesquisar requisição";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordemDeProduçãoToolStripMenuItem,
            this.relatórioDeCustosToolStripMenuItem,
            this.previsãoDoEstoqueToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(37, 28);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // ordemDeProduçãoToolStripMenuItem
            // 
            this.ordemDeProduçãoToolStripMenuItem.Name = "ordemDeProduçãoToolStripMenuItem";
            this.ordemDeProduçãoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ordemDeProduçãoToolStripMenuItem.Text = "Ordem de Produção";
            // 
            // relatórioDeCustosToolStripMenuItem
            // 
            this.relatórioDeCustosToolStripMenuItem.Name = "relatórioDeCustosToolStripMenuItem";
            this.relatórioDeCustosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.relatórioDeCustosToolStripMenuItem.Text = "Relatório de Custos";
            this.relatórioDeCustosToolStripMenuItem.Click += new System.EventHandler(this.relatórioDeCustosToolStripMenuItem_Click);
            // 
            // previsãoDoEstoqueToolStripMenuItem
            // 
            this.previsãoDoEstoqueToolStripMenuItem.Name = "previsãoDoEstoqueToolStripMenuItem";
            this.previsãoDoEstoqueToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.previsãoDoEstoqueToolStripMenuItem.Text = "Previsão do Estoque";
            this.previsãoDoEstoqueToolStripMenuItem.Click += new System.EventHandler(this.previsãoDoEstoqueToolStripMenuItem_Click);
            // 
            // finalProductsDataGridView
            // 
            this.finalProductsDataGridView.AllowUserToAddRows = false;
            this.finalProductsDataGridView.AllowUserToDeleteRows = false;
            this.finalProductsDataGridView.AllowUserToOrderColumns = true;
            this.finalProductsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.finalProductsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.finalProductsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.finalProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.finalProductsDataGridView.Location = new System.Drawing.Point(12, 112);
            this.finalProductsDataGridView.Name = "finalProductsDataGridView";
            this.finalProductsDataGridView.ReadOnly = true;
            this.finalProductsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.finalProductsDataGridView.Size = new System.Drawing.Size(960, 114);
            this.finalProductsDataGridView.TabIndex = 1;
            this.finalProductsDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.finalProductsDataGridView_RowEnter);
            // 
            // compositionDataGridView
            // 
            this.compositionDataGridView.AllowUserToAddRows = false;
            this.compositionDataGridView.AllowUserToDeleteRows = false;
            this.compositionDataGridView.AllowUserToOrderColumns = true;
            this.compositionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.compositionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.compositionDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.compositionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.compositionDataGridView.Location = new System.Drawing.Point(12, 430);
            this.compositionDataGridView.Name = "compositionDataGridView";
            this.compositionDataGridView.ReadOnly = true;
            this.compositionDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.compositionDataGridView.Size = new System.Drawing.Size(475, 285);
            this.compositionDataGridView.TabIndex = 2;
            // 
            // processDataGridView
            // 
            this.processDataGridView.AllowUserToAddRows = false;
            this.processDataGridView.AllowUserToDeleteRows = false;
            this.processDataGridView.AllowUserToOrderColumns = true;
            this.processDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.processDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.processDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processDataGridView.Location = new System.Drawing.Point(12, 248);
            this.processDataGridView.Name = "processDataGridView";
            this.processDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.processDataGridView.Size = new System.Drawing.Size(960, 163);
            this.processDataGridView.TabIndex = 3;
            this.processDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.processDataGridView_CellBeginEdit);
            this.processDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.processDataGridView_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Produtos finais";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Composição esperada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Processos utilizados";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // usedCompositionDataGridView
            // 
            this.usedCompositionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usedCompositionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.usedCompositionDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.usedCompositionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usedCompositionDataGridView.Location = new System.Drawing.Point(497, 430);
            this.usedCompositionDataGridView.Name = "usedCompositionDataGridView";
            this.usedCompositionDataGridView.ReadOnly = true;
            this.usedCompositionDataGridView.Size = new System.Drawing.Size(475, 285);
            this.usedCompositionDataGridView.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Composição utilizada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ordem de produção:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Data:";
            // 
            // lblOrdemProducao
            // 
            this.lblOrdemProducao.AutoSize = true;
            this.lblOrdemProducao.Location = new System.Drawing.Point(123, 40);
            this.lblOrdemProducao.Name = "lblOrdemProducao";
            this.lblOrdemProducao.Size = new System.Drawing.Size(31, 13);
            this.lblOrdemProducao.TabIndex = 11;
            this.lblOrdemProducao.Text = "0000";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(123, 63);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(65, 13);
            this.lblData.TabIndex = 12;
            this.lblData.Text = "01/01/0001";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Situação:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Confirmado:";
            // 
            // lblDataConfirmacao
            // 
            this.lblDataConfirmacao.AutoSize = true;
            this.lblDataConfirmacao.Location = new System.Drawing.Point(293, 63);
            this.lblDataConfirmacao.Name = "lblDataConfirmacao";
            this.lblDataConfirmacao.Size = new System.Drawing.Size(65, 13);
            this.lblDataConfirmacao.TabIndex = 15;
            this.lblDataConfirmacao.Text = "01/01/0001";
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Location = new System.Drawing.Point(293, 40);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(38, 13);
            this.lblSituacao.TabIndex = 16;
            this.lblSituacao.Text = "Aberto";
            // 
            // addProcessToolStripButton
            // 
            this.addProcessToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addProcessToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addProcessToolStripButton.Image")));
            this.addProcessToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addProcessToolStripButton.Name = "addProcessToolStripButton";
            this.addProcessToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.addProcessToolStripButton.Text = "Adicionar processo";
            this.addProcessToolStripButton.Click += new System.EventHandler(this.addProcessToolStripButton_Click);
            // 
            // FormOrderStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 727);
            this.Controls.Add(this.lblSituacao);
            this.Controls.Add(this.lblDataConfirmacao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblOrdemProducao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.usedCompositionDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.processDataGridView);
            this.Controls.Add(this.compositionDataGridView);
            this.Controls.Add(this.finalProductsDataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOrderStarter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordem de Produção - Starter";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalProductsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositionDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usedCompositionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton iniciarToolStripButton;
        private System.Windows.Forms.ToolStripButton encerrarToolStripButton;
        private System.Windows.Forms.DataGridView finalProductsDataGridView;
        private System.Windows.Forms.DataGridView compositionDataGridView;
        private System.Windows.Forms.DataGridView processDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.DataGridView usedCompositionDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOrdemProducao;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDataConfirmacao;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ordemDeProduçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDeCustosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previsãoDoEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton addProcessToolStripButton;
    }
}