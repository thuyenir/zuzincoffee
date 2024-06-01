namespace ZuZin.Models
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
