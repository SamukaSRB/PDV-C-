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
    public partial class FrmProduto : Form
    {
        Conexao con = new Conexao();
        string sql;
        string id;
        MySqlCommand cmd;

        double vCompra,vVenda,lucro, vUnitario ;
        int Entrada;

        public FrmProduto()
        {
            InitializeComponent();
        }
        private void FrmProduto_Load(object sender, EventArgs e)
        {
            listar();
            ListarFornecedor();
            listarCategorias();
            desabilitarCampos();
        }        
        public void listar()
        {
            con.AbrirConexao();
            sql = " Select * from produtos Order By nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            grid.DataSource = tbl;
            con.fecharConexao();
            FormatarGrid();
        }
        public void listarCategorias()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM categorias ORDER BY nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbCategorias.DataSource = dt;
            cbCategorias.ValueMember = "id"; //vou usar o ID para relacionar o Produto com o categorias
            cbCategorias.DisplayMember = "nome"; //aqui mostrar o nome no comboBox
            con.fecharConexao();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            
            habilitarCampos();
            txtCodigoDeBarra.Focus();
            cbCategorias.Text = "Selecione uma categoria";
            limparCampos();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            con.AbrirConexao();
            verificar();

            if (txtCodigoDeBarra.Text.ToString().Trim() == "")
            {
             
                MessageBox.Show("Preencha o campo Código de barra", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoDeBarra.Focus();
          
                return;
            }
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Nome", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }
            if (cbFornecedor.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Fornecedor", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }
            if (cbCategorias.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Escolha uma categoria", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCategorias.Focus();
                return;
            }
            if (txtDescrição.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Cadastre uma embalagem", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescrição.Focus();
                return;
            }

            if (int.Parse(txtEntrada.Text) < 1) 
            {
                MessageBox.Show("Preencha quantidade de Entrada", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEntrada.Text = "0";
                txtEntrada.Focus();
                return;
            }
            //if (vCompra < 0.01)
            //{
            //    MessageBox.Show("Preencha o valor total da compra", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCompra.Focus();
            //    return;
            //}
            if (Convert.ToDouble(txtVenda.Text) < 0.01)
            {
                MessageBox.Show("Preencha o valor da venda", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVenda.Focus();
                return;
            }
            if (txtVenda.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o valor de venda", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVenda.Focus();
                return;
            }

            vCompra = Convert.ToDouble(txtCompra.Text);
            vVenda = Convert.ToDouble(txtVenda.Text);
            vUnitario = Convert.ToDouble(txtVenda.Text);
            Entrada = int.Parse(txtEntrada.Text);

            sql = "Insert into produtos(codigobarras, nome, fornecedor, categoria, embalagem, estminimo, estatual, entrada, vcompra, vunitario, vvenda, lucro) values (@codigobarras, @nome, @fornecedor, @categoria, @embalagem, @estminimo, @estatual, @entrada, @vcompra, @vunitario, @vvenda, @lucro)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@codigobarras", txtCodigoDeBarra.Text);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.Text);          
            cmd.Parameters.AddWithValue("@categoria", cbCategorias.Text);
            cmd.Parameters.AddWithValue("@embalagem", txtDescrição.Text);
            cmd.Parameters.AddWithValue("@estminimo", txtMinimo.Text);
            cmd.Parameters.AddWithValue("@estatual", txtAtual.Text);
            cmd.Parameters.AddWithValue("@entrada", Convert.ToInt32(txtEntrada.Text));
            cmd.Parameters.AddWithValue("@vcompra", Convert.ToDouble(txtCompra.Text)); 
            cmd.Parameters.AddWithValue("@vunitario", Convert.ToDouble(txtUnitario.Text));
            cmd.Parameters.AddWithValue("@vvenda", Convert.ToDouble(txtVenda.Text));
            cmd.Parameters.AddWithValue("@lucro", Convert.ToDouble(txtVenda.Text) - Convert.ToDouble(txtUnitario.Text));
           
            cmd.ExecuteNonQuery();
            con.fecharConexao();
            MessageBox.Show("Registro salvo com sucesso", "Cadastro de produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listar();
            limparCampos();
            
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {

            con.AbrirConexao();
            //     verificar();

            if (txtCodigoDeBarra.Text.ToString().Trim() == "")
            {

                MessageBox.Show("Preencha o campo Código de barra", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoDeBarra.Focus();

                return;
            }
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Nome", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }
            if (cbFornecedor.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Fornecedor", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }
            if (cbCategorias.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Escolha uma categoria", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCategorias.Focus();
                return;
            }
            if (txtDescrição.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Cadastre uma embalagem", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescrição.Focus();
                return;
            }

            if (int.Parse(txtEntrada.Text) < 1)
            {
                MessageBox.Show("Preencha quantidade de Entrada", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEntrada.Text = "0";
                txtEntrada.Focus();
                return;
            }
            //if (vCompra < 0.01)
            //{
            //    MessageBox.Show("Preencha o valor total da compra", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCompra.Focus();
            //    return;
            //}
            if (Convert.ToDouble(txtVenda.Text) < 0.01)
            {
                MessageBox.Show("Preencha o valor da venda", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVenda.Focus();
                return;
            }
            if (txtVenda.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o valor de venda", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVenda.Focus();
                return;
            }

            vCompra = Convert.ToDouble(txtCompra.Text);
            vVenda = Convert.ToDouble(txtVenda.Text);
            vUnitario = Convert.ToDouble(txtVenda.Text);
            Entrada = int.Parse(txtEntrada.Text);

            //botao editar
            con.AbrirConexao();
            sql = "UPDATE produtos SET  codigobarras = @codigobarras, nome= @nome, fornecedor = @fornecedor, categoria = @categoria, embalagem = @embalagem, estminimo = @estminimo, estatual = @estatual, entrada = @entrada, vcompra = @vcompra, vunitario = @vunitario, vvenda = @vvenda, lucro = @lucro where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@codigobarras", txtCodigoDeBarra.Text);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.Text);
            cmd.Parameters.AddWithValue("@categoria", cbCategorias.Text);
            cmd.Parameters.AddWithValue("@embalagem", txtDescrição.Text);
            cmd.Parameters.AddWithValue("@estminimo", txtMinimo.Text);
            cmd.Parameters.AddWithValue("@estatual", txtAtual.Text);
            cmd.Parameters.AddWithValue("@entrada", Convert.ToInt32(txtEntrada.Text));
            cmd.Parameters.AddWithValue("@vcompra", Convert.ToDouble(txtCompra.Text));
            cmd.Parameters.AddWithValue("@vunitario", Convert.ToDouble(txtUnitario.Text));
            cmd.Parameters.AddWithValue("@vvenda", Convert.ToDouble(txtVenda.Text));
            cmd.Parameters.AddWithValue("@lucro", Convert.ToDouble(txtVenda.Text) - Convert.ToDouble(txtUnitario.Text));


            cmd.ExecuteNonQuery();
            con.fecharConexao();
            listar();

            MessageBox.Show("Registro Editado com sucesso!", "Cadastro produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            desabilitarCampos();
            limparCampos();

        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Deseja realmente excluir o registro!", "Cadastro de Produtos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //botao excluir
                con.AbrirConexao();
                sql = "DELETE FROM produtos WHERE id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.fecharConexao();
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                desabilitarCampos();
                limparCampos();
                listar();
                MessageBox.Show("Registro Excluído com sucesso!", "Cadastro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigoDeBarra.Focus();
            btnCancelar.Enabled = true;
            txtCodigoDeBarra.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            btnNovo.Enabled = true;
            grid.Enabled = true;

            listar();
            limparCampos();
            desabilitarCampos();

        }
        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            habilitarCampos();
            if (e.RowIndex > -1)
            {
                //habilitarCampos();


                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnNovo.Enabled = false;

                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtCodigoDeBarra.Text = grid.CurrentRow.Cells[1].Value.ToString();
                txtNome.Text = grid.CurrentRow.Cells[2].Value.ToString();
                cbFornecedor.Text = grid.CurrentRow.Cells[3].Value.ToString();
                cbCategorias.Text = grid.CurrentRow.Cells[4].Value.ToString();
                txtDescrição.Text = grid.CurrentRow.Cells[5].Value.ToString();
                txtMinimo.Text = grid.CurrentRow.Cells[6].Value.ToString();
                txtAtual.Text = grid.CurrentRow.Cells[7].Value.ToString();
                txtEntrada.Text = grid.CurrentRow.Cells[8].Value.ToString();
                txtCompra.Text = grid.CurrentRow.Cells[9].Value.ToString();
                txtUnitario.Text = grid.CurrentRow.Cells[10].Value.ToString();
                txtVenda.Text = grid.CurrentRow.Cells[11].Value.ToString();
                txtLucro.Text = grid.CurrentRow.Cells[12].Value.ToString();

                //if (grid.CurrentRow.Cells[6].Value != DBNull.Value)
                //{
                //    byte[] imagem = (byte[])grid.Rows[e.RowIndex].Cells[6].Value;
                //    MemoryStream ms = new MemoryStream(imagem);
                //    image.Image = System.Drawing.Image.FromStream(ms);

                //}
                //else
                //{
                //    image.Image = Properties.Resources.camera;
                //}

            }
            else
            {
                return;

            }
        }






        private  void ListarFornecedor()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM fornecedores ORDER BY nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbFornecedor.DataSource = dt;
            cbFornecedor.ValueMember = "id"; //vou usar o ID para relacionar o Produto com o Fornecedor
            cbFornecedor.DisplayMember = "nome"; //aqui mostrar o nome no comboBox
            con.fecharConexao();
        }
        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(2, '0');

                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);

                v = Convert.ToDouble(n) / 100;

                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception)
            {
            }
        }
        private void verificar()
        {
            //Verificar se cod ja existe  
            MySqlCommand cmdVerificar;
            cmdVerificar = new MySqlCommand("SELECT * FROM produtos WHERE codigobarras = @codigobarras", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            cmdVerificar.Parameters.AddWithValue("@codigobarras", txtCodigoDeBarra.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Código de barra já registrado", "Cadastro de produtos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCodigoDeBarra.Text = "";
                txtCodigoDeBarra.Focus();
                return;
            }
        }
        //Eventos
        private void txtCompra_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtCompra);

            if (Convert.ToDouble(txtCompra.Text) < 0.01)
            {
                txtUnitario.Text = "0";
            }
            else
            {
                if (txtEntrada.Text.ToString().Trim() != "")
                {
                    vCompra = Convert.ToDouble(txtCompra.Text);
                    Entrada = Convert.ToInt32(txtEntrada.Text);
                    var rs = vCompra / Entrada;
                    //txtUnitario.Text = rs.ToString();
                     txtUnitario.Text = string.Format("{0:N}", rs);
                }
            }
        }     

        private void txtVenda_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtLucro);
            //if (Convert.ToDouble(txtVenda.Text) < 0.01)
            //{
            //    txtLucro.Text = "0";
            //}
            //else
            //{
                if (txtVenda.Text.ToString().Trim() != "")
                {
                    vVenda = Convert.ToDouble(txtVenda.Text);
                    vUnitario = Convert.ToDouble(txtUnitario.Text);
                    var rs = vUnitario - vVenda;
                    //txtUnitario.Text = rs.ToString();
                    txtLucro.Text = string.Format("{0:N}", rs);
                }

            //}
        }
        private void cbFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bloqueia a digitação,
            e.Handled = true;
        }
        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);
        }
        private void txtMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);
        }
        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);
        }
       





      
        private void desabilitarCampos()
        {
            btnCancelar.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            txtCodigoDeBarra.Enabled = false;
            txtNome.Enabled = false;
            cbFornecedor.Enabled = false;
            cbCategorias.Enabled = false;
            txtDescrição.Enabled =false;
            txtMinimo.Enabled = false;
            txtAtual.Enabled = false;
            txtEntrada.Enabled = false;
            txtCompra.Enabled =false;
            txtUnitario.Enabled = false;
            txtVenda.Enabled = false;
            txtLucro.Enabled =false;
        }
        private void habilitarCampos()
        {
            // btnFoto.Enabled = true;
            btnCancelar.Enabled = true;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = true;

            txtCodigoDeBarra.Enabled = true;
            txtNome.Enabled = true;
            cbFornecedor.Enabled = true;
            cbCategorias.Enabled = true;
            txtDescrição.Enabled = true;
            txtMinimo.Enabled = true;
            txtAtual.Enabled = true;
            txtEntrada.Enabled = true;
            txtCompra.Enabled = true;
            txtUnitario.Enabled = true;
            txtVenda.Enabled = true;
            txtLucro.Enabled = true;
        }

       

        private void limparCampos()
        {
            txtCodigoDeBarra.Text = "";
            txtNome.Text = "";
            cbCategorias.Text = "";
           // txtDescricao.Text = "";
           // txtBuscarNome.Text = "";
           // txtBuscarCod.Text = "";
            txtUnitario.Text = "0";
            txtEntrada.Text = "0";
            txtCompra.Text = "0";
            txtVenda.Text = "0";
            txtAtual.Text = "0";
            txtMinimo.Text = "0";        
            //txtNota.Text = "0";
            txtLucro.Text = "0";
            cbFornecedor.SelectedIndex = 0;

            //lblUltimaEntrada.Text = "0";
            //lblValorCompra.Text = "0,00";
            //lblValorVenda.Text = "0,00";
            //lblValorUnit.Text = "0,00";
            //lblLucro.Text = "0,00";
        }

     

        private void FormatarGrid()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Código";
            grid.Columns[2].HeaderText = "Produto";      
            grid.Columns[3].HeaderText = "Fornecedor";
            grid.Columns[4].HeaderText = "Categoria";
            grid.Columns[5].HeaderText = "Embalagem";
            grid.Columns[6].HeaderText = "Mínimo";
            grid.Columns[7].HeaderText = "Est Atual";
            grid.Columns[8].HeaderText = "Entrada";
            grid.Columns[9].HeaderText = "V.Compra";
            grid.Columns[10].HeaderText = "CustoUnit"; 
            grid.Columns[11].HeaderText = "V.Venda";
            grid.Columns[12].HeaderText = "Lucro"; 

            //gridum.Width[2] = "300";
            //formatar coluna  moeda
            grid.Columns[9].DefaultCellStyle.Format = "c2";
            grid.Columns[10].DefaultCellStyle.Format = "c2";
            grid.Columns[11].DefaultCellStyle.Format = "c2";
            grid.Columns[12].DefaultCellStyle.Format = "c2";
            grid.Columns[0].Visible = false;
            //grid.Columns[11].Visible = false;
            //grid.Columns[7].Visible = false;
        }
        private void formatarTextNumero(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -2)
                {
                    e.Handled = true;
                }


                if (e.KeyChar == ','
                    && (sender as TextBox).Text.IndexOf(',') > -2)
                {
                    e.Handled = true;
                }

                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
