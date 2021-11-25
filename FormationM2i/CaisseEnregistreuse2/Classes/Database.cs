using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.Classes
{
    internal class Database
    {
        private static string connectionString = @"Data Source=(LocalDB)\coursDOTNET;Integrated Security=True";
        public static SqlConnection Connection
        {
            get => new SqlConnection(connectionString);
        }
    }
}
