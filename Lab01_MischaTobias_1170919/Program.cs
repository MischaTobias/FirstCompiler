using System;

namespace Lab01_MischaTobias_1170919
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexp = Console.ReadLine();
            Scanner scanner = new Scanner(regexp);

            Token nextToken;

            do
            {
                nextToken = scanner.GetToken();
                Console.WriteLine("Token: {0}, Valor {1}", nextToken.Tag, nextToken.Value);
            } while (nextToken.Tag != TokenType.EOF);

            Console.ReadLine();
        } // MAIN
    }
}
