using Northwind.CommonComponents.Exceptions;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.UI
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
            Console.WriteLine("[1] Ver Territorios");
            Console.WriteLine("[2] Ver Categorias");
            Console.WriteLine("[3] Crear Categoria");
            Console.WriteLine("[4] Modificar Categoria");
            Console.WriteLine("[5] Eliminar Categoria");
            Console.WriteLine("[6] Salir");

            return ValidateInput("Ingrese su opcion", 1, 6);
        }

        public static Categories PickCategory(string message, List<Categories> categories)
        {
            ShowCategories(categories);
            var index = ValidateInput(message, 1, categories.Count) - 1;

            return categories[index];
        }

        #region Menu options
        public static void ShowTerritories(List<Territories> territories)
        {
            var index = 1;
            foreach (var territory in territories)
            {
                Console.WriteLine($"[{index}] {territory.TerritoryDescription}");

                index++;
            }
        }

        public static void ShowCategories(List<Categories> categories)
        {
            var index = 1;
            foreach (var category in categories)
            {
                Console.WriteLine($"[{index}] {category.CategoryName} - {category.Description}");

                index++;
            }
        }

        public static Categories CreateCategory()
        {
            var category = new Categories
            {
                CategoryName = GetInput("Ingrese nombre de categoria"),
                Description = GetInput("Ingrese descripcion de la categoria")
            };

            return category;
        }

        public static Categories UpdateCategory(List<Categories> categories)
        {
            if (categories.Count == 0)
                throw new NoEntitiesException();

            var category = PickCategory("Ingrese el ID de la categoria a modificar", categories);

            var updatedCategory = CreateCategory();
            updatedCategory.CategoryID = category.CategoryID;

            return updatedCategory;
        }

        public static int DeleteCategory(List<Categories> categories)
        {
            if (categories.Count == 0)
                throw new NoEntitiesException();

            return PickCategory("Ingrese el ID de la categoria a eliminar", categories).CategoryID;
        }
        #endregion
    }
}
