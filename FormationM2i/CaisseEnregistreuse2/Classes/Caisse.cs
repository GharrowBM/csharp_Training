using System;
using System.Collections.Generic;

namespace CaisseEnregistreuse.Classes
{
    public class Caisse
    {
        private List<Produit> produits;
        private List<Vente> ventes;
        public Caisse()
        {
            Produits = new List<Produit>();
            if (Produit.GetProduits().Count > 0) Produits = Produit.GetProduits();
            Ventes = new List<Vente>();
        }

        public List<Produit> Produits { get => produits; set => produits = value; }
        public List<Vente> Ventes { get => ventes; set => ventes = value; }

        public bool AjouterProduit(Produit produit)
        {
            if (Produit.GetProduit(produit.Id) == default(Produit))
            {
                produits.Add(produit);
                return produit.Save();
            }
            return false;
        }
        public bool AjouterVente(Vente vente)
        {
            if(Vente.GetVente(vente.Id) == default(Vente))
            {
                ventes.Add(vente);
                return true;
            }

            return false;
        }
        public Produit RechercherProduit(int id)
        {
            return Produit.GetProduit(id);
        }
    }
}
