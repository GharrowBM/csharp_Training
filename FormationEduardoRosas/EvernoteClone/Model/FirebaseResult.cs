using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Model
{
    public class FirebaseResult
    {
        public string Kind { get; set; }
        public string IdToken { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
        public string LocalId { get; set; }

    }
}
