using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoTemp.Test
{
    public class ConversaoUnitTest
    {
        [Fact]
        public void VerificarConversao()
        {
            double celsius = 100;

            var valorEsperado = 212;

            var resultado = ConversaoTemperatura.CelsiusToFahrenheit(celsius);

            Assert.Equal(resultado, valorEsperado);
        }
    }
}
