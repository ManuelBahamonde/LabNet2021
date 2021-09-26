using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.Entities;
using TpLinqLogic;

namespace Tp5.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabajo Practico Nº 5");
            Console.WriteLine("Manuel Bahamonde");

            var customerLogic = new CustomerLogic();
            var productsLogic = new ProductsLogic();

            int opt;
            do
            {
                opt = Helpers.ProcessMenu();

                switch (opt)
                {
                    case 1:
                        var customers = new List<Customer> { customerLogic.GetCustomer() };
                        Helpers.ShowCustomers(customers);
                        break;
                    case 2:
                        Helpers.ShowProducts(productsLogic.GetProductsWithNoStock());
                        break;
                    case 3:
                        Helpers.ShowProducts(productsLogic.GetExpensiveProductsInStock());
                        break;
                    case 4:
                        Helpers.ShowCustomers(customerLogic.GetWACustomers());
                        break;
                    case 5:
                        {
                            var product789 = productsLogic.GetProduct789();
                            if (product789 != null)
                            {
                                var products = new List<Product> { product789 };
                                Helpers.ShowProducts(products);
                            } 
                            else
                            {
                                Console.WriteLine("That product does not exist.");
                            }
                        }
                        break;
                    case 6:
                        Helpers.ShowCustomerNames(customerLogic.GetCustomerNames());
                        break;
                    case 7:
                        Helpers.ShowCustomerOrders(customerLogic.GetCustomersOrders());
                        break;
                    case 8:
                        Helpers.ShowCustomers(customerLogic.GetFirstCustomersOfWARegion());
                        break;
                    case 9:
                        Helpers.ShowProducts(productsLogic.GetProductsOrderedByName());
                        break;
                    case 10:
                        Helpers.ShowProducts(productsLogic.GetProductsOrderedByStock());
                        break;
                    case 11:
                        Helpers.ShowCategories(productsLogic.GetProductsCategories());
                        break;
                    case 12:
                        {
                            var products = new List<Product> { productsLogic.GetFirstProduct() };
                            Helpers.ShowProducts(products);
                            break;
                        }
                    case 13:
                        Helpers.ShowCustomerOrdersQuantities(customerLogic.GetCustomerOrdersQuantity());
                        break;
                    default: break;
                }
            } while (opt != 14);

            Console.ReadKey();
        }
    }
}
