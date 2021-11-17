using Heritage03.Models;
using System;

namespace Heritage03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock<int> list = new Stock<int>(5);


            for (int i = 0; i <= 5; i++)
            {
                list.Add(i);
            }

            list.Remove(3);


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(list.Find(i));
            }


        }
    }
}
