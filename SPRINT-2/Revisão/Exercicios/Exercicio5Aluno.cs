using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Exercicio5Aluno
    {
        public string Nome { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }

        public Exercicio5Aluno()
        {

        }
        public Exercicio5Aluno(string nome, double nota1, double nota2, double nota3)
        {
            this.Nome = nome;
            this.Nota1 = nota1;
            this.Nota2 = nota2;
            this.Nota3 = nota3;
        }
    }
}