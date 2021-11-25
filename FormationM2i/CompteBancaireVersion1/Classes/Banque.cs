using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CompteBancaireVersion1.Classes
{
    internal class Banque
    {
        List<Compte> comptes;
        private string request;
        private SqlCommand command;
        private SqlConnection connection;


        public Banque()
        {
            connection = DB.Connection;
            request = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'comptes';";
            command = new SqlCommand(request, connection);
            connection.Open();
            string confirm = (string)command.ExecuteScalar();
            command.Dispose();
            connection.Close();

            if (confirm == "comptes")
            {
                if (Compte.GetAllAccounts() == null) comptes = new List<Compte>();
                else comptes = Compte.GetAllAccounts();
            }
            else
            {
                request = "CREATE TABLE clients (id INT NOT NULL PRIMARY KEY IDENTITY(1, 1), nom VARCHAR(150), prenom VARCHAR(150), telephone VARCHAR(15));"
                    + "CREATE TABLE operations (id INT NOT NULL PRIMARY KEY IDENTITY(1, 1), montant DECIMAL, date_operation DATETIME, compte_id INT);"
                    + "CREATE TABLE comptes (id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),solde DECIMAL, client_id INT);";
                command = new SqlCommand(request, connection);
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

                comptes = new List<Compte>();
            }
        }

        public Client CreerClient(string nom, string prenom, string telephone)
        {
            if (!Client.ClientExist(telephone))
            {
                Client client = new Client(nom, prenom, telephone);
                if (client.Save())
                {
                    return client;
                }
                return default(Client);

            }
            return default(Client);
        }

        public Compte CreationCompte(Client client, decimal soldeInitial, string type)
        {
            Compte compte;
            if(type == "3")
            {
                compte = new CompteEpargne();
            }
            else if(type == "2")
            {
                compte = new ComptePayant();
            }
            else
            {
                compte = new Compte();
            }
            compte.Client = client;
            if (compte.Save())
            {
                compte.Depot(new Operation(soldeInitial));
            }
            return compte;
        } 

        public Compte RechercherCompte(int id)
        {
            Compte compte = default(Compte);
            foreach(Compte c in comptes)
            {
                if(c.Id == id)
                {
                    compte = c;
                    break;
                }
            }
            return compte;
        }
    }
}
