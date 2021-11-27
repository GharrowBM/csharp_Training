using DesktopContactsApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Logique d'interaction pour ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            Owner = App.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contact = contact;
            emailTextBox.Text = contact.Email;
            nameTextBox.Text = contact.Name;
            phoneTextBox.Text = contact.Phone;

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Phone = phoneTextBox.Text;
            contact.Email = emailTextBox.Text;

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            Close();
        }
    }
}
