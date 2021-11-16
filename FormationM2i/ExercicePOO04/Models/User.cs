using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicePOO04
{
    internal class User
    {
        private string name;
        private int age;

        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }


        public bool CreateNews(Forum forum)
        {
            Console.Write("Veuilliez donner le sujet de la nouvelle : ");
            string tmpSubject = Console.ReadLine();

            Console.Write("Veuilliez donner le corps de la nouvelle : ");
            string tmpBody = Console.ReadLine();

            News tmpNews = new News(tmpSubject, tmpBody);

            Console.WriteLine("Voici votre nouvelle : ");
            Console.WriteLine(tmpNews);

            Console.Write("Voulez vous poster la nouvelle ? OUI pour confirmer"); 
            if (Console.ReadLine().ToUpper().Substring(0,3) == "OUI") forum.AddNews(tmpNews);

            return true;
        }

        public void SeeNews()
        {

        }

        public bool AnswerNews(News)
    }
}
