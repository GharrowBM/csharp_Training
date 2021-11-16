using System;

namespace ExercicePOO01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chair chairA = new Chair();
            Chair chairB = new Chair(3, "black" ,"aluminium");
            Chair chairC = new Chair(1, "red", "plastic");

            Chair[] chairs = new[] { chairA, chairB, chairC };

            Console.WriteLine("Printing my chairs : ");

            foreach (Chair chair in chairs)
            {
                PrintObject(chair);
            }

            Console.ReadKey();
        }

        static void PrintObject(Object obj)
        {
            Console.WriteLine("\n---- Display of a new object ----");
            Console.WriteLine(obj.ToString());
            Console.WriteLine("--------------------------------------");
        }
    }
}
