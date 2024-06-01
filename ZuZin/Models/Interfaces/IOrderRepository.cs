namespace ZuZin.Models.Interfaces
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
        Order GetOrder(int orderId);
    }
}
