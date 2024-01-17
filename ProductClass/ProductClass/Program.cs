using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductClass
{

    internal class Program
    {
        private int PrivateProductId;
        private string PrivateName;
        private DateTime PrivateMfgDate;
        private int PrivateWarranty;
        private decimal PrivatePrice;
        private int PrivateStock;
        private decimal PrivateDiscount;
        private int PrivateGST;

        static void Main(string[] args)
        {

            int choice;
            var productList = new List<Product>();

            do
            {
                Console.WriteLine("-----MENU-----");
                Console.WriteLine();
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddProduct(productList);
                        break;
                    case 2:
                        DisplayProducts(productList);
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                



            } while (choice != 3);
        }

        static void AddProduct(List<Product> productList)
        {
            Product newProduct = new Product();
            Console.Write("Enter Product ID: ");
            newProduct.ProductId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            newProduct.ProductName = Console.ReadLine();

            Console.Write("Enter Manufacturing Date (mm/dd/yyyy): ");
            newProduct.MfgDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Warranty(in months): ");
            newProduct.Warranty = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price: ");
            newProduct.Price = Convert.ToDecimal(Console.ReadLine());
        
            Console.Write("Enter Stock: ");
            newProduct.Stock = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter GST(5, 12, 18, or 28): ");
            newProduct.GST = Convert.ToInt32(Console.ReadLine());
        
            Console.Write("Enter Discount: ");
            newProduct.Discount = Convert.ToDecimal(Console.ReadLine());
            
            productList.Add(newProduct);
    }

        static void DisplayProducts(List<Product> ProductList)
        {
            Console.WriteLine("----PRODUCT DETAILS----");
            Console.WriteLine();
            foreach (Product TempProduct in ProductList)
            {
                Console.WriteLine("------------");
                Console.WriteLine(TempProduct.Display());
                
                Console.WriteLine();
            }
            Console.WriteLine("------------");
        }
    }
}

