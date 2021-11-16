using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicePOO04
{
    internal class Forum
    {
        private string name;
        private DateTime creationDate;
        private List<News> forumNews = new List<News>();

        public Forum(string name)
        {
            this.name = name;
            this.creationDate = DateTime.Now;
        }

        public bool AddNews(News news)
        {
            this.forumNews.Add(news);
            return true;
        }

        public bool RemoveNews(News news)
        {
            if (this.forumNews.Contains(news))
            {
                this.forumNews.Remove(news);
                return true,
            }

            return false;
        }
    }
}
