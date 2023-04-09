using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV
{
     class Funcionario
    {
       
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Endereco { get; set; }
        public string Foto { get; set; }
    
        public Funcionario(string nome, string cpf, string telefone, string cargo, string endereco, string foto)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Cargo = cargo;
            this.Endereco = endereco;
            this.Foto = foto;
        }
    }
}
