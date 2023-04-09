using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PDV.cadastro
{
    public partial class FrmCargo : Form
    {
        Conexao con = new Conexao();
        string sql;
        string id;
        string nomeAntigo;

        MySqlCommand cmd;

        public FrmCargo()
        {
            InitializeComponent();
        }

        private void FrmCargo_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void FormatarGrid()
        {
            grid.Columns[0].HeaderText = "ID";           
            grid.Columns[1].HeaderText = "Cargos";    
            
            grid.Columns[0].Visible = false;
        }

        public void Listar()
        {
            con.AbrirConexao();
            sql = "Select * from cargos Order By nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grid.DataSource = tbl;
            con.fecharConexao();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show("Deseja realmente excluir esse registro!", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                con.AbrirConexao();
                sql = "Delete From cargos Where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.fecharConexao();
                Listar();

                MessageBox.Show("Registro excluido com sucesso!", "Cadastro cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            con.AbrirConexao();

            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }        
           
            sql = "Insert into cargos(nome, data) values (@nome, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);         
            cmd.ExecuteNonQuery();
            con.fecharConexao();
            Listar();

            MessageBox.Show("Registro editado com sucesso", "Cadastro de cargos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha  o campo nome ", "Cadastro de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
          
            con.AbrirConexao();
           
                sql = "Update cargos Set nome = @nome where ID = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);

            //Verifica se existe nome
                if (txtNome.Text != nomeAntigo)
                 {
                MySqlCommand cmdVerificar;
                cmdVerificar = new MySqlCommand("Select * from  cargos where nome = @nome ", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@nome", txtNome.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Cargo ja  registrado", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }

            }

            cmd.ExecuteNonQuery();
            con.fecharConexao();

            Listar();

            MessageBox.Show("Registro editado com sucesso", "Cadastro de funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
           

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            btnSalvar.Enabled = true;
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
               
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnNovo.Enabled = false;

                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();

            }
            else
            {
                return;

            }
        }
    }
}
