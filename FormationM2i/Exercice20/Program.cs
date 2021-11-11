using System;

namespace Exercice20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Je compte jusqu'à 10 ---");
            Console.WriteLine("\nJE commence à compte r: ");
            int i;
            for (i = 1; i <= 10 ; i++)
            {
                Console.WriteLine(i);

            }
            Console.WriteLine($"Super, je sais compter jusqu'à {i-1} !");
        }
    }
}
