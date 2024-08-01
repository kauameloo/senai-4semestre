using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotec
{
    public static class Biblioteca
    {
        private static List<string> livros = new List<string>();

        public static void AdicionarLivro(string livro)
        {
            livros.Add(livro);
        }

        public static List<string> ObterLivros()
        {
            return new List<string>(livros);
        }
    }
}
