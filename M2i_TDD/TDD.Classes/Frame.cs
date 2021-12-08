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

        public int Score { get { return score; } }
        public List<Roll> Rolls { get => rolls; }

        public Frame()
        {
            rolls = new List<Roll>();
        }

        public bool Roll()
        {
            if (score < 10 && rolls.Count < 3)
            {
                rolls.Add(new Roll() { Pins = new Random().Next(0, 11 - score) });
                score = 0;
                foreach (Roll roll in rolls) score += roll.Pins;
                return true;
            }

            return false;
        }
    }
}
