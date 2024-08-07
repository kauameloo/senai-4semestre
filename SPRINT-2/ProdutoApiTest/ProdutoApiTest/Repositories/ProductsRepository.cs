using Microsoft.EntityFrameworkCore;
using ProdutoApiTest.Context;
using ProdutoApiTest.Domains;
using ProdutoApiTest.Interface;

namespace ProdutoApiTest.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductContext _productContext;

        public ProductsRepository()
        {
            _productContext = new ProductContext();
        }

        public void Delete(Guid id)
        {
            try
            {
                Products produtoBuscado = _productContext.Products.FirstOrDefault(a => a.IdProduct == id)!;
                _productContext.Remove(produtoBuscado);
                _productContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Products> Get()
        {
            return _productContext.Products.ToList();
        }

        public Products GetById(Guid guid)
        {
            try
            {
                Products productsBuscado = _productContext.Products.FirstOrDefault(a => a.IdProduct == guid)!;
                return productsBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Post(Products p)
        {
            try
            {
                _productContext.Add(p);
                _productContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Put(Guid id, Products p)
        {
            try
            {
                Products productsBuscado = _productContext.Products.Find(id)!;

                if (productsBuscado != null)
                {
                    if (p.Name != null)
                    {
                    productsBuscado.Name = p.Name;

                    }
                    if (p.Price.HasValue)
                    {
                        productsBuscado.Price = p.Price.Value;
                    }
                }

                _productContext.Products.Update(productsBuscado!);

                _productContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
