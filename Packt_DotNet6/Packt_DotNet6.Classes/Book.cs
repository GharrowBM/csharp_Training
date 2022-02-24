using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Packt_DotNet6.Classes
{
    public class Book
    {
        // Constructeur pour ne pas avoir de valeur nulle
        public Book(string title)
        {
            Title = title;
        }
        // Propriétés
        public string Title { get; set; }
        public string? Author { get; set; }
        // Champs 
        [JsonInclude] // Inclure ce champ
        public DateTime PublishDate;
        [JsonInclude] // Inclure ce champ
        public DateTimeOffset Created;
        public ushort Pages;
    }
}
