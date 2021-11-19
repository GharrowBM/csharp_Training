using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    internal class Client
    {
        private string id;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private List<Room> reservations;
        private static int nbOfClients = 0;

        public static int NbOfClients { get { return nbOfClients; } }

        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        internal List<Room> Reservations { get => reservations; set => reservations = value; }

        public Client(string lastName, string firstName, string phoneNumber)
        {
            this.id = Guid.NewGuid().ToString();
            this.lastName = lastName;
            this.firstName = firstName;
            this.phoneNumber = phoneNumber;
            this.reservations = new List<Room>();
            nbOfClients++;
        }

        public override string ToString()
        {
            return $"{lastName.ToUpper()} {firstName.Substring(0,1).ToUpper() + firstName.Substring(1, firstName.Length - 1).ToLower()} - {phoneNumber}";
        }

        public bool AddReservation(Room room)
        {
            reservations.Add(room);
            return true;
        }

        public bool CancelReservation(Room room)
        {
            reservations.Remove(room);
            return true;
        }

        public void ShowReservations()
        {
            Console.WriteLine($"\n::: {lastName.ToUpper()} {firstName.Substring(0, 1).ToUpper() + firstName.Substring(1, firstName.Length - 1).ToLower()}'s Reservations :::");
            foreach (Room room in reservations) Console.WriteLine(room.ToString());
        }
    }
}
