// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


Console.WriteLine($"Informe a nota:");
int nota = int.Parse(Console.ReadLine());


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