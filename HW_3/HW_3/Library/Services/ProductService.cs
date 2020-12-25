using System.Collections.Generic;
using System.Linq;
using Library.Model;

namespace Library.Services
{
    public class ProductService
    {
        private readonly FileWorker _fileWorker;
        private readonly string _fileName;

        public ProductService(string fileNameProduct = "")
        {
            _fileWorker = new FileWorker();

            if (string.IsNullOrEmpty(fileNameProduct) )
                _fileName = "product.csv";
            else
                _fileName = fileNameProduct;
        }

        public List<Product> FindById(string id)
        {
            var products = GetProductsFromFile();
            return products.Distinct().Where(x => x.Id.ToLower() == id.ToLower()).ToList();
        }

        public List<Product> FindByBrandOrModel(string subStr)
        {
            var products = GetProductsFromFile();
            return products.Distinct().Where(x =>
                x.Brand.ToLower().Contains(subStr.ToLower()) || x.Model.ToLower().Contains(subStr.ToLower())).ToList();
        }

        public List<Product> FindByTag(string tagStr)
        {
            var tags = new TagService().GetAllTagsFromFile();// get all tags from file
            var products = GetProductsFromFile();

            var foundProducts = new List<Product>();
            foreach (var product in products)
            {
                if (tags.Exists(x => x.ProductId == product.Id && x.Value.ToLower().Contains(tagStr.ToLower())) &&
                    !foundProducts.Contains(product))
                    foundProducts.Add(product);
            }

            return foundProducts.Distinct().ToList();
        }

        public List<Product> GetAllProducts(bool desc = true)
        {
            var products = GetProductsFromFile();
            if (desc)
                return products.OrderByDescending(x => x.Price).ToList();
            
            return products.OrderBy(x => x.Price).ToList();
        }

        private List<Product> GetProductsFromFile()
        {
            var products = new List<Product>();

            var fromFile = _fileWorker.Deserialize(_fileName);
            foreach (var str in fromFile)
            {
                var splitted = str.Split(';');
                var product = new Product(splitted[0],splitted[1],splitted[2],double.Parse(splitted[3]));
                products.Add(product);
            }

            return products;
        }
    }
}