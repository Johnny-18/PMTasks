using System.Collections.Generic;
using Library.Model;

namespace Library.Comparers
{
    public class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return string.Equals(x.Id, y.Id);
        }

        public int GetHashCode(Product obj)
        {
            return obj.Brand.Length ^ obj.Model.Length;
        }
    }
}