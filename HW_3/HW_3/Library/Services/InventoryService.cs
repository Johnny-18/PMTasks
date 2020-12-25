using System.Collections.Generic;
using System.Linq;
using Library.Model;

namespace Library.Services
{
    public class InventoryService
    {
        private readonly FileWorker _fileWorker;
        private readonly string _fileName;
        private readonly ProductService _productService;

        public InventoryService(string fileName = "")
        {
            _fileWorker  = new FileWorker();
            _productService = new ProductService();

            if (!string.IsNullOrEmpty(fileName))
                _fileName = fileName;
            else
                _fileName = "inventory.csv";
        }

        public List<Product> GetMissingProducts()
        {
            var products = _productService.GetAllProducts();
            var inventories = GetAllInventoryFromFile();

            List<Product> selectedProducts = new List<Product>();
            foreach (var product in products)
            {
                var selectedInv = inventories.Where(x => x.ProductId == product.Id).ToList();
                if (selectedInv.Count != 0 && selectedInv.Where(x => x.Balance == 0).ToList().Count == 0) // if product haves on storages
                {
                    continue;
                }
                
                selectedProducts.Add(product);
            }

            return selectedProducts.OrderBy(x => x.Id).ToList();
        }

        public SortedList<int, Product> GetBalanceProducts(bool desc = true)
        {
            var products = _productService.GetAllProducts(desc);
            var inventories = GetAllInventoryFromFile();
            
            var selectedProd = new SortedList<int, Product>();
            foreach (var product in products)
            {
                var selectedInv = inventories.Where(x => x.ProductId == product.Id).ToList();
                int balance = selectedInv.Select(x => x.Balance).Sum();
                selectedProd.Add(balance, product);
            }

            return selectedProd;
        }

        public List<Inventory> GetInventoriesByProductId(string id)
        {
            var inventories = GetAllInventoryFromFile();
            return inventories.Where(x => x.ProductId.ToLower() == id.ToLower()).OrderByDescending(x => x.Balance)
                .ToList();
        }

        private List<Inventory> GetAllInventoryFromFile()
        {
            var inventories = new List<Inventory>();

            var fromFile = _fileWorker.Deserialize(_fileName);
            foreach (var str in fromFile)
            {
                var splitted = str.Split(';');
                var inventory = new Inventory(splitted[0], splitted[1], int.Parse(splitted[2]));
                inventories.Add(inventory);
            }

            return inventories;
        }
    }
}