using System;
using CustomCompiler;

namespace Lab1_PrimerCompilador
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            var repetir = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese la cadena a validar");
                try
                {
                    var result = parser.Parse(Console.ReadLine());
                    if (double.IsNegativeInfinity(result)) Console.WriteLine("Infinito negativo");
                    else if (double.IsInfinity(result)) Console.WriteLine("Infinito");
                    else Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Ingrese una Y si quiere realizar otra operación");
                if (Console.ReadKey().Key != ConsoleKey.Y) repetir = false;
            } while (repetir);
            Console.ReadLine();
        }
    }
}
