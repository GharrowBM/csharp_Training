using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CaisseEnregistreuse.Classes
{
    public class Produit
    {
        private int id;
        private string titre;
        private decimal prix;
        private int stock;
        public static string request;
        public static SqlCommand command;
        public static SqlConnection connection;
        public static SqlDataReader reader;


        public Produit(string titre, decimal prix, int stock)
        {
            Titre = titre;
            Prix = prix;
            Stock = stock;
        }

        public int Id { get => id; set => id = value; }
        public string Titre
        {
            get => titre;
            set
            {
                if (value.Length > 3)
                    titre = value;
                else
                   throw new FormatException("Le titre doit avoir 3 caractères min");
            }
        }
        public decimal Prix
        {
            get => prix; 
            set
            {
                if (value > 0)
                    prix = value;
                else
                    throw new FormatException("Le prix du produit doit être un nombre positif");
            }
        }
        public int Stock { get => stock; set => stock = value; }

        public static Produit GetProduit(int id)
        {
            Produit produit = default(Produit);
            request = "SELECT * FROM produit WHERE id = @id;";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                produit = new Produit(reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3)) { Id = reader.GetInt32(0)};
            }

            reader.Close();
            command.Dispose();
            connection.Close();

            return produit;
        }

        public static List<Produit> GetProduits()
        {
            List<Produit> produits = new List<Produit>();
            request = "SELECT * FROM produit;";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);

            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Produit produit = new Produit(reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3)) { Id = reader.GetInt32(0) };
                produits.Add(produit);
            }

            reader.Close();
            command.Dispose();
            connection.Close();

            return produits;
        }

        public static List<Produit> GetProduitsFromVente(int id)
        {
            List<Produit> produits = new List<Produit>();
            request = "SELECT * FROM produit AS p INNER JOIN vente_produit AS vp ON vp.produit_id = p.id WHERE vp.id = @id;";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Produit produit = new Produit(reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));
                produits.Add(produit);
            }

            reader.Close();
            command.Dispose();
            connection.Close();

            return produits;
        }
        public bool Save()
        {
            request = "INSERT INTO produit (titre, prix, stock) OUTPUT INSERTED.ID VALUES (@titre, @prix, @stock);";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", Titre));
            command.Parameters.Add(new SqlParameter("@prix", Prix));
            command.Parameters.Add(new SqlParameter("@stock", Stock));

            connection.Open();

            id = (int) command.ExecuteScalar();

            command.Dispose();
            connection.Close();

            return Id > 0;
        }

        public bool UpdateStock(int newStock)
        {
            request = "UPDATE produit SET stock = @stock WHERE id = @id;";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@stock", newStock));
            command.Parameters.Add(new SqlParameter("@id", Id));
            
            connection.Open();

            int nbRow = command.ExecuteNonQuery();


            command.Dispose();
            connection.Close();

            return nbRow == 1;
        }
    }
}
