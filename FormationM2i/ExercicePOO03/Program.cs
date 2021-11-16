using System;

namespace ExercicePOO03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Hangman hgmn = new Hangman();

            Console.WriteLine("--- Le jeu du Pendu ---");

            while (hgmn.NbTries < 10 && hgmn.TestWin() == false)
            {
                Console.WriteLine($"Le mot à trouver : {hgmn.mask}");
                Console.Write("Veuilliez saisir une lettre : ");
                hgmn.TestChar((char) Console.ReadLine().ToUpper()[0]);
            }

            if (hgmn.TestWin())
            {
                Console.WriteLine(hgmn.NbTries > 0 ? $"Félicitation, vous avez gagné avec seulement {hgmn.NbTries} erreurs !" : "Bravo, vous n'avez fait aucune erreur !!!");
            }
            else
            {
                Console.WriteLine("Désolé, mais vous avez perdu...");
            }
        }
    }
}
