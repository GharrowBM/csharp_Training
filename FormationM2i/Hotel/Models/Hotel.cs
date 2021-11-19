using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    internal class Hotel
    {
        private string name;
        private List<Client> clients;
        private List<Room> rooms;
        private List<Reservation> reservations;

        public Hotel(string name, int nbOfRooms)
        {
            this.name = name;
            this.clients = new List<Client>();
            this.rooms = new List<Room>();
            this.reservations = new List<Reservation>();
            RoomBuilder(nbOfRooms);
        }

        private void ShowMenu()
        {
            Console.WriteLine("\n::: Menu principal :::");
            Console.WriteLine("1. Ajouter un client");
            Console.WriteLine("2. Afficher la liste des clients");
            Console.WriteLine("3. Afficher les réservations d'un client");
            Console.WriteLine("4. Ajouter une réservation");
            Console.WriteLine("5. Annuler une réservation");
            Console.WriteLine("6. Afficher la liste des réservations");
            Console.WriteLine("0. Quitter le programme");
        }

        public void Run()
        {
            int mainMenuChoice = -1;

            do
            {
                ShowMenu();

                Console.Write("Entrez un choix : ");
                mainMenuChoice = int.Parse(Console.ReadLine());

                switch (mainMenuChoice)
                {
                    case 1:
                        AddClient();
                        break;
                    case 2:
                        ShowClients();
                        break;
                    case 3:
                        ShowClientReservations();
                        break;
                    case 4:
                        AddReservation();
                        break;
                    case 5:
                        CancelReservation();
                        break;
                    case 6:
                        ShowReservations();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Ce choix n'est pas disponible !");
                        break;

                }

            } while (mainMenuChoice != 0);
        }

        private void RoomBuilder(int nbOfRooms)
        {
            Random random = new Random();

            for (int i = 0; i <= nbOfRooms; i++)
            {
                int newRoomID = random.Next(0, 1000);

                do
                {
                    newRoomID = random.Next(0, 1000);
                } while (rooms.Find(x => x.Id == newRoomID) != null);

                rooms.Add(new Room(newRoomID, random.Next(0, 5)));
                
            }
        }

        private bool AddClient()
        {
            Console.WriteLine("\n::: Ajout d'un client :::");
            Console.Write("Donnez le nom du client : ");
            string clientLastName = Console.ReadLine();
            Console.Write("Donnez le prénom du client : ");
            string clientFirstName = Console.ReadLine();
            Console.Write("Donnez le téléphone du client : ");
            string clientPhoneNumber = Console.ReadLine();

            if (clients.Find(x => x.PhoneNumber == clientPhoneNumber) == null)
            {
                clients.Add(new Client(clientLastName, clientFirstName, clientPhoneNumber));
                return true;
            }

            return false;
        }

        private void ShowClients()
        {
            Console.WriteLine("\n::: Liste des clients :::");
            foreach(Client client in clients) Console.WriteLine(client.ToString());
        }

        private void ShowClientReservations()
        {
            Console.Write("Donnez le numéro de téléphone du client : ");
            string phoneToFind = Console.ReadLine();
            Client clientToFind = clients.Find(x => x.PhoneNumber == phoneToFind);

            if (clientToFind != null)
            {
                clientToFind.ShowReservations();
            }
            else
            {
                Console.WriteLine("Ce client n'est pas dans les archives !");
            }
        }

        private bool AddReservation()
        {
            Console.Write("Donnez le numéro de téléphone du client : ");
            string phoneToFind = Console.ReadLine();

            Client clientToFind = clients.Find(x => x.PhoneNumber == phoneToFind);

            if (clientToFind != null)
            {
                Console.Write("Donnez le nombre d'occupants : ");
                int nbOfSleepers = int.Parse(Console.ReadLine());

                Room roomToReserve = rooms.Find(x => x.NbOfBeds >= nbOfSleepers);

                if (!clientToFind.Reservations.Contains(roomToReserve) && roomToReserve != null)
                {
                    clientToFind.AddReservation(roomToReserve);
                    reservations.Add(new Reservation(roomToReserve, clientToFind));
                    return true;
                }
                else
                {
                    Console.WriteLine("Désole, mais aucune chambre ne semble convenir...");
                }
            }
            else
            {
                Console.WriteLine("Ce client n'est pas dans les archives !");
            }

            return false;

            
        }

        private bool CancelReservation()
        {
            Console.Write("Donnez le numéro de la réservation : ");
            int idOfReservationToFind = int.Parse(Console.ReadLine());

            Reservation reservationToFind = reservations.Find(x => x.Id == idOfReservationToFind);

            if (reservationToFind != null)
            {
                reservationToFind.Client.CancelReservation(reservationToFind.Room);
                reservations.Remove(reservationToFind);
                return true;
            }
            else
            {
                Console.WriteLine("Aucune réservation trouvée à cet ID !");
            }

            return false;
        }

        private void ShowReservations()
        {
            Console.WriteLine("\n::: Hotel Reservations :::");
            foreach (Reservation reservation in reservations) Console.WriteLine(reservation.ToString());
        }
    }
}
