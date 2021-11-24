using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CompteBancaireVersion1.Classes
{
    internal class DB
    {
        private static string connectionString = @"Data Source=(LocalDB)\coursDOTNET;Integrated Security=True";
        public static SqlConnection Connection
        {
            get => new SqlConnection(connectionString);
        }

    }
}
