using Agenda.Classes;
using Agenda.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

int mainMenuChoice = -1;
AgendaContext context = new AgendaContext();

do
{
    Console.WriteLine("=== MAIN MENU ===");
    Console.WriteLine("1. View Clients");
    Console.WriteLine("2. Add a Client");
    Console.WriteLine("3. Edit a Client");
    Console.WriteLine("4. Remove a Client");
    Console.WriteLine("5. View Appointments");
    Console.WriteLine("6. Add an Appointment");
    Console.WriteLine("7. Edit an Appointment");
    Console.WriteLine("8. Remove an Appointment");
    Console.WriteLine("0. Quit");

    if (int.TryParse(Console.ReadLine(), out mainMenuChoice))
    {
        switch (mainMenuChoice)
        {
            case 0:
                break;
            case 1:
                foreach (var client in context.Clients) Console.WriteLine(client);
                break;
            case 2:
                Console.Write("\nLastname: ");
                string clientAddLastname = Console.ReadLine();
                clientAddLastname = clientAddLastname.ToUpper();
                Console.Write("\nFirstname: ");
                string clientAddFirstname = Console.ReadLine();
                clientAddFirstname = clientAddFirstname.Substring(0, 1).ToUpper() + clientAddFirstname.Substring(1, clientAddFirstname.Length - 1).ToLower();
                Console.Write("\nPhone number: ");
                string clientAddPhonenumber = Console.ReadLine();
                Console.Write("\nEmail: ");
                string clientAddEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(clientAddEmail) && !string.IsNullOrEmpty(clientAddPhonenumber) && !string.IsNullOrEmpty(clientAddFirstname) && !string.IsNullOrEmpty(clientAddLastname))
                {
                    Client clientToAdd = new Client() { Firstname = clientAddFirstname, Lastname = clientAddLastname, PhoneNumber = clientAddPhonenumber, Email = clientAddEmail };
                    context.Clients.Add(clientToAdd);
                    context.SaveChanges();
                    Console.WriteLine($"{clientAddFirstname} {clientAddLastname} added to agenda.");
                }
                break;
            case 3:
                Console.Write("ID: ");
                if (int.TryParse(Console.ReadLine(), out int clientIdToEdit))
                {
                    Client clientToEdit = context.Clients.Include(c => c.Appointments).FirstOrDefault(c => c.Id == clientIdToEdit);
                    if (clientIdToEdit != null)
                    {
                        Console.Write("\nNew Lastname: ");
                        string clientEditNewLastname = Console.ReadLine();
                        clientEditNewLastname = clientEditNewLastname.ToUpper();
                        Console.Write("\nNew Firstname: ");
                        string clientEditNewFirstname = Console.ReadLine();
                        clientEditNewFirstname = clientEditNewFirstname.Substring(0, 1).ToUpper() + clientEditNewFirstname.Substring(1, clientEditNewFirstname.Length - 1).ToLower();
                        Console.Write("\nNew Phone number: ");
                        string clientEditNewPhonenumber = Console.ReadLine();
                        Console.Write("\nNew Email: ");
                        string clientEditNewEmail = Console.ReadLine();
                        if (!string.IsNullOrEmpty(clientEditNewLastname) && !string.IsNullOrEmpty(clientEditNewFirstname) && !string.IsNullOrEmpty(clientEditNewPhonenumber) && !string.IsNullOrEmpty(clientEditNewEmail))
                        {
                            clientToEdit.Lastname = clientEditNewLastname;
                            clientToEdit.Firstname = clientEditNewFirstname;
                            clientToEdit.PhoneNumber = clientEditNewPhonenumber;
                            clientToEdit.Email = clientEditNewEmail;
                            context.Clients.Update(clientToEdit);
                            Console.WriteLine($"{clientEditNewFirstname} {clientEditNewLastname} edited to agenda.");
                        }
                    }
                }
                break;
            case 4:
                Console.Write("ID: ");
                if (int.TryParse(Console.ReadLine(), out int clientIdToRemove))
                {
                    Client clientToRemove = context.Clients.Include(c => c.Appointments).FirstOrDefault(c => c.Id == clientIdToRemove);
                    if (clientToRemove != null)
                    {
                        context.Clients.Remove(clientToRemove);
                        context.SaveChanges();
                        Console.WriteLine($"{clientToRemove.Firstname} {clientToRemove.Lastname} removed from agenda.");
                    }
                }
                break;
            case 5:
                foreach (var appointment in context.Appointments) Console.WriteLine(appointment);
                break;
            case 6:
                Console.Write("\nTitle: ");
                string appointmentAddTitle = Console.ReadLine();
                Console.Write("\nDate (dd/mm/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime appointmentAddDate))
                {
                    if (string.IsNullOrEmpty(appointmentAddTitle))
                    {
                        Console.Write("ID: ");
                        if (int.TryParse(Console.ReadLine(), out int clientIdToAddToAppointment))
                        {
                            Client clientToAddToAppointment = context.Clients.Include(c => c.Appointments).FirstOrDefault(c => c.Id == clientIdToAddToAppointment);
                            if (clientToAddToAppointment != null)
                            {
                                Appointment appointmentToAdd = new Appointment() { Title = appointmentAddTitle, Date = appointmentAddDate };
                                appointmentToAdd.Clients.Add(clientToAddToAppointment);
                                clientToAddToAppointment.Appointments.Add(appointmentToAdd);
                                context.SaveChanges();
                            }
                        }

                    }
                }
                break;
            case 7:
                Console.Write("ID: ");
                if (int.TryParse(Console.ReadLine(), out int appointmentIdToEdit))
                {
                    Appointment appointmentToEdit = context.Appointments.Include(a => a.Clients).FirstOrDefault(a => a.Id == appointmentIdToEdit);
                    if (appointmentToEdit != null)
                    {
                        int appointmentMenuChoice = -1;

                        do
                        {
                            Console.WriteLine("=== EDIT APPOINTMENT ===");
                            Console.WriteLine("1. Add Client");
                            Console.WriteLine("2. Remove Client");
                            Console.WriteLine("3. Change Details");
                            Console.WriteLine("0. Cancel");

                            if (int.TryParse(Console.ReadLine(), out appointmentMenuChoice))
                            {
                                switch (appointmentMenuChoice)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        Console.Write("ID: ");
                                        if (int.TryParse(Console.ReadLine(), out int clientIdToAddToAppointment2))
                                        {
                                            Client clientToAddToAppointment2 = context.Clients.Include(c => c.Appointments).FirstOrDefault(c => c.Id == clientIdToAddToAppointment2);
                                            if (clientToAddToAppointment2 != null)
                                            {
                                                appointmentToEdit.Clients.Add(clientToAddToAppointment2);
                                                context.Appointments.Update(appointmentToEdit);
                                            }
                                        }
                                        break;
                                    case 2:
                                        Console.Write("ID: ");
                                        if (int.TryParse(Console.ReadLine(), out int clientIdToRemoveFromAppointment))
                                        {
                                            Client clientToRemoveFromAppointment2 = context.Clients.Include(c => c.Appointments).FirstOrDefault(c => c.Id == clientIdToRemoveFromAppointment);
                                            if (clientToRemoveFromAppointment2 != null)
                                            {
                                                appointmentToEdit.Clients.Remove(clientToRemoveFromAppointment2);
                                                context.Appointments.Update(appointmentToEdit);
                                            }
                                        }
                                        break;
                                    case 3:
                                        Console.Write("New Title: ");
                                        string appointmentEditTitle = Console.ReadLine();
                                        if (DateTime.TryParse(Console.ReadLine().Trim(), out DateTime appointmentEditDate))
                                        {
                                            appointmentToEdit.Title = appointmentEditTitle;
                                            appointmentToEdit.Date = appointmentEditDate;
                                            context.SaveChanges();
                                            Console.WriteLine("Appointment edited with success!");
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Incorrent choice...");
                                        break;
                                }
                            }

                        } while (appointmentMenuChoice != 0);
                    }
                }
                break;
            case 8:
                Console.Write("ID: ");
                if (int.TryParse(Console.ReadLine(), out int appointmentIdToRemove))
                {
                    Appointment appointmentToRemove = context.Appointments.Include(a => a.Clients).FirstOrDefault(a => a.Id == appointmentIdToRemove);
                    if (appointmentToRemove != null)
                    {
                        context.Appointments.Remove(appointmentToRemove);
                        context.SaveChanges();
                        Console.WriteLine($"{appointmentToRemove.Title} removed from agenda.");
                    }
                }
                break;
            default:
                break;
        }
    }
    else
    {
        Console.WriteLine("ERR: Can't read that choice...");
    }
} while (mainMenuChoice != 0);