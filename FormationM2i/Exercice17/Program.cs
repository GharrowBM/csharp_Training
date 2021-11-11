using System;

namespace Exercice17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Quelle boisson souhaitez-vous ? ---");
            Console.Write("\nListe des boissons disponibles : \n" +
                                "\t1 - Eau Plate \n" +
                                "\t2 - Eau Gazeuse \n" +
                                "\t3 - Coca-Cola \n" +
                                "\t4 - Fanta \n" +
                                "\t5 - Sprite \n" +
                                "\t6 - Orangina \n" +
                                "\t7 - 7 Up \n" +
                                "\nFaites votre Choix (1 à 7) : ");
            if (Int32.TryParse(Console.ReadLine(), out int value))
            {
                switch (value)
                {
                    case 1:
                        Console.WriteLine("Votre eau plate est servie...");
                        break;
                    case 2:

                        Console.WriteLine("Votre eau gazeuse est servie...");
                        break;
                    case 3:
                        Console.WriteLine("Votre Coca-Cola est servi...");
                        break;
                    case 4:
                        Console.WriteLine("Votre Fanta est servi...");
                        break;
                    case 5:
                        Console.WriteLine("Votre Sprite est servi...");
                        break;
                    case 6:
                        Console.WriteLine("Votre Orangina est servi...");
                        break;
                    case 7:
                        Console.WriteLine("Votre 7-Up est servi...");
                        break;
                    default:
                        Console.WriteLine("Cette boisson n'est pas à la carte !");
                        break;
                }
            }
            else Console.WriteLine("ERR: La valeur saisie n'est pas un Int32 correct...");
        }
    }
}
