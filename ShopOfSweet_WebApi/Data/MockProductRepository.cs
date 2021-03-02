using ShopOfSweet_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.Data
{
    public class MockProductRepository : IProductRepository
    {
        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = new List<Product>{
                new Product
                {
                    Id = 0,
                    Name = "Печенье Школодное",
                    Description = "В нем нет шоколада",
                    manufacturer = "Москва",
                    SerialNumber = "12345"
                },
                new Product
                {
                    Id = 1,
                    Name = "шоколад Аленка",
                    Description = "вкусный шоколад",
                    manufacturer = "Казань",
                    SerialNumber = "123456"
                },
                new Product
                {
                    Id = 2,
                    Name = "Варенье",
                    Description = "какое-то описание",
                    manufacturer = "Деревня",
                    SerialNumber = "xxxx"
                }
            };

            return products;
        }

        public Product GetProductById(int id)
        {
            return new Product
            {
                Id = 1,
                Name = "TEST_MOCK",
                Description = "вкусный шоколад",
                manufacturer = "Казань",
                SerialNumber = "123456"
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
