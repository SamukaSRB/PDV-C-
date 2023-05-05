namespace PDV.cadastro
{
    partial class FrmCliente
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
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbInadiplente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFoto = new System.Windows.Forms.Button();
            this.image = new System.Windows.Forms.PictureBox();
            this.txtBuscarNome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuscarCpf = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.Funcionario = new System.Windows.Forms.Label();
            this.cbFuncionario = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(336, 183);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 38;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(491, 106);
            this.txtTelefone.Mask = "(99) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(104, 20);
            this.txtTelefone.TabIndex = 28;
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(491, 68);
            this.txtCpf.Mask = "000.000.000-00";
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(104, 20);
            this.txtCpf.TabIndex = 27;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(254, 183);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(173, 183);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 35;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(92, 183);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 34;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(11, 183);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 33;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(7, 213);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(873, 226);
            this.grid.TabIndex = 32;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(13, 106);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(460, 20);
            this.txtEndereco.TabIndex = 29;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 67);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(333, 20);
            this.txtNome.TabIndex = 26;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(12, 90);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(53, 13);
            this.lblEndereco.TabIndex = 24;
            this.lblEndereco.Text = "Endereço";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(488, 91);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(49, 13);
            this.lblTelefone.TabIndex = 23;
            this.lblTelefone.Text = "Telefone";
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(488, 51);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(23, 13);
            this.lblCpf.TabIndex = 22;
            this.lblCpf.Text = "Cpf";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(10, 51);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 21;
            this.lblNome.Text = "Nome";
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(355, 68);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(118, 20);
            this.txtCod.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Codigo";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 152);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(460, 20);
            this.txtEmail.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "E-mail";
            // 
            // cbInadiplente
            // 
            this.cbInadiplente.FormattingEnabled = true;
            this.cbInadiplente.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cbInadiplente.Location = new System.Drawing.Point(601, 66);
            this.cbInadiplente.Name = "cbInadiplente";
            this.cbInadiplente.Size = new System.Drawing.Size(104, 21);
            this.cbInadiplente.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(598, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Inadiplente";
            // 
            // btnFoto
            // 
            this.btnFoto.Location = new System.Drawing.Point(711, 150);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(146, 23);
            this.btnFoto.TabIndex = 48;
            this.btnFoto.Text = "Carregar Foto";
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.image.Location = new System.Drawing.Point(711, 12);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(146, 127);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 47;
            this.image.TabStop = false;
            // 
            // txtBuscarNome
            // 
            this.txtBuscarNome.Location = new System.Drawing.Point(11, 28);
            this.txtBuscarNome.Name = "txtBuscarNome";
            this.txtBuscarNome.Size = new System.Drawing.Size(461, 20);
            this.txtBuscarNome.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Buscar por Nome";
            // 
            // txtBuscarCpf
            // 
            this.txtBuscarCpf.Location = new System.Drawing.Point(601, 28);
            this.txtBuscarCpf.Mask = "000.000.000-00";
            this.txtBuscarCpf.Name = "txtBuscarCpf";
            this.txtBuscarCpf.Size = new System.Drawing.Size(104, 20);
            this.txtBuscarCpf.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(598, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Buscar por Cpf";
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Location = new System.Drawing.Point(491, 25);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(104, 23);
            this.btnLocalizar.TabIndex = 53;
            this.btnLocalizar.Text = "Localizar";
            this.btnLocalizar.UseVisualStyleBackColor = true;
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // Funcionario
            // 
            this.Funcionario.AutoSize = true;
            this.Funcionario.Location = new System.Drawing.Point(598, 90);
            this.Funcionario.Name = "Funcionario";
            this.Funcionario.Size = new System.Drawing.Size(62, 13);
            this.Funcionario.TabIndex = 55;
            this.Funcionario.Text = "Funcionario";
            // 
            // cbFuncionario
            // 
            this.cbFuncionario.FormattingEnabled = true;
            this.cbFuncionario.Location = new System.Drawing.Point(601, 106);
            this.cbFuncionario.Name = "cbFuncionario";
            this.cbFuncionario.Size = new System.Drawing.Size(104, 21);
            this.cbFuncionario.TabIndex = 54;
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(899, 450);
            this.Controls.Add(this.Funcionario);
            this.Controls.Add(this.cbFuncionario);
            this.Controls.Add(this.btnLocalizar);
            this.Controls.Add(this.txtBuscarNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBuscarCpf);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFoto);
            this.Controls.Add(this.image);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbInadiplente);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.lblNome);
            this.Name = "FrmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCliente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.MaskedTextBox txtCpf;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbInadiplente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.TextBox txtBuscarNome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtBuscarCpf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLocalizar;
        private System.Windows.Forms.Label Funcionario;
        private System.Windows.Forms.ComboBox cbFuncionario;
    }
}