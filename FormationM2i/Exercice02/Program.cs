﻿using System;

namespace Exercice02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bonjour, veuilliez saisir votre prénom : ");
            string firstname = Console.ReadLine();
            Console.WriteLine($"Bonjour {firstname}");
            Console.ReadLine();
        }
    }
}
