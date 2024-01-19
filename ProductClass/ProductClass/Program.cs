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
        private static Logger Write = new Logger();


        static void Main(string[] args)
        {
            int choice;
            
            Dictionary<int,Product> productList = new Dictionary<int, Product>();

            do
            {

                Write.log("\n-----MENU-----");
                Write.log();
                Write.log("1. Add Product");
                Write.log("2. Display all Products");
                Write.log("3. Find Product");
                Write.log("4. Remove Product");
                Write.log("5. Exit");
                Write.log();

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Write.log("Invalid input. Please enter a number.");
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
                        FindProduct(productList);
                        break;
                    case 4:
                        RemoveProduct(productList);
                        break;
                    case 5:
                        Write.log("Exiting...");
                        break;
                    default:
                        Write.log("Invalid choice. Please enter a valid option.");
                        break;
                }             



            } while (choice != 5);
        }

        static void AddProduct(Dictionary<int,Product> productList)
        {
            int ProductIdInput;
            try
            {
                Product newProduct = new Product();
                Console.Write("Enter Product ID: ");
                ProductIdInput = Convert.ToInt32(Console.ReadLine());
                if (productList.ContainsKey(ProductIdInput))
                    throw new Exception("Product already present");
                newProduct.ProductId = ProductIdInput;

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
            
                productList.Add(ProductIdInput, newProduct);

            }
            catch(Exception e)
            {
                Write.log();
                Write.log(e.Message.ToString());
                Write.log("Try Again");
            }
            
    }

        static void DisplayProducts(Dictionary<int, Product> ProductList)
        {
            if (ProductList.Count == 0)
            {
                Write.log("Product list is empty");
                return;
            } 
            Write.log("----PRODUCT DETAILS----");
            Write.log();
            foreach (Product TempProduct in ProductList.Values)
            {
                Write.log("------------");
                Write.log(TempProduct.Display());
                Write.log();
            }
            Write.log("------------");
        }
    
        static void FindProduct(Dictionary<int, Product> ProductList)
        {
            if (ProductList.Count == 0)
            {
                Write.log("Product list is empty");
                return;
            }
            int ProductIdInput;
            Console.Write("Enter Product ID: ");
            ProductIdInput = int.Parse(Console.ReadLine());
            if (ProductList.Keys.Contains(ProductIdInput))
            {

                Write.log("Product Found!");
                Write.log(ProductList[ProductIdInput].Display());
                return;

            }
            else
            {
                Write.log("Product Not Found!");
            }

        }

        static void RemoveProduct(Dictionary<int, Product> ProductList) 
        {
            int ProductIdInput;
            Write.log("Enter Product ID of product to be deleted: ");
            ProductIdInput = Convert.ToInt32(Console.ReadLine());
            if (!ProductList.ContainsKey(ProductIdInput))
            {
                Write.log("Product does not exist");
                return;
            }
            ProductList.Remove(ProductIdInput);
            Write.log("Product deleted.");
        }
    }
}

