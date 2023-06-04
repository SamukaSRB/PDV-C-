using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.cadastro
{
    public partial class FrmUsuario : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string foto;
        string i8d;


        public FrmUsuario()
        {
            InitializeComponent();
            
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            listarUsuario();
        }

        public void listarUsuario()
        {
            con.AbrirConexao();
            sql = "select * from usuario order by nome desc";
            cmd = new  MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.fecharConexao();


        }

        
    }
}
