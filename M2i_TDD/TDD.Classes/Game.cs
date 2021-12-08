using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Classes
{
    public class Game
    {
        public int GlobalScore { get; }
        public List<Frame> Frames { get; } = new List<Frame>();
    }
}
