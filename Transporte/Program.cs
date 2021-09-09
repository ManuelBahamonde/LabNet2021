using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transporte.Clases;

namespace Transporte
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabajo Practico Nº 1");
            Console.WriteLine("Manuel Bahamonde");
            Console.WriteLine();

            var transportes = new List<TransportePulico>();
            int resp;

            do
            {
                resp = IngresarOpcionMenu();
                Console.WriteLine();

                if (resp == 1)
                    transportes.AddRange(IngresarTransportes());
                else if (resp == 2)
                    ListarTransportes(transportes);

            } while (resp != 3);

            Console.WriteLine();
            Console.Write("Presione cualquier tecla para salir");
            Console.ReadKey();
        }

        #region Metodos
        static int IngresarOpcionMenu()
        {
            Console.WriteLine("---- Menu Principal ----");
            Console.WriteLine("[1] Ingresar nuevos transportes");
            Console.WriteLine("[2] Listado de transportes actuales");
            Console.WriteLine("[3] Salir");

            return ValidarInput("Ingrese su opcion", 1, 3);
        }

        #region Ingreso de transportes
        static int IngresarOpcionTransporte()
        {
            Console.WriteLine("[1] Omnibus");
            Console.WriteLine("[2] Taxi");
            Console.WriteLine("[3] Finalizar");

            return ValidarInput("Ingrese su opcion", 1, 3);
        }

        static List<TransportePulico> IngresarTransportes()
        {
            var transportes = new List<TransportePulico>();

            var resp = IngresarOpcionTransporte();
            Console.WriteLine();

            while (resp != 3)
            {
                if (resp == 1)
                    transportes.Add(IngresarOmnibus());
                else
                    transportes.Add(IngresarTaxi());

                resp = IngresarOpcionTransporte();
                Console.WriteLine();
            }

            return transportes;
        }

        static Tuple<string, int, int> IngresarTransportePublico()
        {
            var descripcion = IngresarString("Ingrese una descripcion del vehiculo");
            var aceleracion = ValidarInput("Ingrese la aceleracion del vehiculo (0 a 50m/s cuadrados)", 0, 50);
            var desaceleracion = ValidarInput("Ingrese la desaceleracion del vehiculo (0 a 50m/s cuadrados)", 0, 50);

            return Tuple.Create(descripcion, aceleracion, desaceleracion);
        }

        static Omnibus IngresarOmnibus()
        {
            var datosTransportePublico = IngresarTransportePublico();
            var pasajeros = ValidarInput("Ingrese cantidad de pasajeros (1 a 100)", 1, 100);
            var linea = IngresarString("Ingrese la linea del omnibus");
            Console.WriteLine();

            return new Omnibus(datosTransportePublico.Item1, pasajeros, datosTransportePublico.Item2, datosTransportePublico.Item3, linea);
        }

        static Taxi IngresarTaxi()
        {
            var datosTransportePublico = IngresarTransportePublico();
            var pasajeros = ValidarInput("Ingrese cantidad de pasajeros (1 a 4)", 1, 4);
            var radio = IngresarString("Ingrese la radio del taxi");
            Console.WriteLine();

            return new Taxi(datosTransportePublico.Item1, pasajeros, datosTransportePublico.Item2, datosTransportePublico.Item3, radio);
        }
        #endregion

        #region Listado de transportes
        static void ListarTransportes(List<TransportePulico> transportes)
        {
            if (transportes.Count == 0)
            {
                Console.WriteLine("No hay vehiculos cargados!");
                Console.WriteLine();
                return;
            }

            var distancia = ValidarInput("Ingrese una distancia para hacer avanzar a los vehiculos (de 0 a 1000 metros)", 0, 1000);
            Console.WriteLine();

            Console.WriteLine("---- Datos de los Vehiculos ----");
            foreach (var transporte in transportes)
            {
                Console.WriteLine($"{transporte.Descripcion}: {transporte.Pasajeros} pasajeros.");
                Console.WriteLine($"Aceleracion: {transporte.Aceleracion} m/s2. Desaceleracion: {transporte.Desaceleracion} m/s2.");
                Console.WriteLine();

                Console.WriteLine($"Este vehiculo tarda {transporte.Avanzar(distancia)} segundos en avanzar {distancia} metros");
                var velocidadAntesDeFrenar = transporte.VelocidadActual;
                Console.WriteLine($"Este vehiculo tarda {transporte.Detenerse()} segundos en detenerse desde los {velocidadAntesDeFrenar} m/s");

                Console.WriteLine(); Console.WriteLine();
            }
        }
        #endregion

        #endregion

        #region Helpers
        static int ValidarInput(string mensaje, int valorMin, int valorMax)
        {
            int input = 0;
            do
            {
                Console.WriteLine(mensaje);
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("El valor ingresado no es un numero entero.");
                }
                catch (Exception)
                {
                    Console.WriteLine("El valor ingresado no es valido");
                }
            } while (input < valorMin || input > valorMax);

            return input;
        }

        static string IngresarString(string mensaje)
        {
            string respuesta = "";
            do
            {
                Console.WriteLine(mensaje);
                respuesta = Console.ReadLine();
            } while (respuesta.Length == 0);

            return respuesta;
        }
        #endregion
    }
}
