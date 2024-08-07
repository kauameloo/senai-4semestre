using Microsoft.Identity.Client;
using Moq;
using ProdutoApiTest.Domains;
using ProdutoApiTest.Interface;
using ProdutoApiTest.Repositories;

namespace ProdutosApiTestUnit
{
    public class ProductsTest
    {
        /// <summary>
        /// Teste para a funcionalidade de listar todos os produtos
        /// </summary>
        [Fact]

        public void Get()
        {
            //Arrange

            //lista de produtos
            List<Products> productList = new List<Products>
            {
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 1", Price = 78 },
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 2", Price = 90 },
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 3", Price = 787 }

            };

            //Cria um objeto de simulação do tipo ProductRepository
            var mockRepository = new Mock<IProductsRepository>();
            //Configura o metodo Get para que retorne a lista mockada
            mockRepository.Setup(x => x.Get()).Returns(productList);

            //Act
            //Executando o metodo Get e atribui a resposta em result 
            var result = mockRepository.Object.Get();

            //Assert
            Assert.Equal(3, result.Count);

        }
        [Fact]
        public void Post()
        {

            //Criar o objeto
            Products product = new Products { IdProduct = Guid.NewGuid(), Name = "Rolex", Price = 99 };

            //Criar a lista
            List<Products> productList = new List<Products>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Post(product)).Callback<Products>(x => productList.Add(product));

            //Act
            mockRepository.Object.Post(product);

            //Assert
            Assert.Contains(product, productList);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Products { IdProduct = productId, Name = "Produto para deletar", Price = 50 };
            var productList = new List<Products> { product };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Delete(productId)).Callback<Guid>(id => productList.RemoveAll(p => p.IdProduct == id));

            // Act
            mockRepository.Object.Delete(productId);

            // Assert
            Assert.DoesNotContain(productList, p => p.IdProduct == productId);
        }


        [Fact]
        public void GetById()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Products { IdProduct = productId, Name = "Produto 1", Price = 78 };
            var productList = new List<Products> { product };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.GetById(productId)).Returns(product);

            // Act
            var result = mockRepository.Object.GetById(productId);

            // Assert
            Assert.Equal(product, result);
        }


        [Fact]
        public void Update()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Products { IdProduct = productId, Name = "Produto Original", Price = 50 };
            var updatedProduct = new Products { IdProduct = productId, Name = "Produto Atualizado", Price = 100 };
            var productList = new List<Products> { product };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Put(productId, updatedProduct)).Callback<Guid, Products>((id, prod) => {
                var index = productList.FindIndex(p => p.IdProduct == id);
                if (index != -1)
                {
                    productList[index] = prod;
                }
            });

            // Act
            mockRepository.Object.Put(productId, updatedProduct);

            // Assert
            var result = productList.FirstOrDefault(p => p.IdProduct == productId);
            Assert.NotNull(result);
            Assert.Equal(updatedProduct.Name, result.Name);
            Assert.Equal(updatedProduct.Price, result.Price);
        }

    }
}