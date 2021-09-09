using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporte.Clases
{
    public abstract class TransportePulico
    {
        #region Propiedades
        public int VelocidadActual { get; protected set; }
        public string Descripcion { get; set; }
        public int Pasajeros { get; set; }
        public int Aceleracion { get; set; }
        public int Desaceleracion { get; set; }
        #endregion

        #region Constructor
        public TransportePulico(string descripcion, int pasajeros, int aceleracion, int desaceleracion)
        {
            Descripcion = descripcion;
            Pasajeros = pasajeros;
            Aceleracion = aceleracion;
            Desaceleracion = desaceleracion;
            VelocidadActual = 0;
        }

        public TransportePulico(TransportePulico transportePulico)
        {
            Pasajeros = transportePulico.Pasajeros;
            Aceleracion = transportePulico.Aceleracion;
            Desaceleracion = transportePulico.Desaceleracion;
            VelocidadActual = 0;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Avanza el vehiculo una distancia determinada
        /// </summary>
        /// <param name="distancia">Distancia a recorrer</param>
        /// <returns>Segundos que tarda el vehiculo en avanzar la distancia especificada</returns>
        public int Avanzar(int distancia)
        {
            var tiempo = distancia * 2 / Aceleracion;
            VelocidadActual += Aceleracion * tiempo;

            return tiempo;
        }

        /// <summary>
        /// Detiene el vehiculo
        /// </summary>
        /// <returns>Segundos que tarda el vehiculo en detenerse</returns>
        public int Detenerse()
        {
            var tiempo = VelocidadActual / Desaceleracion;
            VelocidadActual = 0;

            return tiempo;
        }
        #endregion
    }
}
