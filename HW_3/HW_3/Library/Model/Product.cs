using System.Collections.Generic;
using Library.Comparers;

namespace Library.Model
{
    public class Product
    {
        public string Id { get; }
        public string Brand { get; }
        public string Model { get; }
        public double Price { get; }
        public static IEqualityComparer<Product> EqualityComparer { get; } = new ProductEqualityComparer();

        public Product(string id, string brand, string model, double price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Price = price;
        }

        public override string ToString()
        {
            return $"Product #{Id} brand: {Brand}, model: {Model}, price: {Price}$";
        }
    }
}