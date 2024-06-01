using System.ComponentModel.DataAnnotations.Schema;

namespace ZuZin.Models
{
    [Table("Product")]
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image {  get; set; }
        public decimal Price { get; set; }
        public bool IsTrendingProduct { get; set; }
    }
}
