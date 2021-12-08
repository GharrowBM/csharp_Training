using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Classes.Interfaces;

namespace TDD.Classes
{
    internal class PinsNumberGenerator : IIntGenerator
    {
        private int remainingPins = 10;

        public int Generate()
        {
            int numberGenerated = new Random().Next(0, remainingPins);
            remainingPins -= numberGenerated;
            return numberGenerated;
        }
    }
}
