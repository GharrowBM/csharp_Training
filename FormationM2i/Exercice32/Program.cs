using System;

namespace Exercice32
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int TABLE_LENGTH = 10;

            int[] tab = new int[TABLE_LENGTH];

            Console.WriteLine("Insertion des valeurs du tableau");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine($"Veilliez entrer la valeur n°{i + 1} : ");
                tab[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Affichage des valeurs du tableau : ");
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("\t");
                }
                Console.WriteLine(tab[i]);
            }
        }
    }
}
