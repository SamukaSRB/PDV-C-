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
        //public string conec = "Server=localhost;port=3306;username=root;password=samuka.201232;database=pdv";
        //Servidor base
        public string conec = "Server=containers-us-west-85.railway.app;port=7787;username=root;password=eISMaMakZKyK656xhmdp;database=pdv";
        public MySqlConnection con = null;

        public void AbrirConexao()
        {

            try
            {
                con = new MySqlConnection(conec);
                con.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro de conexão com o Banco de Dados: " + ex.Message);
            }
           
        }

        public void fecharConexao()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
                con.Dispose();
                con.ClearAllPoolsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o Banco de Dados: " + ex.Message);
            }
           
        }

    }
}
