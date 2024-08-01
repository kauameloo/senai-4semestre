using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventario.Test
{
    public class controleUnitTest
    {
        [Fact]
        public void AdicionarProduto_QuantidadeIncorreta_DeveFalhar()
        {
            // Arrange
            string nomeProduto = "Produto C";
            int quantidadeProduto = 10;

            // Act
            controleInventario.AdicionarProduto(nomeProduto, quantidadeProduto);
            var produtoObtido = controleInventario.ObterProduto(nomeProduto);

            // Assert - Espera que a quantidade seja 5, o que é incorreto e deve fazer o teste falhar
            Assert.NotNull(produtoObtido);  // Verifica se o produto foi adicionado
            Assert.Equal(nomeProduto, produtoObtido.Nome);
            Assert.Equal(10, produtoObtido.Quantidade);  // Valor incorreto para forçar a falha
        }
    }
}
