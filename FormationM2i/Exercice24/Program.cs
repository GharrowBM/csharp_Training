using System;

namespace Exercice24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Les suites chaînées de nombres ---");
            Console.Write("Merci de saisir un nombre :");
            if (Int32.TryParse(Console.ReadLine(), out int value))
            {
                Console.WriteLine("Les chaînes possibles sont :");
                for (int i = 1; i <= value / 2; i++)
                {
                    string str = $"{value} = {i}";
                    int sum = i;
                    for (int j = i+1; j <= value / 2 + 1; j++)
                    {
                        sum = sum + j;
                        str += $"+{j}";
                        if (sum == value)
                        {
                            Console.WriteLine(str);
                            break;
                        }
                        else if (sum > value)
                        {
                            break;
                        }


                    }
                }
            }
        }
    }
}
