using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAI.Classes
{
    // This class is a public representation of the normal Secret class, which is hidden due to API keys and private infos
    // To make the App works, change its name to Secrets after entering the required strings
    internal class SecretsPublic
    {
        string url = "Your URL Here";
        string predictionKey = "Your Key Here";
        string contentType = "Your Content Type Here";
    }
}
