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
        public static SqlCommand cmd;
        public static SqlConnection conn;
        public static string request;
        public static SqlDataReader reader;

        //public Produit()
        //{

        //}
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

        public static Produit GetProduit(int id)
        {
            Produit produit = default(Produit);
            request = "SELECT * FROM produit WHERE id=@id;";
            conn = Database.Connection;
            cmd = new SqlCommand(request, conn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                produit = new Produit(reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return produit;
        }

        public static List<Produit> GetProduitsFromVente(int id)
        {
            List<Produit> produits = new List<Produit>();
            request = "SELECT * FROM produit AS p INNER JOIN vente_produit AS vp ON p.id = vp.produit_id WHERE vp.vente_id=@id;";
            conn = Database.Connection;
            cmd = new SqlCommand(request, conn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Produit produit = new Produit(reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));
                produits.Add(produit);
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();
            return produits;
        }

        public bool Save()
        {
            request = "INSERT INTO produit (titre, prix, stock) OUTPUT INSERTED.ID VALUES (@titre, @prix, @stock);";
            conn = Database.Connection;
            cmd = new SqlCommand(request, conn);
            cmd.Parameters.Add(new SqlParameter("@titre", Titre));
            cmd.Parameters.Add(new SqlParameter("@prix", Prix));
            cmd.Parameters.Add(new SqlParameter("@stock", Stock));
            conn.Open();

            Id = (int)cmd.ExecuteScalar();

            cmd.Dispose();
            conn.Close();

            return Id > 0;
        }
        public int Stock { get => stock; set => stock = value; }
    }
}
