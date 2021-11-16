using System;
using Heritage01.Models;

namespace Heritage01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car laguna = new Car("Renault", "Laguna", 30.0);
            laguna.Fill(30.0);
            Console.WriteLine(laguna);
            laguna.Start();
            laguna.Move(25.0);
            Console.WriteLine(laguna);

        }
    }
}
