using System;

namespace ExoVariableStringConcat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bonjour, veuilliez saisir votre prénom : ");
            string firstname = Console.ReadLine();
            Console.Write("Bonjour, veuilliez saisir votre nom : ");
            string lastname = Console.ReadLine();
            Console.WriteLine($"Bonjour {firstname} {lastname.ToUpper()}");
            Console.ReadLine();
        }
    }
}
