using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Exercicio4
    {
        public static void AdivinharNumero()
        {

            Random numero = new Random();
            int numeroEscolhido = numero.Next(1, 100);
            int resposta, count = 0;
            do
            {
                Console.WriteLine($"Adivinhe o número:");
                resposta = int.Parse(Console.ReadLine()!);

                if (resposta != numeroEscolhido)
                {
                    Console.WriteLine($"Número errado!");
                    count++;
                }
                else
                {
                    Console.WriteLine($"Você acertou!");
                    Console.WriteLine($"Número de tentativas: {count}");

                }

            } while (resposta != numeroEscolhido);

        }
    }
}