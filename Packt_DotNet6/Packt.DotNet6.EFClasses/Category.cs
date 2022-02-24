using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.DotNet6.EFClasses
{
    public class Category
    {
        // Les propriétés représentent les colonnes en BdD
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        // Ici , on spécifie le type de la colonne en NTEXT
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        // Ici, on crée un lien One-to-Many avec Product en faisant une propriété de navigation
        public virtual ICollection<Product> Products { get; set; }

        // Le constructeur permet aux développeurs d'ajouter des produits dans la collection vide
        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
