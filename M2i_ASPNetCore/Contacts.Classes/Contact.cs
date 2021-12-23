using System;

namespace Contacts.Classes
{
    public class Contact
    {
        private int id;
        private string lastname;
        private string firstname;
        private string email;
        private string phone;
        private string avatarPath;

        public int Id { get => id; set => id = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string AvatarPath { get => avatarPath; set => avatarPath = value; }
    }
}
