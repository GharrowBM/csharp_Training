using System;

namespace ExoNatureTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Quelle est la nature du triangle ABC ? ---");

            try
            {
                Console.Write("Entrez la longueur du segment AB : ");
                double coteAB = Convert.ToDouble(Console.ReadLine());
                Console.Write("Entrez la longueur du segment BC : ");
                double coteBC = Convert.ToDouble(Console.ReadLine());
                Console.Write("Entrez la longueur du segment AC : ");
                double coteAC = Convert.ToDouble(Console.ReadLine());

                if (coteAB == coteAC && coteAB == coteBC) Console.WriteLine("Le triangle est équilatéral !");
                else if (coteAB == coteBC) Console.WriteLine("Le triangle est isocèle en B !");
                else if (coteAB == coteAC) Console.WriteLine("Le triangle est isocèle en A !");
                else if (coteAC == coteBC) Console.WriteLine("Le triangle est isocèle en C !");
                else Console.WriteLine("Le triangle est quelconque.");

            } catch (FormatException ex)
            {
                Console.WriteLine("ERR: Erreur lors de la conversion de la saisie utilisateur.");
            } finally
            {
                Console.ReadLine();
            }
        }
    }
}
