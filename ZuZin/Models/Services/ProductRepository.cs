using Microsoft.EntityFrameworkCore;
using ZuZin.Data;
using ZuZin.Models.Interfaces;

namespace ZuZin.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private ZuZinDbContext dbContext;
        public ProductRepository(ZuZinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Product> ListProducts()
        {
            return dbContext.Products;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products;
        }
        public Product? GetProductDetail(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.ProductId == id);
        }
        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Products.Where(p => p.IsTrendingProduct);
        }
        //add
        public List<Product> Search(string keyword)
        {
            return dbContext.Products.Where(p => p.Name.Contains(keyword)).ToList();
        }
        public Product GetProductById(int id)
        {
            return dbContext.Products.Find(id);
        }
        public void AddProduct(Product product)
        {
            dbContext.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            dbContext.Entry(product).State = EntityState.Modified;
        }

        public void DeleteProduct(int id)
        {
            var product = dbContext.Products.Find(id);
            dbContext.Products.Remove(product);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
