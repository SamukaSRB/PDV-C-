using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class FrmFuncionario : Form
    {  
        //public string ID, Nome, Cpf, Tel, Endereco, Cargo, Foto;

        Conexao con = new Conexao();
        string sql;
        string id;
        MySqlCommand cmd;
        
        string foto;
        string alterouImagem = "nao";
        string cpfAntigo;

        public FrmFuncionario()
        {
            InitializeComponent();
        

        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            LimparFoto();          
            Lista();
            listarCargos();
            alterouImagem = "nao";
            cbCargo.Text = "Selecione um cargo";



        }

        public void Lista()
        {
            listar();
           // Conexao.Listar(grid);
           FormatarGrid();
        }

        public void listarCargos()
        {
            con.AbrirConexao();
            sql = "Select * from  cargos ORDER BY nome DESC";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbCargo.DataSource =dt;
            cbCargo.DisplayMember = "nome";
            con.fecharConexao();
        } 

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            txtNome.Focus();
            cbCargo.Text = "Selecione um cargo";
        }

        public void listar()
        {
            con.AbrirConexao();
            sql = "Select * from funcionarios Order By nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grid.DataSource = tbl;
            con.fecharConexao();
            
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

            if (txtTel.Text == "(  )       -" || txtCpf.Text.Length < 10)
            {
                MessageBox.Show("Preencha o campo do Telefone", "Cadastro Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTel.Focus();
                return;
            }

            sql = "Insert into funcionarios(nome, cpf, telefone, cargo, endereco, foto) values (@nome,@cpf,@telefone,@cargo,@endereco,@foto)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTel.Text);
            cmd.Parameters.AddWithValue("@cargo", cbCargo.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEnd.Text);
            cmd.Parameters.AddWithValue("@foto", img());

            cmd.ExecuteNonQuery();
            con.fecharConexao();
            //Funcionario func = new Funcionario(txtNome.Text, txtCpf.Text.Trim(), txtTel.Text.Trim(), cbCargo.Text.Trim(), txtEnd.Text.Trim(), img().ToString());
            //Conexao.AddFuncionario(func);
            Clear();
            listar();




        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha  o campo nome ", "Cadastro de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            if (txtCpf.Text == "   ,   ,   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha  o campo CPF ", "Cadastro de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return;
            }
            con.AbrirConexao();
            if (alterouImagem == "sim")
            {
                sql = "Update funcionarios Set nome = @nome , cpf = @cpf, endereco = @endereco, telefone = @telefone, cargo = @cargo, foto = @foto where ID = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTel.Text);
                cmd.Parameters.AddWithValue("@cargo", cbCargo.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEnd.Text);
                cmd.Parameters.AddWithValue("@foto", img());

            }
            else if (alterouImagem == "nao")
            {
                sql = "Update funcionarios Set nome = @nome , cpf = @cpf, endereco = @endereco, telefone = @telefone, cargo = @cargo, foto = @foto where ID = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTel.Text);
                cmd.Parameters.AddWithValue("@cargo", cbCargo.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEnd.Text);
                cmd.Parameters.AddWithValue("@foto", img());

            }
            //Verifica se existe cpf
            if (txtCpf.Text != cpfAntigo)
            {
                MySqlCommand cmdVerificar;
                cmdVerificar = new MySqlCommand("Select * from  funcionarios where cpf = @ cpf ", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já esta cadastrado", "Cadastro de funcionários", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCpf.Text = "";
                    txtCpf.Focus();
                    return;
                }

            }

            cmd.ExecuteNonQuery();
            con.fecharConexao();

            Lista();

            MessageBox.Show("Registro editado com sucesso", "Cadastro de funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            desabilitarCampos();
            Clear();
            LimparFoto();
            alterouImagem = "nao";




        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            var resp = MessageBox.Show("Deseja realmente excluir esse registro!", "Cadastro funcionários", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(resp == DialogResult.Yes)
            {
                con.AbrirConexao();
                sql = "Delete From funcionarios Where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.fecharConexao();

                MessageBox.Show("Registro excluido com sucesso!", "Cadastro funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = false;
                desabilitarCampos();
                Clear();
                LimparFoto();
                listar();
                              
            }

        
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Imagens(*.jpg; *.png)| *.jpg;*.png";
            if(dialog.ShowDialog()== DialogResult.OK)
            {
                foto = dialog.FileName.ToString();
                image.ImageLocation = foto;
                alterouImagem = "sim";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;   
            btnNovo.Enabled = true;
            desabilitarCampos();
            LimparFoto();
            Clear();


        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                habilitarCampos();
              

                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnNovo.Enabled = false;

                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
                txtCpf.Text = grid.CurrentRow.Cells[2].Value.ToString();
                cpfAntigo = grid.CurrentRow.Cells[2].Value.ToString();
                txtTel.Text = grid.CurrentRow.Cells[3].Value.ToString();
                cbCargo.Text = grid.CurrentRow.Cells[4].Value.ToString();
                txtEnd.Text = grid.CurrentRow.Cells[5].Value.ToString();



                if (grid.CurrentRow.Cells[6].Value != DBNull.Value)
                {
                    byte[] imagem = (byte[])grid.Rows[e.RowIndex].Cells[6].Value;
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

        public void FormatarGrid()                  
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Nome";
            grid.Columns[2].HeaderText = "Cpf";
            grid.Columns[3].HeaderText = "Telefone";
            grid.Columns[4].HeaderText = "Cargo";
            grid.Columns[5].HeaderText = "Endereco";          
            grid.Columns[6].HeaderText = "Imagem";

            grid.Columns[0].Width = 50;
            grid.Columns[1].Width = 250;
            grid.Columns[5].Width = 100;
            grid.Columns[5].Width = 250;
            grid.Columns[6].Width = 50;

            grid.Columns[0].Visible = true;
            grid.Columns[6].Visible = false;

        }
       
        private void habilitarCampos()
        {
            btnFoto.Enabled = true;
            btnCancelar.Enabled = true;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;


            txtNome.Enabled = true;
            txtCpf.Enabled = true;
            txtEnd.Enabled = true;
            txtTel.Enabled = true;
            cbCargo.Enabled = true;
        }

        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCpf.Enabled = false;
            txtEnd.Enabled = false;
            txtTel.Enabled = false;
            cbCargo.Enabled =false;
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

        public void Clear()
        {
            txtNome.Text = txtCpf.Text = txtTel.Text = cbCargo.Text = txtEnd.Text =  string.Empty;
        }

    }
}
