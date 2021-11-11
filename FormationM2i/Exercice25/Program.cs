using System;
using System.Linq;

namespace Exercice25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] notes = new int[5];
            Console.WriteLine("--- Gestion des notes ---");
            Console.WriteLine("\nVeuilliez saisir 5 notes :");
            for (int i = 0; i <5; i++)
            {
                Console.Write($"Veuilliez saisir la note {i + 1} (sur /20) ; ");
                notes[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nLa meilleure note est {notes.Max()}/20");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"La moins bonne note est {notes.Min()}/20");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"La moyenne des notes est {notes.Average()}/20");
        }
    }
}
