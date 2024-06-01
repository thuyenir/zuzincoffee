using System.ComponentModel.DataAnnotations.Schema;

namespace ZuZin.Models
{
    //[Table("ShoppingCartItem")]
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int Qty { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
