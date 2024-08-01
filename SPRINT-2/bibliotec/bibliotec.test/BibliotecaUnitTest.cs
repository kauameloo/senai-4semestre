using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotec.test
{
    public class BibliotecaUnitTest
    {
        [Fact]
        public void VerificarLivro()
        {
            // Arrange
            string livro = "Um livro";
            string livroIncorreto = "Livro incorreto";

            // Act
            Biblioteca.AdicionarLivro(livro);
            List<string> livros = Biblioteca.ObterLivros();

            // Assert (comparando com um valor incorreto para falhar deliberadamente)
            Assert.Contains(livroIncorreto, livros);
        }
    }
}
