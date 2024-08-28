using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Exercicio3
    {
        public static void SomaDosPares()
        {
            // int numero = 0;
            // int resultado = 0;
            // while (numero <= 100)
            // {
            //     resultado += numero;
            //     numero += 2;
            // }
            // Console.WriteLine(resultado);

            int pares = 1;
            int soma = 0;

            while (pares <= 100)
            {
                if (pares % 2 == 0)
                {
                    soma += pares;
                }
                pares++;
            }

            Console.WriteLine(soma);
        }
    }
}