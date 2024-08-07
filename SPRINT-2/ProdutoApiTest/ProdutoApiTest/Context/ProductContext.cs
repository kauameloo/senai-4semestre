using Microsoft.EntityFrameworkCore;
using ProdutoApiTest.Domains;

namespace ProdutoApiTest.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = KAUA-; Database = ProductsTest_tarde; User Id = sa; Password = Senai@134; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
