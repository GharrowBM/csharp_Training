using System;

namespace Exercice21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Menu et sous-menus ---");
            Console.WriteLine("\nTable des matières : ");
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine($"Chapitre {i}");
                for (int j = 1; j < 4; j++)
                {
                    Console.WriteLine($"\tPartie {i}.{j}");
                }
            }
        }
    }
}
