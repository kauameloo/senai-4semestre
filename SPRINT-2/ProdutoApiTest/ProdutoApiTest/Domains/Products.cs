using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdutoApiTest.Domains
{
    [Table(nameof(Products))]
    public class Products
    {

        [Key]

        public Guid IdProduct { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        //[Required(ErrorMessage = "O Nome é obrigatorio")]

        public string? Name { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal? Price { get; set; }



    }
}
