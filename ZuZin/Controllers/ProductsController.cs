using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZuZin.Models;
using ZuZin.Models.Interfaces;
using ZuZin.Models.Services;

namespace ZuZin.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Shop()
        {
            return View(productRepository.GetAllProducts());
        }
        public IActionResult ListProduct()
        {
            return View(productRepository.ListProducts());
        }
        public IActionResult Detail(int id)
        {
            var product = productRepository.GetProductDetail(id);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Search(string keyword)
        {
            var searchResults = productRepository.Search(keyword);
            return View("SearchResult", searchResults);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.AddProduct(product);
                productRepository.SaveChanges();
                return RedirectToAction("ListProduct");
            }
            return View(product);
        }
        //edit product
        public ActionResult Edit(int id)
        {
            var product = productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.UpdateProduct(product);
                productRepository.SaveChanges();
                return RedirectToAction("ListProduct");
            }
            return View(product);
        }
        //delete product
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var productToDelete = productRepository.GetProductById(id);
            if (productToDelete == null)
            {
                return NotFound(); 
            }

            productRepository.DeleteProduct(id);

            productRepository.SaveChanges();

            return RedirectToAction("ListProduct");
        }
    }
}
