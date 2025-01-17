﻿using System;
using System.Globalization;

namespace Exercice19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- Quelle sera le montant de mes impôts ? ---");

            try
            {
                Console.Write("Entrez le montant net imposable du foyer (en euros) : ");
                double HouseMoney = Convert.ToDouble(Console.ReadLine());
                Console.Write("Entrez le nombre d'adultes du foyer : ");
                double NbAdults = Convert.ToDouble(Console.ReadLine());
                Console.Write("Entrez le nombre d'enfants du foyer : ");
                double nbChildren = Convert.ToDouble(Console.ReadLine());

                double nbPart = NbAdults + (nbChildren > 2 ? nbChildren - 1 : nbChildren / 2);
                double quotientFamilial = 0.0;

                switch (HouseMoney)
                {
                    case var expression when HouseMoney > 158122:
                        quotientFamilial = (HouseMoney - 158122) * 0.45 + (158122.0 - 73517.0) * 0.41 + (73516.0 - 25710.0) * 0.30 + (25710.0 - 10085.0) * 0.11;
                        break;
                    case var expression when HouseMoney > 73516:
                        quotientFamilial = (HouseMoney - 73516) * 0.41 + (73516.0 - 25710.0) * 0.30 + (25710.0 - 10085.0) * 0.11;
                        break;
                    case var expression when HouseMoney > 25710:
                        quotientFamilial = (HouseMoney - 25710) * 0.3 + (25710.0 - 10085.0) * 0.11;
                        break;
                    case var expression when HouseMoney > 10084:
                        quotientFamilial = (HouseMoney - 10084) * 0.11;
                        break;
                    default:
                        quotientFamilial = 0.0;
                        break;
                }

                Console.WriteLine($"Pour {nbPart} parts et un quotient familial de {quotientFamilial.ToString("C", CultureInfo.CurrentCulture)}\nVous allez payer {(quotientFamilial * nbPart).ToString("C", CultureInfo.CurrentCulture)}");
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
