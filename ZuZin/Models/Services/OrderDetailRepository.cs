using Microsoft.EntityFrameworkCore;
using ZuZin.Data;
using ZuZin.Models.Interfaces;

namespace ZuZin.Models.Services
{
    public class OrderDetailRepository:IOrderDetailRepository
    {
        private readonly ZuZinDbContext _context;
        public OrderDetailRepository(ZuZinDbContext context)
        {
            _context = context;
        }
        public List<OrderDetailViewModel> GetAllOrderDetails()
        {
            return _context.OrderDetails
                           .Select(od => new OrderDetailViewModel
                           {
                               Id = od.OrderDetailId,
                               ProductName = od.Product != null ? od.Product.Name : "N/A",
                               CustomerName = od.Order != null ? od.Order.LastName + " " + od.Order.FirstName : "N/A",
                               Quantity = od.Quantity,
                               Price = od.Price
                           })
                           .ToList();
        }
        public List<OrderDetailViewModel> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails
                                 .Where(od => od.OrderId == orderId)
                                 .Select(od => new OrderDetailViewModel
                                 {
                                     ProductName = od.Product != null ? od.Product.Name : "N/A",
                                     CustomerName = od.Order != null ? od.Order.LastName + " " + od.Order.FirstName : "N/A",
                                     Quantity = od.Quantity,
                                     Price = od.Price
                                 })
                                 .ToList();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
