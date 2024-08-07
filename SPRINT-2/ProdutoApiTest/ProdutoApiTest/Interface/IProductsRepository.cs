using ProdutoApiTest.Domains;

namespace ProdutoApiTest.Interface
{
    public interface IProductsRepository
    {
        List<Products> Get();

        Products GetById(Guid guid);
		void Post(Products p);
        void Put(Guid id, Products p);
		void Delete(Guid id);
    }
}
