using System;

namespace Exercice27
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

                int i = 1;

                while (i <= value /2)
                {
                    int j = i + 1;
                    string str = $"{value} = {i}";
                    int sum = i;

                    while (j <= value /2 +1)
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

                        j++;
                    }

                    i++;
                }
            }
        }
    }
}
