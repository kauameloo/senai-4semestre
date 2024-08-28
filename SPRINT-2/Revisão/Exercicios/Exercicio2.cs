using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Exercicio2
    {
        public static void CalcularTabuada()
        {
            Console.WriteLine($"Insira um número: ");
            int num = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"===================");
            Console.WriteLine($"Tabuada do numero: {num}");
            Console.WriteLine($"===================");
            for (var i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} x {i} = {num * i}");

            }
            Console.WriteLine($"===============");
        }
    }
}