using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageSalarie.Models
{
    internal class Commercial : Employee
    {
        private decimal chiffreAffaire;
        private decimal commission;

        public Commercial() : base()
        {

        }
        public Commercial(string matricule, string categorie, decimal salaire, string service, string nom, decimal chiffreAffaire, decimal commission) : base(matricule, categorie, salaire, service, nom)
        {
            ChiffreAffaire = chiffreAffaire;
            Commission = commission;
        }

        public decimal ChiffreAffaire { get => chiffreAffaire; set => chiffreAffaire = value; }
        public decimal Commission { get => commission; set => commission = value; }

        public override string AfficherSalaire()
        {
            decimal salaireAvecCommission = Salaire + (chiffreAffaire * commission / 100);
            return $"Le salaire du commercial {Nom} est de {salaireAvecCommission} euros";
        }
    }
}
