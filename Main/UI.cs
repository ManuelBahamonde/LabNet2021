using System;
using Tp2.ExtensionMethods;

namespace Tp2
{
    class UI
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabajo Practico Nº 2");
            Console.WriteLine("Manuel Bahamonde");

            int opt;
            do
            {
                opt = ProcessMenu();

                switch (opt)
                {
                    case 1: Exercise1(); break;
                    case 2: Exercise2(); break;
                    case 3: Exercise3(); break;
                    case 4: Exercise4(); break;
                    default: break;
                }
            } while (opt != 5);

            Console.WriteLine("Ingrese cualquier tecla para finalizar.");
            Console.ReadKey();
        }

        #region Exercises
        static void Exercise1()
        {
            var input = (float) ValidarInput("Ingrese un numero para dividirlo por 0", 0, null);

            try
            {
                Console.WriteLine($"Resultado: {input.DivideByZero()}");
            }
            catch (DivideByZeroException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public static void Exercise2()
        {
            var dividend = (float) ValidarInput("Ingrese un dividendo", 0, null);
            var divisor = (float) ValidarInput("Ingrese un divisor", 0, null);

            try
            {
                Console.WriteLine($"Resutado: {dividend.DivideBy(divisor).ToString("0.00")}");
            }
            catch (DivideByZeroException exc)
            {
                Console.WriteLine($"Solo Chuck Norris divide por cero! Si con eso no te alcanza, aca tenes una descripcion detallada: {exc.Message}");
            }
        }

        static void Exercise3()
        {
            var logic = new Logic();

            try
            {
                logic.ThrowException();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        static void Exercise4()
        {
            var logic = new Logic();

            try
            {
                logic.ThrowCustomException();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
        #endregion

        #region Helpers
        static int ValidarInput(string mensaje, int? valorMin, int? valorMax)
        {
            int input = 0;
            do
            {
                Console.WriteLine(mensaje);
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Seguro ingreso una letra o no ingreso nada!");
                }
            } while ((valorMin.HasValue && input < valorMin) || (valorMax.HasValue && input > valorMax));

            return input;
        }

        static int ProcessMenu()
        {
            Console.WriteLine();
            Console.WriteLine("---- MENU ----");
            Console.WriteLine("[1] Ejercicio 1");
            Console.WriteLine("[2] Ejercicio 2");
            Console.WriteLine("[3] Ejercicio 3");
            Console.WriteLine("[4] Ejercicio 4");
            Console.WriteLine("[5] Salir");

            return ValidarInput("Ingrese su opcion", 1, 5);
        }
        #endregion
    }
}
