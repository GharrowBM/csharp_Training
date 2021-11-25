using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CompteBancaireVersion1.Classes
{
    internal class Compte
    {
        private int id;
        private decimal solde;
        private Client client;
        private List<Operation> operations;
        public static string request;
        public static SqlCommand command;
        public static SqlConnection connection;
        public int Id { get => id; }
        public decimal Solde { get => solde; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }

        public event Action<int, decimal> ADecouvert;
        public Compte()
        {
            operations = new List<Operation>();
        }

        public virtual bool Depot(Operation operation)
        {
            if (operation.Montant >= 0)
            {
                //operations.Add(operation);
                if (operation.Save(this))
                {
                    solde += operation.Montant;

                    return Update();
                }
                return false;
            }
            return false;
        }

        public virtual bool Retrait(Operation operation)
        {
            if (operation.Save(this))
            {
                solde += operation.Montant;
                if (solde < 0)
                {
                    if (ADecouvert != null)
                        ADecouvert(id, Solde);
                }
                return Update();
            }
            return false;


        }

        public static Compte GetAccountFromClient(Client client)
        {
            Compte compte = default(Compte);
            connection = DB.Connection;
            request = "SELECT * FROM comptes WHERE client_id = @client;";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@client", client.Id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                compte = new Compte()
                {
                    id = reader.GetInt32(0),
                    solde = reader.GetDecimal(1)
                };
                compte.Client = Client.GetClientFromAccountID(compte.Id);
                compte.Operations = Operation.GetAllOperationsFromAccountID(compte.Id);
            }
            reader.Close();
            command.Dispose();
            connection.Close();

            return compte;
        }

        public static List<Compte> GetAllAccounts()
        {
            List<Compte> comptes = new List<Compte>();
            connection = DB.Connection;
            request = "SELECT * FROM comptes;";
            command = new SqlCommand(request, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Compte compte = new Compte()
                {
                    id = reader.GetInt32(0),
                    solde = reader.GetDecimal(1)
                };
                compte.client = Client.GetClientFromAccountID(compte.Id);
                compte.operations = Operation.GetAllOperationsFromAccountID(compte.Id);

                comptes.Add(compte);
            }
            reader.Close();
            command.Dispose();
            connection.Close();

            return comptes;
        }

        public bool Save()
        {

            connection = DB.Connection;
            request = "INSERT INTO comptes (solde, client_id) OUTPUT INSERTED.ID VALUES (@solde, @client);";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@solde", solde));
            command.Parameters.Add(new SqlParameter("@client", client.Id));
            connection.Open();
            id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id > 0;
        }

        public bool Update()
        {
            request = "UPDATE comptes set solde=@solde where id=@id";
            connection = DB.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@solde", Solde));
            command.Parameters.Add(new SqlParameter("@id", Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }


    }
}
