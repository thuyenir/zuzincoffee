
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using ZuZin.Data;
using ZuZin.Models;
using ZuZin.Models.Interfaces;
using ZuZin.Models.Services;

namespace ZuZin.Controllers
{
    public class OrdersController : Controller
    {
        private ZuZinDbContext dbcontext;
        private IOrderRepository orderRepository;
        private IShoppingCartRepository shoppingCartRepository;
        public OrdersController(IOrderRepository oderRepository, IShoppingCartRepository shoppingCartRepossitory, ZuZinDbContext dbcontext)
        {
            this.orderRepository = oderRepository;
            this.shoppingCartRepository = shoppingCartRepossitory;
            this.dbcontext = dbcontext;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            orderRepository.PlaceOrder(order);
            shoppingCartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);
            return RedirectToAction("CheckoutComplete");
        }
        public IActionResult CheckoutComplete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckoutComplete(int orderId)
        {
            Order order = orderRepository.GetOrder(orderId);

            if (order == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(order);
        }
    }
}
