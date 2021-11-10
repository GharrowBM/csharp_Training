using System;

namespace Exercice05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int whatTypeOfSum;

            Console.WriteLine("Bonjour, voulez vous faire la somme d'entiers ou de décimaux ?");
            Console.WriteLine("\t1-Entiers");
            Console.WriteLine("\t2-Décimaux");

            // Quel type de somme ?
            if (int.TryParse(Console.ReadLine(), out whatTypeOfSum))
            {
                // Entiers
                if (whatTypeOfSum == 1)
                {
                    int nbA, nbB;

                    Console.WriteLine("Veuilliez entrer le premier nombre : ");
                    if (int.TryParse(Console.ReadLine(), out nbA))
                    {
                        Console.WriteLine("Veuilliez entrer le second nombre : ");
                        if (int.TryParse(Console.ReadLine(), out nbB)) Console.WriteLine($"La somme des deux nombres vaut : {nbA + nbB}");
                        else Console.WriteLine("La valeur donnée n'est pas du bon type !");
                    }
                    else Console.WriteLine("La valeur donnée n'est pas du bon type !");
                }

                // Décimaux
                else if (whatTypeOfSum == 2)
                {
                    double nbA, nbB;

                    Console.WriteLine("Veuilliez entrer le premier nombre : ");
                    if (double.TryParse(Console.ReadLine(), out nbA))
                    {
                        Console.WriteLine("Veuilliez entrer le second nombre : ");
                        if (double.TryParse(Console.ReadLine(), out nbB)) Console.WriteLine($"La somme des deux nombres vaut : {nbA + nbB}");
                        else Console.WriteLine("La valeur donnée n'est pas du bon type !");
                    }
                    else Console.WriteLine("La valeur donnée n'est pas du bon type !");
                }
                else
                {
                    Console.WriteLine("La valeur entrée ne correspond à aucuns choix");
                }
            }
            else Console.WriteLine("La valeur entrée n'est pas un nombre");

            Console.WriteLine("\nFin du programme...");
            Console.ReadLine();
        }
    }
}
