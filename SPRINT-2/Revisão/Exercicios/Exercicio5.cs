using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios
{
    //         Exercício:

    // 5) Você vai criar um programa que armazena as notas de vários alunos em diferentes disciplinas. O programa deve calcular a média de cada aluno e determinar quais alunos têm médias acima de 7.0 (aprovados) e quais têm médias abaixo de 7.0 (reprovados). O programa deve usar foreach para iterar sobre as coleções de alunos e suas notas.

    // Especificações:

    // - Armazene as notas de 3 disciplinas para cada aluno.
    // - Calcule a média de cada aluno.
    // - Exiba a média e o status (aprovado/reprovado) de cada aluno.
    // - Use foreach para iterar sobre os alunos e as disciplinas.
    public class Exercicio5
    {

        public static void Programa()
        {
            foreach (var item in GetAlunos())
            {
                Console.WriteLine($"========= - ALUNO - =========");

                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Nota - 1: {item.Nota1}");
                Console.WriteLine($"Nota - 2: {item.Nota2}");
                Console.WriteLine($"Nota - 3: {item.Nota3}");

                double media = CalcularMedia(item.Nota1, item.Nota2, item.Nota3);

                Console.WriteLine($"-------------------------");
                Console.WriteLine($"Média das notas = {media}");
                Console.WriteLine($"Status do aluno: {Status(media)}");
                Console.WriteLine($"=========================");


            }
        }

        public static List<Exercicio5Aluno> GetAlunos()
        {
            Exercicio5Aluno alunoK = new Exercicio5Aluno("Kauã", 5, 7, 9);
            Exercicio5Aluno alunoG = new Exercicio5Aluno("Gui", 2, 8, 6);
            Exercicio5Aluno alunoE = new Exercicio5Aluno("Enzo", 0, 4.5, 10);
            List<Exercicio5Aluno> alunos = new List<Exercicio5Aluno>();
            alunos.Add(alunoK);
            alunos.Add(alunoG);
            alunos.Add(alunoE);
            return alunos;
        }
        public static double CalcularMedia(double nota1, double nota2, double nota3)
        {
            double media = (nota1 + nota2 + nota3) / 3;

            return media;
        }

        public static string Status(double media)
        {
            if (media >= 7.0)
            {
                return "Aprovado";
            }
            else
            {
                return "Reprovado";
            }
        }
    }
}