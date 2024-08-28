using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Exercicio1
    {
        public static void VerificarAprovacao()
        {
            Console.WriteLine($"Informe a nota:");
            int nota = int.Parse(Console.ReadLine()!);


            if (nota >= 5)
            {
                Console.WriteLine($"APROVADO");
            }
            else if (nota <= 2)
            {
                Console.WriteLine($"REPROVADO");
            }
            else
            {
                Console.WriteLine($"RECUPERAÇÃO");
            }
        }
    }
}