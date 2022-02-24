using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.DotNet6.EFClasses
{
    public class Product
    {
        public int ProductId { get; set; } // Clé primaire

        [Required] // Ne peut être null
        [StringLength(40)] // Taille de NVARCHAR(XXX) au lieu de NVARCHAR(MAX)
        public string ProductName { get; set; }

        [Column("UnitPrice", TypeName = "money")] // Le nom de la colonne est différent de celui de la propriété
        public decimal? Cost { get; set; } // Peut être null

        [Column("UnitsInStock")]
        public short? Stock { get; set; }
        public bool Discontinued { get; set; }


        // Création du lien avec la clé étrangère, virtual permet à EF Core d'ajouter des features via l'override
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
