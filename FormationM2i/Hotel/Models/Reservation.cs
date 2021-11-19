using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    internal class Reservation
    {
        private int id;
        private Room room;
        private Client client;
        public int Id { get => id; }
        internal Room Room { get => room; }
        internal Client Client { get => client; }

        public Reservation(Room room, Client client)
        {
            this.id = new Random().Next(0,10000);
            this.room = room;
            this.client = client;
        }


        public override string ToString()
        {
            return $"Room N°{room.Id.ToString().PadLeft(3,'0')} reserved by {client}";
        }
    }
}
