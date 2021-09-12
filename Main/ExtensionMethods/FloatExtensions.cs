using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2.ExtensionMethods
{
    public static class FloatExtensions
    {
        public static double DivideBy(this float dividend, float divisor)
        {
            return dividend / divisor;
        }
        
        public static float DivideByZero(this float dividend)
        {
            return dividend / 0;
        }
    }
}
