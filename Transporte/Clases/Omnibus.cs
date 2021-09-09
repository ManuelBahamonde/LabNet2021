using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporte.Clases
{
    public class Omnibus : TransportePulico
    {
        public string Linea { get; set; }

        public Omnibus(string descripcion, int pasajeros, int aceleracion, int desaceleracion, string linea) : base(descripcion, pasajeros, aceleracion, desaceleracion)
        {
            Linea = linea;
        }
    }
}
