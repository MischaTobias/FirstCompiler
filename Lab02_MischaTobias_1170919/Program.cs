using System;

namespace Lab02_MischaTobias_1170919
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexp = Console.ReadLine();
            Parser parser = new Parser();
            parser.Parse(regexp);
            Console.WriteLine("Expresión OK");
            Console.ReadLine();
        }
    }
}
