using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void MenuSair_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show("Deseja realmente sair!", "Cadastro funcionários", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                this.Close();
            }
                
        }

        private void MenuFuncionarios_Click(object sender, EventArgs e)
        {
            cadastro.FrmFuncionario frm = new cadastro.FrmFuncionario();
            frm.ShowDialog();
        }

        private void MenuCargos_Click(object sender, EventArgs e)
        {
            cadastro.FrmCargo frm = new cadastro.FrmCargo();
            frm.ShowDialog();
        }

        private void MenuClientes_Click(object sender, EventArgs e)
        {
            cadastro.FrmCliente frm = new cadastro.FrmCliente();
            frm.ShowDialog();
        }

        private void MenuFornecedor_Click(object sender, EventArgs e)
        {
            cadastro.FrmFornecedor frm = new cadastro.FrmFornecedor();
            frm.ShowDialog();
        }

        private void MenuProduto_Click(object sender, EventArgs e)
        {
            cadastro.FrmProduto frm = new cadastro.FrmProduto();
            frm.ShowDialog();
        }
    }
}
    