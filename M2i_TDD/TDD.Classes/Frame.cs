using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Classes.Interfaces;

namespace TDD.Classes
{
    public class Frame
    {
        private int score;
        private List<Roll> rolls;

        public int Score { get { return score; }  }
        public List<Roll> Rolls { get => rolls; }

        public void Roll(IIntGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
