using System;

namespace ExoVariableIntConcat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bonjour, veuilliez saisir votre prénom : ");
            string firstname = Console.ReadLine();
            Console.Write("Bonjour, veuilliez saisir votre nom : ");
            string lastname = Console.ReadLine();
            Console.Write("Bonjour, veuilliez saisir votre age : ");
            int age;
            if (int.TryParse(Console.ReadLine(), out age)) Console.WriteLine($"Bonjour {firstname} {lastname.ToUpper()}, vous avez {age} ans.");
            else Console.WriteLine($"Bonjour {firstname} {lastname.ToUpper()}, vous avez un âge inconnu suite à une erreur de parsing.");
            Console.ReadLine();
        }
    }
}
