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
        private List<Produit> produits;
        public static SqlCommand cmd;
        public static SqlConnection conn;
        public static string request;
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
        }

        public bool Valider(IPaiement paiement)
        {
            //A Coder
            return false;
        }

        public bool AjouterProduit(Produit produit)
        {
            Produits.Add(produit);
            return true;
        }

        public bool Save()
        {
            request = "INSERT INTO vente (total, etat, type_paiement) OUTPUT INSERTED.ID VALUES (@total, @etat, @type_paiement);";
            conn = Database.Connection;
            cmd = new SqlCommand(request, conn);
            cmd.Parameters.Add(new SqlParameter("@total", Total));
            cmd.Parameters.Add(new SqlParameter("@etat", Etat));
            cmd.Parameters.Add(new SqlParameter("@type_paiement", 1));
            conn.Open();
            
            Id = (int)cmd.ExecuteScalar();

            cmd.Dispose();
            conn.Close();

            return Id > 0;
        }

        public static Vente GetVente(int id)
        {
            Vente vente = default(Vente);
            request = "SELECT * FROM vente WHERE id=@id;";
            conn = Database.Connection;
            cmd = new SqlCommand(request, conn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                vente = new Vente() {
                    Id = id,
                    Etat = reader.GetString(2),
                    Produits = Produit.GetProduitsFromVente(id)
                };
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return vente;
        }
    }
}
