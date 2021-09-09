using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporte.Clases
{
    public class Taxi : TransportePulico
    {
        public string Radio { get; set; }

        public Taxi(string descripcion, int pasajeros, int aceleracion, int desaceleracion, string radio) : base(descripcion, pasajeros, aceleracion, desaceleracion)
        {
            Radio = radio;
        }
    }
}
