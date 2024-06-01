using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZuZin.Data;
using ZuZin.Models.Interfaces;

namespace ZuZin.Models.Services
{
    public class OrderRepository:IOrderRepository
    {
        private ZuZinDbContext dbcontext;
        private IShoppingCartRepository shoppingCartRepository;
        public OrderRepository(ZuZinDbContext dbcontext, IShoppingCartRepository shoppingCartRepository)
        {
            this.dbcontext = dbcontext;
            this.shoppingCartRepository = shoppingCartRepository;
        }
        public void PlaceOrder(Order order)
        {
            var shoppingCartItems = shoppingCartRepository.GetAllShoppingCartItems();
            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = item.Qty,
                    ProductId = item.Product.ProductId,
                    Price = item.Product.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = shoppingCartRepository.GetShoppingCartTotal();
            dbcontext.Orders.Add(order);
            dbcontext.SaveChanges();
        }
        public Order GetOrder(int orderId)
        {
            return dbcontext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }
    }
}
