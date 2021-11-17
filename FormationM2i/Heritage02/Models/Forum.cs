using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage02.Models
{
    internal class Forum
    {
        private string id;
        private string name;
        private DateTime creationDate;
        private List<News> news;
        private Moderator modo;

        public string Name { get { return name; } }
        public List<News> News { get { return news; } }
        
        public Forum(string name)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
            this.creationDate = DateTime.Now;
            this.news = new List<News>();
            this.modo = null;
        }

        public Forum(string name, Moderator modo)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
            this.creationDate = DateTime.Now;
            this.news = new List<News>();
            this.modo = modo;
        }

        public bool AddNews(News newNews)
        {
            if (!news.Contains(newNews))
            {
                news.Add(newNews);
                return true;
            }

            return false;
        }

        public bool DeleteNews(string id, Moderator modo)
        {
            if (news.Find(x => x.Id.StartsWith(id)) != null)
            {
                if (this.modo == modo)
                {
                    news.Remove(news.Find(x => x.Id.StartsWith(id)));
                    return true;
                }
            }
            return false; 

        }

        public News ShowNews(string id)
        {
            return news.Find(x => x.Id.StartsWith(id));
        }

        public bool AnswerNews(string id, News answer)
        {
            if (news.Find(x => x.Id.StartsWith(id)) != null)
            {
                news.Insert(news.IndexOf(news.Find(x => x.Id.StartsWith(id))), answer);
                return true;
            }

            return false;
        }

        public bool AddModoToForum(Moderator newModo)
        {
            if (this.modo != null)
            {
                this.modo = newModo;
                return true;
            }

            return false;
        }
    }
}
