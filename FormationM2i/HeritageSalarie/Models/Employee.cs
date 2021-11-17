using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageSalarie.Models
{
    internal class Employee
    {
        private string matricule;
        private string categorie;
        private decimal salaire;
        private string service;
        private string nom;

        private static decimal totalSalaire;
        private static int nbSalaries = 0;
        public string Matricule { get => matricule; set => matricule = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public decimal Salaire { get => salaire; set => salaire = value; }
        public string Service { get => service; set => service = value; }
        public string Nom { get => nom; set => nom = value; }
        public static decimal TotalSalaire { get => totalSalaire; }
        public static int NbSalaries { get => nbSalaries; }


        public Employee()
        {

        }
        public Employee(string matricule, string categorie, decimal salaire, string service, string nom)
        {
            Matricule = matricule;
            Categorie = categorie;
            Salaire = salaire;
            Service = service;
            Nom = nom;
            totalSalaire += salaire;
            nbSalaries++;
        }

        public virtual string AfficherSalaire()
        {
            return $"Le salaire de {Nom} est de {Salaire} euros";
        }
    }
}
