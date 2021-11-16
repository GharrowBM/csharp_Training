using System;
using CompteBancaire.Views;

namespace CompteBancaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new BankView().Start();
        }
    }
}
