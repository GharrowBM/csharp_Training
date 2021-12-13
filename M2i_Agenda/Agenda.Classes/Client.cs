namespace Agenda.Classes
{
    public class Client
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}