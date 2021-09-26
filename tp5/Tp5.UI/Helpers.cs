using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.DTO;
using Tp5.Entities;

namespace Tp5.UI
{
    public class Helpers
    {
        public static int ValidateInput(string message, int? minValue, int? maxValue)
        {
            int input = 0;
            do
            {
                Console.WriteLine(message);
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Entrada no valida");
                }
            } while ((minValue.HasValue && input < minValue) || (maxValue.HasValue && input > maxValue));

            return input;
        }

        public static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int ProcessMenu()
        {
            Console.WriteLine();
            Console.WriteLine("--- Menu Principal ---");
            Console.WriteLine("[1] Query para devolver objeto customer");
            Console.WriteLine("[2] Query para devolver todos los productos sin stock");
            Console.WriteLine("[3] Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
            Console.WriteLine("[4] Query para devolver todos los customers de la Región WA");
            Console.WriteLine("[5] Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            Console.WriteLine("[6] Query para devolver los nombre de los Customers.");
            Console.WriteLine("[7] Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.");
            Console.WriteLine("[8] Query para devolver los primeros 3 Customers de la  Región WA");
            Console.WriteLine("[9] Query para devolver lista de productos ordenados por nombre");
            Console.WriteLine("[10] Query para devolver lista de productos ordenados por unit in stock de mayor a menor.");
            Console.WriteLine("[11] Query para devolver las distintas categorías asociadas a los productos");
            Console.WriteLine("[12] Query para devolver el primer elemento de una lista de productos");
            Console.WriteLine("[13] Query para devolver los customer con la cantidad de ordenes asociadas");
            Console.WriteLine("[14] Salir");

            return ValidateInput("Ingrese su opcion", 1, 14);
        }

        #region Customers
        public static void ShowCustomers(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer Name: {customer.ContactName}");
            }
        }

        public static void ShowCustomerNames(List<CustomerNames> customersNames)
        {
            foreach (var customerNames in customersNames)
            {
                Console.WriteLine($"{customerNames.CustomerNameLower} - {customerNames.CustomerNameUpper}");
            }
        }

        public static void ShowCustomerOrders(List<CustomerOrders> customersOrders)
        {
            foreach (var customerOrders in customersOrders)
            {
                Console.WriteLine($"{customerOrders.Customer.ContactName} orders:");
                foreach (var order in customerOrders.Orders)
                {
                    Console.WriteLine(order.OrderID);
                }
            }
        }

        public static void ShowCustomerOrdersQuantities(List<CustomerOrdersQuantity> customersOrdersQuantity)
        {
            foreach (var customerOrdersQuantity in customersOrdersQuantity)
            {
                Console.WriteLine($"Customer {customerOrdersQuantity.Customer.ContactName} has ordered {customerOrdersQuantity.OrdersQuantity} times");
            }
        }
        #endregion

        #region Products
        public static void ShowProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        public static void ShowCategories(List<Category> categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine(category.CategoryName);
            }
        }
        #endregion
    }
}
