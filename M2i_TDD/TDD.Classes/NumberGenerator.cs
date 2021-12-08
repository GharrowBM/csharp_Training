using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Classes.Interfaces;

namespace TDD.Classes
{
    public class NumberGenerator : IIntGenerator
    {
        public int GenerateBetween(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}
