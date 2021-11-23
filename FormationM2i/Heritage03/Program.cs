using Heritage03.Models;
using System;

namespace Heritage03
{
    internal class Program
    {

        static void FullStock()
        {
            Console.WriteLine("La pile est pleine");
        }

        static void Main(string[] args)
        {
            Stock<int> list = new Stock<int>(5);
            list.Event += FullStock;

            for (int i = 0; i <= 5; i++)
            {
                list.Add(i);
            }

            bool test = true;

            for (int i = 0; i < 5; i++)
            {
                if (list[i] == 0) test = false;
            }

            if (test) list.FullStockEvent();

            list.Remove(3);


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(list.Find(i));
            }


        }
    }
}
