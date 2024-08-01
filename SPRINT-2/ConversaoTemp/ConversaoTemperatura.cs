using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoTemp
{
    public static class ConversaoTemperatura
    {
        public static double CelsiusToFahrenheit(double C)
        {
            double F = (C * 1.8) + 32;
            return F;
        }
    }
}
