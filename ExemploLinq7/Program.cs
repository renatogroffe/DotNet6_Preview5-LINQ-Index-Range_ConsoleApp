using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploLinq7
{
    class Program
    {
        static void Main()
            {
            Console.WriteLine("*** Suporte a Index e Ranges em LINQ ***");

            // Refatoração dos exemplos do artigo
            // Novidades do C# 8.0: como habilitar, Ranges e Indices
            // https://renatogroffe.medium.com/novidades-do-c-8-0-como-habilitar-ranges-e-indices-68396fe9afc1

            var tecnologias =
                new string[] { ".NET 6", "C#", "ASP.NET Core", "Azure", "Blazor", "Visual Studio 2022" };

            ImprimirElementos(tecnologias.Take(2..5), // tecnologias.Take(5).Skip(2) = tecnologias[range]
                "Retornando elementos dos índices 2 a 4");

            Range range = 2..5;
            ImprimirElementos(tecnologias.Take(range), // tecnologias.Take(5).Skip(2) = tecnologias[range]
                "Retornando elementos dos índices 2 a 4 via struct Range");

            ImprimirElementos(tecnologias.Take(0..5), // tecnologias.Take(5) = tecnologias[0..5],
                "Retornando elementos dos índices 0 a 4");
            ImprimirElementos(tecnologias.Take(..5), // tecnologias.Take(5) = tecnologias[..5]
                "Retornando até o elemento de posição 4 (desde a posição 0)");

            ImprimirElementos(tecnologias.Take(1..^2), // tecnologias.SkipLast(2).Skip(1) = tecnologias[1..^2]
                "Retornando elementos da posição 1 até o antepenúltimo");
            ImprimirElementos(tecnologias.Take(1..^1), // tecnologias.SkipLast(1).Skip(1) = tecnologias[1..^1],
                "Retornando elementos da posição 1 até o penúltimo");
            ImprimirElementos(tecnologias.Take(..^1), // tecnologias.SkipLast(1) = tecnologias[..^1]
                "Retornando até o penúltimo elemento");

            ImprimirElementos(tecnologias.Take(3..), // tecnologias.Skip(3)
                "Ignorando os 3 primeiros elementos");
            ImprimirElementos(tecnologias.Take(^2..), // tecnologias.TakeLast(2)
                "Retornando os 2 últimos elementos");
            ImprimirElementos(tecnologias.Take(^4..^2), // tecnologias.TakeLast(4).SkipLast(2)
                "Retornando o terceiro e o quarto elementos");
            Console.WriteLine($"Penúltimo elemento: *{tecnologias.ElementAt(^2)}*");
        }

        private static void ImprimirElementos(
            IEnumerable<string> selecaoTecnologias,
            string mensagem)
        {
            Console.Write($"{mensagem}: [");
            foreach (string tecnologia in selecaoTecnologias)
                Console.Write($"  *{tecnologia}*");
            Console.Write("  ]" + Environment.NewLine);
        }
    }
}