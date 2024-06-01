using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZuZin.Data;
using ZuZin.Models;
using ZuZin.Models.Interfaces;
using ZuZin.Models.Services;

namespace ZuZin.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly ZuZinDbContext _context;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailController(ZuZinDbContext context, IOrderDetailRepository orderDetailRepository)
        {
            _context = context;
            _orderDetailRepository = orderDetailRepository;
        }
        public IActionResult Index()
        {
            List<OrderDetailViewModel> orderDetails = _orderDetailRepository.GetAllOrderDetails();
            return View(orderDetails);
        }
        public IActionResult Details(int orderId)
        {
            List<OrderDetailViewModel> orderDetails = _orderDetailRepository.GetOrderDetailsByOrderId(orderId);
            if (orderDetails == null || orderDetails.Count == 0)
            {
                return NotFound();
            }
            return View(orderDetails);
        }
    }
}
