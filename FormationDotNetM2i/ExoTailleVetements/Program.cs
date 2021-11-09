using System;

namespace ExoTailleVetements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Quelle taille dois-je prendre ? ---");

            try
            {
                Console.Write("Entrez votre taille (en cm) : ");
                int height = Convert.ToInt32(Console.ReadLine());
                Console.Write("Entrez votre poids (en kg) : ");
                int weight = Convert.ToInt32(Console.ReadLine());

                if ((weight >= 43 && weight <= 47 && height >= 145 && height < 172) ||
                    (weight >= 48 && weight <= 53 && height >= 145 && height < 169) ||
                    (weight >= 54 && weight <= 59 && height >= 145 && height < 166) ||
                    (weight >= 60 && weight <= 65 && height >= 145 && height < 163))
                {
                    Console.WriteLine("Prenez la taille 1.");
                }
                else if ((weight >= 48 && weight <= 53 && height >= 169 && height < 183) ||
                    (weight >= 54 && weight <= 59 && height >= 166 && height < 178) ||
                    (weight >= 60 && weight <= 65 && height >= 163 && height < 175) ||
                    (weight >= 66 && weight <= 71 && height >= 160 && height < 172))
                {
                    Console.WriteLine("Prenez la taille 2.");
                }
                else if ((weight >= 54 && weight <= 59 && height >= 178) ||
                  (weight >= 60 && weight <= 65 && height >= 175) ||
                  (weight >= 66 && weight <= 71 && height >= 172) ||
                  (weight >= 72 && weight <= 77 && height >= 163))
                {
                    Console.WriteLine("Prenez la taille 3.");
                }
                else Console.WriteLine("Vous ne correspondez à aucune taille de vêtements...");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERR: Erreur lors de la conversion de la saisie utilisateur.");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
