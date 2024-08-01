using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventario
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public Produto()
        {
            
        }
        public Produto(string nome, int quantidade)
        {
            this.Nome = nome;
            this.Quantidade = quantidade;
        }
    }
}
