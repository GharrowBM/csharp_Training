using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CompteBancaireVersion1.Classes
{
    internal class Operation
    {
        private int id;
        private decimal montant;
        private DateTime dateEtheureOperation;
        public static string request;
        public static SqlCommand command;
        public static SqlConnection connection;

        public decimal Montant { get => montant;  }
        public DateTime DateEtheureOperation { get => dateEtheureOperation; }

        public Operation(decimal montant)
        {
            this.montant = montant;
            this.dateEtheureOperation = DateTime.Now;
        }

        public Operation()
        {

        }

        public override string ToString()
        {
            return $"Montant : {Montant}, Date de l'opération : {DateEtheureOperation}";
        }

        public static List<Operation> GetAllOperationsFromAccountID(int id)
        {
            List<Operation> operations = new List<Operation>();
            connection = DB.Connection;
            request = "SELECT * FROM operations WHERE compte_id = @compte;";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@compte", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Operation operation = new Operation()
                {
                    montant = reader.GetDecimal(1),
                    dateEtheureOperation = reader.GetDateTime(2)
                };
                operations.Add(operation);
            }
            reader.Close();
            command.Dispose();
            connection.Close();

            return operations;
        }

        public bool Save(Compte compte)
        {

            connection = DB.Connection;
            request = "INSERT INTO operations (montant, date_operation, compte_id) OUTPUT INSERTED.ID VALUES (@montant, @date, @compte);";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@montant", montant));
            command.Parameters.Add(new SqlParameter("@date", dateEtheureOperation));
            command.Parameters.Add(new SqlParameter("@compte", compte.Id));
            connection.Open();
            id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id > 0;
        }
    }
}
