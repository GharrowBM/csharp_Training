using System;

namespace Exercice10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- La lettre est-elle une voyelle ? ---");

            Console.Write("Entrez une lettre : ");

            try
            {
                char inputFromUser = Convert.ToChar(Console.ReadLine().ToLower());
                if (inputFromUser == 'y' || inputFromUser == 'a' || inputFromUser == 'e' || inputFromUser == 'u' || inputFromUser == 'i' || inputFromUser == 'o') Console.WriteLine("Cette lettre est une voyelle !");
                else Console.WriteLine("Cette lettre est une consonne !");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERR: Problème de format de conversion !");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
