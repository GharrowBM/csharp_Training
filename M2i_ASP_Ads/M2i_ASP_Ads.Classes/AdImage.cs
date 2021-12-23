using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2iASP_Ads.Classes
{
    public class AdImage
    {
        private int id;
        private string path;
        private Offer offer;

        public int Id { get { return id; } set { id = value; } }
        public string Path { get { return path; } set { path = value; } }
        public virtual Offer Offer { get { return offer; } set { offer = value;} }
    }
}
