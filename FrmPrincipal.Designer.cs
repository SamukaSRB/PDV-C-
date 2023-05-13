namespace PDV
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MenuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCargos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovimentacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLancarVanda = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEntradaSaida = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDespesa = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProdutoRel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVendaRel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovimentoRel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEntradaSaidaRel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDespesaRel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCadastro,
            this.MenuProdutos,
            this.MenuMovimentacoes,
            this.MenuRelatorios,
            this.MenuSair});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(944, 24);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "menuStrip1";
            // 
            // MenuCadastro
            // 
            this.MenuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFuncionarios,
            this.MenuClientes,
            this.MenuUsuarios,
            this.MenuCargos,
            this.MenuFornecedor});
            this.MenuCadastro.Name = "MenuCadastro";
            this.MenuCadastro.Size = new System.Drawing.Size(71, 20);
            this.MenuCadastro.Text = "Cadastros";
            // 
            // MenuFuncionarios
            // 
            this.MenuFuncionarios.Name = "MenuFuncionarios";
            this.MenuFuncionarios.Size = new System.Drawing.Size(180, 22);
            this.MenuFuncionarios.Text = "Funcionários";
            this.MenuFuncionarios.Click += new System.EventHandler(this.MenuFuncionarios_Click);
            // 
            // MenuClientes
            // 
            this.MenuClientes.Name = "MenuClientes";
            this.MenuClientes.Size = new System.Drawing.Size(180, 22);
            this.MenuClientes.Text = "Clientes";
            this.MenuClientes.Click += new System.EventHandler(this.MenuClientes_Click);
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.Name = "MenuUsuarios";
            this.MenuUsuarios.Size = new System.Drawing.Size(180, 22);
            this.MenuUsuarios.Text = "Usuarios";
            // 
            // MenuCargos
            // 
            this.MenuCargos.Name = "MenuCargos";
            this.MenuCargos.Size = new System.Drawing.Size(180, 22);
            this.MenuCargos.Text = "Cargos";
            this.MenuCargos.Click += new System.EventHandler(this.MenuCargos_Click);
            // 
            // MenuFornecedor
            // 
            this.MenuFornecedor.Name = "MenuFornecedor";
            this.MenuFornecedor.Size = new System.Drawing.Size(180, 22);
            this.MenuFornecedor.Text = "Fornecedor";
            this.MenuFornecedor.Click += new System.EventHandler(this.MenuFornecedor_Click);
            // 
            // MenuProdutos
            // 
            this.MenuProdutos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProduto,
            this.MenuEstoque});
            this.MenuProdutos.Name = "MenuProdutos";
            this.MenuProdutos.Size = new System.Drawing.Size(67, 20);
            this.MenuProdutos.Text = "Produtos";
            // 
            // MenuProduto
            // 
            this.MenuProduto.Name = "MenuProduto";
            this.MenuProduto.Size = new System.Drawing.Size(180, 22);
            this.MenuProduto.Text = "Produto";
            this.MenuProduto.Click += new System.EventHandler(this.MenuProduto_Click);
            // 
            // MenuEstoque
            // 
            this.MenuEstoque.Name = "MenuEstoque";
            this.MenuEstoque.Size = new System.Drawing.Size(180, 22);
            this.MenuEstoque.Text = "Estoque";
            // 
            // MenuMovimentacoes
            // 
            this.MenuMovimentacoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCaixa,
            this.MenuLancarVanda,
            this.MenuEntradaSaida,
            this.MenuDespesa});
            this.MenuMovimentacoes.Name = "MenuMovimentacoes";
            this.MenuMovimentacoes.Size = new System.Drawing.Size(104, 20);
            this.MenuMovimentacoes.Text = "Movimentações";
            // 
            // MenuCaixa
            // 
            this.MenuCaixa.Name = "MenuCaixa";
            this.MenuCaixa.Size = new System.Drawing.Size(163, 22);
            this.MenuCaixa.Text = "Fluxo de Caixa";
            // 
            // MenuLancarVanda
            // 
            this.MenuLancarVanda.Name = "MenuLancarVanda";
            this.MenuLancarVanda.Size = new System.Drawing.Size(163, 22);
            this.MenuLancarVanda.Text = "Lançar Venda";
            // 
            // MenuEntradaSaida
            // 
            this.MenuEntradaSaida.Name = "MenuEntradaSaida";
            this.MenuEntradaSaida.Size = new System.Drawing.Size(163, 22);
            this.MenuEntradaSaida.Text = "Entradas / Saídas";
            // 
            // MenuDespesa
            // 
            this.MenuDespesa.Name = "MenuDespesa";
            this.MenuDespesa.Size = new System.Drawing.Size(163, 22);
            this.MenuDespesa.Text = "Despesas";
            // 
            // MenuRelatorios
            // 
            this.MenuRelatorios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProdutoRel,
            this.MenuVendaRel,
            this.MenuMovimentoRel,
            this.MenuEntradaSaidaRel,
            this.MenuDespesaRel});
            this.MenuRelatorios.Name = "MenuRelatorios";
            this.MenuRelatorios.Size = new System.Drawing.Size(71, 20);
            this.MenuRelatorios.Text = "Relatórios";
            // 
            // MenuProdutoRel
            // 
            this.MenuProdutoRel.Name = "MenuProdutoRel";
            this.MenuProdutoRel.Size = new System.Drawing.Size(163, 22);
            this.MenuProdutoRel.Text = "Produto";
            // 
            // MenuVendaRel
            // 
            this.MenuVendaRel.Name = "MenuVendaRel";
            this.MenuVendaRel.Size = new System.Drawing.Size(163, 22);
            this.MenuVendaRel.Text = "Vendas";
            // 
            // MenuMovimentoRel
            // 
            this.MenuMovimentoRel.Name = "MenuMovimentoRel";
            this.MenuMovimentoRel.Size = new System.Drawing.Size(163, 22);
            this.MenuMovimentoRel.Text = "Movimentos";
            // 
            // MenuEntradaSaidaRel
            // 
            this.MenuEntradaSaidaRel.Name = "MenuEntradaSaidaRel";
            this.MenuEntradaSaidaRel.Size = new System.Drawing.Size(163, 22);
            this.MenuEntradaSaidaRel.Text = "Entradas / Saídas";
            // 
            // MenuDespesaRel
            // 
            this.MenuDespesaRel.Name = "MenuDespesaRel";
            this.MenuDespesaRel.Size = new System.Drawing.Size(163, 22);
            this.MenuDespesaRel.Text = "Despesas";
            // 
            // MenuSair
            // 
            this.MenuSair.Name = "MenuSair";
            this.MenuSair.Size = new System.Drawing.Size(38, 20);
            this.MenuSair.Text = "Sair";
            this.MenuSair.Click += new System.EventHandler(this.MenuSair_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(944, 450);
            this.Controls.Add(this.MenuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastro;
        private System.Windows.Forms.ToolStripMenuItem MenuProdutos;
        private System.Windows.Forms.ToolStripMenuItem MenuMovimentacoes;
        private System.Windows.Forms.ToolStripMenuItem MenuRelatorios;
        private System.Windows.Forms.ToolStripMenuItem MenuSair;
        private System.Windows.Forms.ToolStripMenuItem MenuFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem MenuClientes;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem MenuCargos;
        private System.Windows.Forms.ToolStripMenuItem MenuFornecedor;
        private System.Windows.Forms.ToolStripMenuItem MenuProduto;
        private System.Windows.Forms.ToolStripMenuItem MenuEstoque;
        private System.Windows.Forms.ToolStripMenuItem MenuCaixa;
        private System.Windows.Forms.ToolStripMenuItem MenuLancarVanda;
        private System.Windows.Forms.ToolStripMenuItem MenuEntradaSaida;
        private System.Windows.Forms.ToolStripMenuItem MenuDespesa;
        private System.Windows.Forms.ToolStripMenuItem MenuProdutoRel;
        private System.Windows.Forms.ToolStripMenuItem MenuVendaRel;
        private System.Windows.Forms.ToolStripMenuItem MenuMovimentoRel;
        private System.Windows.Forms.ToolStripMenuItem MenuEntradaSaidaRel;
        private System.Windows.Forms.ToolStripMenuItem MenuDespesaRel;
    }
}

