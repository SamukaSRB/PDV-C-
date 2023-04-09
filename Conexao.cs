using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV
{
    class Conexao
    {
        public string conec = "Server=localhost;port=3306;username=root;password=samuka.201232;database=pdv";

        public MySqlConnection con = null;

        public void AbrirConexao()
        {
            con = new MySqlConnection(conec);
            con.Open();
        }

        public void fecharConexao()
        {
            con = new MySqlConnection(conec);
            con.Close();
            con.Dispose();
            con.ClearAllPoolsAsync();
        }


        //public static MySqlConnection GetConnection()
        //{
        //    string sql = "datasource=localhost;port=3306;username=root;password=samuka.201232;database=pdv";
        //    MySqlConnection con = new MySqlConnection(sql);
        //    try
        //    {
        //        con.Open();
        //    }
        //    catch (MySqlException ex)
        //    {

        //        MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return con;
        //}

        //public static void Listar(DataGridView grid)
        //{

        //    string sql = "Select * from funcionarios Order By nome asc";

        //    MySqlConnection con = GetConnection();         
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
        //    DataTable tbl = new DataTable();
        //    adp.Fill(tbl);
        //    grid.DataSource = tbl;

        //    con.Close();
        //}
        //public static void AddFuncionario(Funcionario func)
        //{
        //    string sql = "Insert into funcionarios(nome, cpf, telefone, cargo, endereco, foto) values (@nome,@cpf,@telefone,@cargo,@endereco,@foto)";

        //    MySqlConnection con = GetConnection();
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value =func.Nome;
        //    cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = func.Cpf;
        //    cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = func.Telefone;
        //    cmd.Parameters.Add("@cargo", MySqlDbType.VarChar).Value = func.Cargo;
        //    cmd.Parameters.Add("@endereco", MySqlDbType.VarChar).Value = func.Endereco;
        //    cmd.Parameters.Add("@foto", MySqlDbType.VarChar).Value = func.Foto;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (MySqlException)
        //    {
        //        MessageBox.Show("Added not insert", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }

        //    con.Close();


        //}

        

    }
}
