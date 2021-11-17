using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heritage02.Models;

namespace Heritage02.Views
{
    internal class IHM
    {
        private Forum workingForum;

        public IHM()
        {
            this.workingForum = new Forum("Default");
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine($"=== Gestion du Forum {workingForum.Name.ToUpper()} ===");
            Console.WriteLine("1---Voir les nouvelles");
            Console.WriteLine("2---Poster une nouvelle");
            Console.WriteLine("3---Repondre à une nouvelle");
            Console.WriteLine("4---Supprimer une nouvelle");
            Console.WriteLine("0---Quitter");
        }

        private void ShowNews()
        {
            Console.Clear();
            Console.WriteLine("=== Nouvelles du Forum ===");
            foreach(News news in workingForum.News) Console.WriteLine(news);
            Console.WriteLine("==========================");
        }

        private void PostNewNews()
        {
            Console.Clear();
            Console.WriteLine("=== Création d'une nouvelle ===");
            Console.Write("Quel est le sujet de la nouvelle : ");
            string tmpSubject = Console.ReadLine();
            Console.Write("Ecrivez la description de la nouvelle : ");
            string tmpDesc = Console.ReadLine();

            if (workingForum.AddNews(new News(tmpSubject, tmpDesc)))
            {
                Console.WriteLine("Nouvelle créée avec succès !");
            }
            else
            {
                Console.WriteLine("Problème lors de la création de la nouvelle...");
            }
        }

        private void AnswerANews()
        {
            Console.Clear();
            Console.WriteLine("=== Répondre à une nouvelle ===");
            Console.Write("Donnez le début de l'ID de la nouvelle à laquelle vous souhaitez répondre : ");
            string startID = Console.ReadLine();
            if (workingForum.News.Find(x => x.Id.StartsWith(startID)) != null)
            {
                Console.Write("Quel est le sujet de la réponse : ");
                string tmpSubject = Console.ReadLine();
                Console.Write("Ecrivez la description de la réponse : ");
                string tmpDesc = Console.ReadLine();

                if (workingForum.AnswerNews(startID,new News(tmpSubject, tmpDesc)))
                {
                    Console.WriteLine("Réponse postée avec succès !");
                }
                else
                {
                    Console.WriteLine("Problème lors de la création de la réponse...");
                }
            }
            else
            {
                Console.WriteLine("Cette nouvelle ne semble pas exister...");
            }

        }

        private void DeleteNews()
        {
            Console.Clear();
            Console.WriteLine("=== Supprimer une nouvelle ===");

        }

        public void Start()
        {
            int mainNenuChoice = 1;

            while (mainNenuChoice != 0)
            {
                ShowMenu();

                if (int.TryParse(Console.ReadLine(), out mainNenuChoice))
                {
                    switch (mainNenuChoice)
                    {
                        case 1:
                            ShowNews();
                            Console.ReadLine();
                            break;
                            case 2:
                            PostNewNews();
                            Console.ReadLine();
                            break;
                        case 3:
                            AnswerANews();
                            Console.ReadLine();
                            break;
                        case 4:
                            DeleteNews();
                            Console.ReadLine();
                            break;
                        case 0:

                            break;
                        default:
                            Console.WriteLine("Veuilliez saisir un choix entre 1 et 4 compris !");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("ERR: Problème de conversion...");
                }

            }
        }
    }
}
