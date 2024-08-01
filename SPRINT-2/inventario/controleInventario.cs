using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventario
{
    public class controleInventario
    {
        private static List<Produto> produtos = new List<Produto>();

        public static void AdicionarProduto(string nome, int quantidade)
        {
            var produto = produtos.FirstOrDefault(p => p.Nome == nome);
            if (produto != null)
            {
                produto.Quantidade += quantidade;
            }
            else
            {
                produtos.Add(new Produto(nome, quantidade));
            }
        }

        public static Produto ObterProduto(string nome)
        {
            return produtos.FirstOrDefault(p => p.Nome == nome);
        }
    }
}
