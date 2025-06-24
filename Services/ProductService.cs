using EmptyProject.Models;
using System.Drawing;
using System.Xml.Linq;

namespace EmptyProject.Services
{
    public static class ProductService
    {
        static List<Product> Products { get; }
        static int nextId = 3;
        static ProductService()
        {
            Products = new List<Product>() {
                new Shoe{Id = 1, Name = "Ortuseight Hyperblast", Price=500000, Color="White", Size=44, Wide=10},
                new Jersey{Id = 2, Name = "Adidas Revive", Price=200000, Color="Black", Size=1 }
            };
        }
        public static List<Product> GetAll() => Products;
        public static Product? GetProduct(int id) => Products.FirstOrDefault(p => p.Id == id);
        public static void AddProduct(Product product)
        {
            product.Id = nextId++;
            Products.Add(product);
        }

        public static void DeleteProduct(int id)
        {
            var product = GetProduct(id);
            if (product is null)
                return;
            Products.Remove(product);
        }

        public static void UpdateProduct(Product product)
        {
            var productId = Products.FindIndex(p => p.Id == product.Id);
            if (productId == -1)
                return;
            Products[productId] = product;
        }

    }
}
