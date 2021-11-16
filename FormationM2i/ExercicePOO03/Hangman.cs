using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicePOO03
{
    internal class Hangman
    {
        public int NbTries;
        public string wordToFind;
        public string mask;

        public Hangman()
        {
            this.NbTries = 0;
            this.wordToFind = new WordGenerator().Generate();
            this.mask = this.GenerateMask();
        }

        public bool TestChar(char c)
        {
            if (this.wordToFind.Contains(c.ToString().ToUpper()))
            {

                StringBuilder sb = new StringBuilder(this.mask);

                for (int i = 0; i < this.wordToFind.Length; i++)
                {
                    if (this.wordToFind[i] == c)
                    {
                        sb[i] = c;
                    }
                }

                this.mask = sb.ToString();

                return true;
            }
            else
            {
                this.NbTries++;
                return false;
            }
        }

        public bool TestWin()
        {
            return wordToFind == mask;
        }

        public string GenerateMask()
        {
            string tmpMask = "";

            foreach (char c in this.wordToFind)
            {
                tmpMask += "*";
            }

            return tmpMask;
        }

    }
}
