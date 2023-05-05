using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.cadastro
{
    public partial class FrmFornecedor : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        string id;
        string cnpjAntigo;
        bool cnpj = false;
        public FrmFornecedor()
        {
            InitializeComponent();
        }

        private void FormatarGD()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Nome";
            grid.Columns[2].HeaderText = "CNPJ";
            grid.Columns[3].HeaderText = "Endereço";
            grid.Columns[4].HeaderText = "Telefone";            

            //grid.Columns[2].Width = 250;

            grid.Columns[0].Visible = false;

        }
        private void Listar()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM fornecedores ORDER BY nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.fecharConexao();

            FormatarGD();
        }
        private void BuscarNome()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM fornecedores WHERE nome LIKE @nome ORDER BY nome asc"; //LIKE, busca nome por aproximacao
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");  //"%" - operador LIKE, busca nome por aproximacao
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.fecharConexao();

            FormatarGD();
        }
        private void BuscarCnpj()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM fornecedores WHERE cnpj = @cnpj ORDER BY nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cnpj", txtBuscarCnpj.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.fecharConexao();

            FormatarGD();
        }
        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            cnpj = true;
            HabilitarCampos();
            LimparCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            Listar();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome", "Cadastro fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            //if (txtCnpj.Text == "  .   .   /    -" || txtCnpj.Text.Length < 18)
            //{
            //    MessageBox.Show("Preencha o campo CNPJ", "Cadastro fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCnpj.Focus();
            //    return;
            //}

            //botao salvar
            con.AbrirConexao();
            sql = "INSERT INTO fornecedores(nome, cnpj, endereco, telefone) VALUES(@nome, @cnpj, @endereco,@telefone)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@cnpj", txtCnpj.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);

            //Verificar se cnpj ja existe
            Verificar();

            cmd.ExecuteNonQuery();
            con.fecharConexao();

            Listar();

            MessageBox.Show("Registro Salvo com sucesso!", "Cadastro fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            DesabilitarCampos();
            LimparCampos();
            cnpj = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            //if (txtCnpj.Text == "  .   .   /    -" || txtCnpj.Text.Length < 18)
            //{
            //    MessageBox.Show("Preencha o campo CPF", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCnpj.Focus();
            //    return;
            //}

            //botao editar
            con.AbrirConexao();
            sql = "UPDATE fornecedores SET nome = @nome, cnpj = @cnpj, endereco = @endereco where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@cnpj", txtCnpj.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);


            //Verificar se cpf ja existe
            if (txtCnpj.Text != cnpjAntigo)
            {
                MySqlCommand cmdVerificar;
                cmdVerificar = new MySqlCommand("SELECT * FROM fornecedores WHERE cnpj = @cnpj", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cnpj", txtCnpj.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já registrado", "Cadastro de fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCnpj.Text = "";
                    txtCnpj.Focus();
                    return;
                }

            }

            cmd.ExecuteNonQuery();
            con.fecharConexao();
            Listar();

            MessageBox.Show("Registro Editado com sucesso!", "Cadastro fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            DesabilitarCampos();
            LimparCampos();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Deseja realmente excluir o registro!", "Cadastro fornecedores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //botao excluir
                con.AbrirConexao();
                sql = "DELETE FROM fornecedores WHERE id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.fecharConexao();
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                DesabilitarCampos();
                LimparCampos();
                Listar();
                MessageBox.Show("Registro Excluído com sucesso!", "Cadastro fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                HabilitarCampos();

                cnpjAntigo = grid.CurrentRow.Cells[2].Value.ToString();
                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
                txtCnpj.Text = grid.CurrentRow.Cells[2].Value.ToString();
                txtEndereco.Text = grid.CurrentRow.Cells[3].Value.ToString();
                txtTelefone.Text = grid.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                return;
            }
        }
       
        private void Verificar()
        {
            //Verificar se cnpj ja existe  
            MySqlCommand cmdVerificar;
            cmdVerificar = new MySqlCommand("SELECT * FROM fornecedores WHERE cnpj = @cnpj", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            cmdVerificar.Parameters.AddWithValue("@cnpj", txtCnpj.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("CPF já registrado", "Cadastro de fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCnpj.Text = "";
                txtCnpj.Focus();
                return;
            }
        }
        private void txtCnpj_Leave(object sender, EventArgs e)
        {
            if (cnpj == true)
            {
                Verificar();
            }

        }
        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }
        private void txtBuscarCnpj_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarCnpj.Text == "  .   .   /    -")
            {
                Listar();
            }
            else { BuscarCnpj(); }
        }    
        private void rbNome_CheckedChanged_1(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = true;
            txtBuscarCnpj.Visible = false;
            txtBuscarCnpj.Text = "";
            txtBuscarNome.Text = "";
        }
        private void rbCnpj_CheckedChanged_1(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = false;
            txtBuscarCnpj.Visible = true;
            txtBuscarCnpj.Text = "";
            txtBuscarNome.Text = "";
        }
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCnpj.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
        }
        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtCnpj.Enabled = true;
            txtEndereco.Enabled = true;
            txtTelefone.Enabled = true;
            txtNome.Focus();
        }
        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCnpj.Enabled = false;
            txtEndereco.Enabled = false;
            txtTelefone.Enabled = false;

        }

       
    }
}
