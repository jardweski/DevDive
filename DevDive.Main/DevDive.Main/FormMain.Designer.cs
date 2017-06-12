namespace DevDive.Main
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.analToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.certificadoDeAnáliseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impressãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vinculoDeProcessosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acompanharPedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analToolStripMenuItem,
            this.certificadoDeAnáliseToolStripMenuItem,
            this.cadastrosToolStripMenuItem,
            this.produçãoToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(579, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // analToolStripMenuItem
            // 
            this.analToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem});
            this.analToolStripMenuItem.Name = "analToolStripMenuItem";
            this.analToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analToolStripMenuItem.Text = "Análises";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            this.cadastroToolStripMenuItem.Click += new System.EventHandler(this.cadastroToolStripMenuItem_Click);
            // 
            // certificadoDeAnáliseToolStripMenuItem
            // 
            this.certificadoDeAnáliseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.impressãoToolStripMenuItem});
            this.certificadoDeAnáliseToolStripMenuItem.Name = "certificadoDeAnáliseToolStripMenuItem";
            this.certificadoDeAnáliseToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.certificadoDeAnáliseToolStripMenuItem.Text = "Certificado de Análise";
            // 
            // impressãoToolStripMenuItem
            // 
            this.impressãoToolStripMenuItem.Name = "impressãoToolStripMenuItem";
            this.impressãoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.impressãoToolStripMenuItem.Text = "Impressão";
            this.impressãoToolStripMenuItem.Click += new System.EventHandler(this.impressãoToolStripMenuItem_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processosToolStripMenuItem,
            this.vinculoDeProcessosToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Processos";
            // 
            // processosToolStripMenuItem
            // 
            this.processosToolStripMenuItem.Name = "processosToolStripMenuItem";
            this.processosToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.processosToolStripMenuItem.Text = "Cadastro";
            this.processosToolStripMenuItem.Click += new System.EventHandler(this.processosToolStripMenuItem_Click);
            // 
            // vinculoDeProcessosToolStripMenuItem
            // 
            this.vinculoDeProcessosToolStripMenuItem.Name = "vinculoDeProcessosToolStripMenuItem";
            this.vinculoDeProcessosToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.vinculoDeProcessosToolStripMenuItem.Text = "Vinculo";
            this.vinculoDeProcessosToolStripMenuItem.Click += new System.EventHandler(this.vinculoDeProcessosToolStripMenuItem_Click);
            // 
            // produçãoToolStripMenuItem
            // 
            this.produçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorarToolStripMenuItem,
            this.acompanharPedidosToolStripMenuItem});
            this.produçãoToolStripMenuItem.Name = "produçãoToolStripMenuItem";
            this.produçãoToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.produçãoToolStripMenuItem.Text = "Produção";
            this.produçãoToolStripMenuItem.Click += new System.EventHandler(this.produçãoToolStripMenuItem_Click);
            // 
            // monitorarToolStripMenuItem
            // 
            this.monitorarToolStripMenuItem.Name = "monitorarToolStripMenuItem";
            this.monitorarToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.monitorarToolStripMenuItem.Text = "Monitorar OP\'s";
            this.monitorarToolStripMenuItem.Click += new System.EventHandler(this.monitorarToolStripMenuItem_Click);
            // 
            // acompanharPedidosToolStripMenuItem
            // 
            this.acompanharPedidosToolStripMenuItem.Name = "acompanharPedidosToolStripMenuItem";
            this.acompanharPedidosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.acompanharPedidosToolStripMenuItem.Text = "Acompanhar pedidos";
            this.acompanharPedidosToolStripMenuItem.Click += new System.EventHandler(this.acompanharPedidosToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(579, 434);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assitente de Produção";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vinculoDeProcessosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acompanharPedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem certificadoDeAnáliseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impressãoToolStripMenuItem;
    }
}

