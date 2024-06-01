namespace ZuZin.Models.Interfaces
{
    public interface IOrderDetailRepository
    {
        List<OrderDetailViewModel> GetAllOrderDetails();
        List<OrderDetailViewModel> GetOrderDetailsByOrderId(int orderId);
    }
}
