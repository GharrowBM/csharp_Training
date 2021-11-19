using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    internal class Room
    {
        private int id;
        private int nbOfBeds;

        public int Id { get => id; }
        public int NbOfBeds { get => nbOfBeds; set => nbOfBeds = value; }


        public Room(int id, int nbOfBeds)
        {
            this.id = id;
            this.nbOfBeds = nbOfBeds;
        }

        public override string ToString()
        {
            return $"Room n°{id.ToString().PadLeft(3,'0')}: {nbOfBeds} bed{(nbOfBeds > 1 ? "s" : null)}";
        }
    }
}
