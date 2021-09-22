using Northwind.CommonComponents;
using Northwind.CommonComponents.Exceptions;
using Northwind.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabajo Practico Nº 4");
            Console.WriteLine("Manuel Bahamonde");

            var territoriesLogic = new TerritoriesLogic();
            var categoriesLogic = new CategoriesLogic();

            int opt;
            do
            {
                opt = Helpers.ProcessMenu();

                try
                {
                    switch (opt)
                    {
                        case 1:
                            Helpers.ShowTerritories(territoriesLogic.GetAll());
                            break;
                        case 2:
                            Helpers.ShowCategories(categoriesLogic.GetAll());
                            break;
                        case 3:
                            categoriesLogic.Add(Helpers.CreateCategory());
                            Console.WriteLine("Categoria creada correctamente!");
                            break;
                        case 4:
                            categoriesLogic.Update(Helpers.UpdateCategory(categoriesLogic.GetAll()));
                            Console.WriteLine("Categoria actualizada correctamente!");
                            break;
                        case 5:
                            categoriesLogic.Delete(Helpers.DeleteCategory(categoriesLogic.GetAll()));
                            Console.WriteLine("Categoria eliminada correctamente!");
                            break;
                        default: break;
                    }
                } 
                catch (CustomDataException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Hubo un error inesperado al realizar la accion solicitada. Mas informacion: {e.Message}");
                }
            } while (opt != 6);


            Console.ReadKey();
        }
    }
}
