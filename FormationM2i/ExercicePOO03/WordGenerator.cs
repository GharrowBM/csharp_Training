using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicePOO03
{
    internal class WordGenerator
    {

        private string[] words = { "Chat", "Chien", "Souris" };

        public string Generate()
        {
            return words[new Random().Next(words.Length)].ToUpper();
        }
    }
}
