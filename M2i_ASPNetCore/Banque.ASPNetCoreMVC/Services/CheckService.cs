using System.Text.RegularExpressions;

namespace Banque.ASPNetCoreMVC.Services
{
    public class CheckService
    {
        public string CheckPassword(string pass)
        {
            string result = "Bad Password";
            bool matching = Regex.IsMatch(pass, "(?=.*[a-z])(?=.*[A-Z])");

            if (pass.Length >= 8 && matching)
            {
                result = "Good Password";
            }

            return result;
        }

    }
}
