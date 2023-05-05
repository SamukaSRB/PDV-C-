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

namespace PDV.cadastro
{
    public partial class FrmCliente : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string foto;
        string id;
        string alterouImagem = "nao";
        string cpfAntigo;

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Listar();
            LimparFoto();
            listarFuncionario();
        }

        public FrmCliente()
        {
            InitializeComponent();
        }

        public void listarFuncionario()
        {
            con.AbrirConexao();
            sql = "Select * from  funcionarios ORDER BY nome DESC";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbFuncionario.DataSource = dt;
            cbFuncionario.DisplayMember = "nome";
            con.fecharConexao();

        }

        private void Listar()
        {
            con.AbrirConexao();

            sql = "Select * from clientes Order By nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.fecharConexao();

            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;

            FormatarGrid();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            txtNome.Focus();
            cbFuncionario.Text = "Selecione um funcionario";

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            con.AbrirConexao();

            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o nome do funcionário", "Cadastro Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            if (txtCpf.Text == "   ,   ,   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo do CPF", "Cadastro Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }
            if (txtTelefone.Text == "(  )       -" || txtCpf.Text.Length < 10)
            {
                MessageBox.Show("Preencha o campo do Telefone", "Cadastro Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefone.Focus();
                return;
            }

            sql = "Insert into clientes(codigo, nome, cpf, tel, email, endereco, inadiplente, funcionario, imagem) values (@codigo, @nome, @cpf, @telefone, @email, @endereco, @inadiplente, @funcionario, @imagem)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@codigo", txtCod.Text);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@inadiplente", cbInadiplente.Text);
            cmd.Parameters.AddWithValue("@funcionario", cbFuncionario.Text);
            cmd.Parameters.AddWithValue("@imagem", img());

            cmd.ExecuteNonQuery();
            con.fecharConexao();

            MessageBox.Show("Registro salvo com sucesso", "Cadastro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimparCampos();
            Listar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha  o campo nome ", "Cadastro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            if (txtCpf.Text == "   ,   ,   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha  o campo CPF ", "Cadastro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return;
            }

            con.AbrirConexao();

            if (alterouImagem == "sim")
            {
                sql = "Update clientes Set codigo = @codigo, nome = @nome, cpf = @cpf, tel = @telefone, email = @email, endereco = @endereco, inadiplente = @inadiplente, funcionario = @funcionario, imagem = @imagem where ID = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@codigo", txtCod.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@inadiplente", cbInadiplente.Text);
                cmd.Parameters.AddWithValue("@funcionario", cbFuncionario.Text);
                cmd.Parameters.AddWithValue("@imagem", img());

            }
            else if (alterouImagem == "nao")
            {
                sql = "Update clientes Set codigo = @codigo, nome = @nome, cpf = @cpf, tel = @telefone, email = @email, endereco = @endereco, inadiplente = @inadiplente, funcionario = @funcionario, imagem = @imagem where ID = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@codigo", txtCod.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@inadiplente", cbInadiplente.Text);
                cmd.Parameters.AddWithValue("@funcionario", cbFuncionario.Text);
                cmd.Parameters.AddWithValue("@imagem", img());

            }

            if (txtCpf.Text != cpfAntigo)
            {
                MySqlCommand cmdVerificar;
                cmdVerificar = new MySqlCommand("Select * from  clientes where cpf = @cpf ", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já esta cadastrado", "Cadastro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCpf.Text = "";
                    txtCpf.Focus();
                    return;
                }

            }

            cmd.ExecuteNonQuery();
            con.fecharConexao();

            Listar();

            MessageBox.Show("Registro editado com sucesso", "Cadastro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimparCampos();
            LimparFoto();
            alterouImagem = "nao";

            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;

        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show("Deseja realmente excluir esse registro!", "Cadastro cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                con.AbrirConexao();
                sql = "Delete From clientes Where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.fecharConexao();

                MessageBox.Show("Registro excluido com sucesso!", "Cadastro clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = false;
                desabilitarCampos();
                LimparCampos();
                LimparFoto();
                Listar();

            }
        }
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void FormatarGrid()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Codigo";
            grid.Columns[2].HeaderText = "Nome";           
            grid.Columns[3].HeaderText = "Cpf";            
            grid.Columns[4].HeaderText = "Telefone";
            grid.Columns[5].HeaderText = "Email";
            grid.Columns[6].HeaderText = "Endereço";           
            grid.Columns[7].HeaderText = "Inadiplente";            
            grid.Columns[8].HeaderText = "Funcionário";
            grid.Columns[9].HeaderText = "Imagem";
          


            //grid.Columns[0].Visible = false;
            //grid.Columns[11].Visible = false;
            //grid.Columns[4].DefaultCellStyle.Format = "c2";

        }
               
        private void BuscarNome()
        {
            con.AbrirConexao();
            sql = "Select * from clientes Where nome=@nome ORDER BY nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.fecharConexao();

            FormatarGrid();

        }

        private void BuscarCpf()
        {
            con.AbrirConexao();
            sql = "Select  * from  clientes Where cpf=@cpf ORDER BY nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cpf", txtBuscarCpf.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.fecharConexao();
            FormatarGrid();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = false;

            if (e.RowIndex > -1)
            {
                HabilitarCampos();              

                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtCod.Text = grid.CurrentRow.Cells[1].Value.ToString();
                txtNome.Text = grid.CurrentRow.Cells[2].Value.ToString();                             
                txtCpf.Text = grid.CurrentRow.Cells[3].Value.ToString();
                cpfAntigo = grid.CurrentRow.Cells[3].Value.ToString();
                txtTelefone.Text = grid.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = grid.CurrentRow.Cells[5].Value.ToString();
                txtEndereco.Text = grid.CurrentRow.Cells[6].Value.ToString();               
                cbInadiplente.Text = grid.CurrentRow.Cells[7].Value.ToString();
                cbFuncionario.Text = grid.CurrentRow.Cells[8].Value.ToString();
               
                if (grid.CurrentRow.Cells[9].Value != DBNull.Value)
                {
                    byte[] imagem = (byte[])grid.Rows[e.RowIndex].Cells[9].Value;
                    MemoryStream ms = new MemoryStream(imagem);
                    image.Image = System.Drawing.Image.FromStream(ms);

                }
                else
                {
                    image.Image = Properties.Resources.camera;
                }

            }
            else
            {
                return;
            }
        
        }

        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtCpf.Enabled = true;
            txtEndereco.Enabled = true;
            txtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            cbInadiplente.Enabled = true;
        
        }

        private void desabilitarCampos()
        {
            txtCod.Enabled = false;
            txtNome.Enabled = false;
            txtCpf.Enabled = false;
            txtEndereco.Enabled = false;
            txtTelefone.Enabled = false;
            cbFuncionario.Enabled = false;
            txtEmail.Enabled = false;
        }
       
        private void LimparCampos()
        {
            txtCod.Text = "";
            txtNome.Text = "";
            txtCpf.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            cbInadiplente.SelectedIndex = 0;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Imagens(*.jpg; *.png)| *.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString();
                image.ImageLocation = foto;
                alterouImagem = "sim";
            }
        }

        private byte[] img()
        {
            byte[] imagem_byte = null;

            if (foto == "")
            {
                return null;
            }

            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            imagem_byte = br.ReadBytes((int)fs.Length);

            return imagem_byte;
        }

        private void LimparFoto()
        {
            image.Image = Properties.Resources.camera;
            foto = "img/camera.png";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
            desabilitarCampos();
            LimparFoto();
            LimparCampos();
        }
    }
    
}
