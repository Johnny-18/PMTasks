using System;
using System.Collections.Generic;
using System.Linq;
using Library.Comparers;
using Library.Model;
using Library.Services;

namespace Library.Menu
{
    public class ChatBot
    {
        private readonly ProductService _productService;
        private readonly TagService _tagService;
        private readonly InventoryService _inventoryService;

        public ChatBot()
        {
            _productService = new ProductService();
            _tagService = new TagService();
            _inventoryService = new InventoryService();
        }
        
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Main menu!");
                Console.WriteLine("1.Exit" +
                                  "\n2.Products" +
                                  "\n3.Inventory");
                
                ChooseAction();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        return;
                    case "2":
                        ProductMenu();
                        break;
                    case "3":
                        InventoryMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid action!");
                        break;
                }
            }
        }

        private void ChooseAction()
        {
            Console.WriteLine("Choose your action:");
        }

        private void ProductMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Product menu!");

                Console.WriteLine("1.Back to main menu" +
                                  "\n2.Find product" +
                                  "\n3.Show all products(sorted by price decrease)" +
                                  "\n4.Show all products(sorted by price increase)");

                ChooseAction();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        return;
                    case "2":
                        FindProduct();
                        break;
                    case "3":
                        GetAllProducts();
                        break;
                    case "4":
                        GetAllProducts(false);
                        break;
                    default:
                        Console.WriteLine("Invalid action!");
                        break;
                }
            }
        }

        private void FindProduct()
        {
            string input;
            while (true)
            {
                Console.WriteLine("Enter your string for search:");
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                    break;
            }
            
            var foundById = _productService.FindById(input);
            var foundByBrandOfModel = _productService.FindByBrandOrModel(input);
            var foundByTag = _productService.FindByTag(input);

            if (foundById.Count == 0 && foundByBrandOfModel.Count == 0 && foundByTag.Count == 0)
            {
                Console.WriteLine("Products didn't found!");
                return;
            }

            var list = new List<Product>();
            list.AddRange(foundById);
            list.AddRange(foundByBrandOfModel);
            list.AddRange(foundByTag);
            PrintList(list.Distinct(new ProductEqualityComparer()).ToList());
        }

        private void GetAllProducts(bool desc = true)
        {
            var products = _productService.GetAllProducts(desc);
            var tags = _tagService.GetAllTagsFromFile();
            if(products != null)
                foreach (var product in products)
                {
                    Console.Write("\n" + product);

                    if(tags != null)
                    {
                        List<Tag> prodTags;
                        prodTags = tags.Where(x => x.ProductId == product.Id).ToList();
                        if (prodTags.Count != 0)
                        {
                            Console.Write(" tags: ");
                            foreach (var tag in prodTags)
                            {
                                Console.Write("#" + tag + " ");
                            }
                        }
                    }
                }
            
            Console.WriteLine();
        }

        private void PrintList<T>(List<T> list)
        {
            if(list != null)
                foreach (var element in list)
                {
                    Console.WriteLine(element);
                }
        }

        private void InventoryMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Inventory menu!");

                Console.WriteLine("1.Back to main menu" +
                                  "\n2.Missing products" +
                                  "\n3.Balance products(increase)" +
                                  "\n4.Balance products(decrease)" +
                                  "\n5.Balance products by id");

                ChooseAction();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        return;
                    case "2":
                        MissingProducts();
                        break;
                    case "3":
                        BalanceProducts(false);
                        break;
                    case "4":
                        BalanceProducts();
                        break;
                    case "5":
                        BalanceProductsById();
                        break;
                    default:
                        Console.WriteLine("Invalid action!");
                        break;
                }
            }
        }

        private void BalanceProductsById()
        {
            string input;
            while (true)
            {
                Console.WriteLine("Enter id for search:");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                    break;

                Console.WriteLine("Invalid value! Id should not be  empty!");
            }

            var inventories = _inventoryService.GetInventoriesByProductId(input);
            if (inventories.Count != 0)
            {
                Console.WriteLine("Balance on storages:");
                PrintList(inventories);
                return;
            }

            Console.WriteLine("Error! Not found product or this product on storages!");
        }

        private void BalanceProducts(bool desc = true)
        {
            var selectedProducts = _inventoryService.GetBalanceProducts(desc);
            if (selectedProducts.Count != 0)
            {
                Console.WriteLine("Balance of products:");
                var products = desc ? selectedProducts.Reverse() : selectedProducts;
                foreach (var product in products)
                {
                    Console.WriteLine(product.Value + " balance: " + product.Key);
                }
            }
        }

        private void MissingProducts()
        {
            var products = _inventoryService.GetMissingProducts();
            if (products.Count != 0)
            {
                Console.WriteLine("Missing products:");
                PrintList(products);
            }
        }
    }
}