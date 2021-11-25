using System;
using System.Collections.Generic;
using CaisseEnregistreuse.Interfaces;
using Microsoft.Data.SqlClient;

namespace CaisseEnregistreuse.Classes
{
    public class Vente
    {
        private int id;
        private string etat;
        private decimal total;
        private List<Produit> produits;
        public static string request;
        public static SqlCommand command;
        public static SqlConnection connection;
        public static SqlDataReader reader;

        public Vente()
        {
            produits = new List<Produit>();
            etat = "En cours";
        }

        public int Id { get { return id; } set { id = value; } }
        public string Etat { get => etat; set => etat = value; }
        public List<Produit> Produits { get => produits; set => produits = value; }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                Produits.ForEach(p =>
                {
                    total += p.Prix;
                });
                return total;
            }
            set => total = value;
        }

        public bool Valider(IPaiement paiement)
        {
            return false;
        }

        public bool AjouterProduit(Produit produit)
        {
            Produits.Add(produit);
            UpdateTotal();

            request = "INSERT INTO vente_produit (produit_id, vente_id) OUTPUT INSERTED.ID VALUES (@produit_id, @vente_id);";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@produit_id", produit.Id));
            command.Parameters.Add(new SqlParameter("@vente_id", Id));

            connection.Open();

            id = (int)command.ExecuteScalar();

            command.Dispose();
            connection.Close();

            return Id > 0;
        }

        public static Vente GetVente(int id)
        {
            Vente vente = default(Vente);
            request = "SELECT * FROM vente WHERE id = @id;";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                vente = new Vente()
                {
                    Id = reader.GetInt32(0),
                    Total = reader.GetDecimal(1),
                    Etat = reader.GetString(2),
                    Produits = Produit.GetProduitsFromVente(id)
                };
            }

            reader.Close();
            command.Dispose();
            connection.Close();

            return vente;
        }

        public bool Save()
        {
            request = "INSERT INTO vente (total, etat, type_paiement) OUTPUT INSERTED.ID VALUES (@total, @etat, @type_paiement);";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@total", Total));
            command.Parameters.Add(new SqlParameter("@etat", Etat));
            command.Parameters.Add(new SqlParameter("@type_paiement", 1));

            connection.Open();

            id = (int) command.ExecuteScalar();

            command.Dispose();
            connection.Close();

            return Id > 0;
        }

        public bool UpdateState()
        {
            request = "UPDATE vente SET etat = @etat WHERE id = @id;";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@etat", Etat));
            command.Parameters.Add(new SqlParameter("@id", Id));

            connection.Open();

            int nbRow = command.ExecuteNonQuery();


            command.Dispose();
            connection.Close();

            return nbRow == 1;
        }

        public bool UpdateTotal()
        {
            request = "UPDATE vente SET total = @total WHERE id = @id;";
            connection = Database.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@total", Total));
            command.Parameters.Add(new SqlParameter("@id", Id));

            connection.Open();

            int nbRow = command.ExecuteNonQuery();


            command.Dispose();
            connection.Close();

            return nbRow == 1;
        }
    }
}
