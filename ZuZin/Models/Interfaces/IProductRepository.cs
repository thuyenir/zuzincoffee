namespace ZuZin.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> ListProducts();
        IEnumerable<Product> GetTrendingProducts();
        Product GetProductDetail(int id);
        //add Crud
        List<Product> Search(string keyword);
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void SaveChanges();

    }
}
