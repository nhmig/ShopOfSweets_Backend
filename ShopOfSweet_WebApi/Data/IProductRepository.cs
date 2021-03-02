using ShopOfSweet_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.Data
{
    public interface IProductRepository
    {
        bool SaveChanges();

        IEnumerable<Product> GetAllProducts();
        void CreateProduct(Product product);
        Product GetProductById(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
