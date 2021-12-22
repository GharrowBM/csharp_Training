using System;
using System.Linq;

namespace Banque.ASPNetCoreMVC.Services
{
    public class ToolsService
    {
        public string ConvertToChuckNorrisCode(string s)
        {
            string binaryResult = string.Empty;
            foreach (char m in s)
            {
                string lengthCheck = Convert.ToString((int)m, 2);
                if (lengthCheck.Length < 7)
                {
                    lengthCheck = new string('0', 7 - lengthCheck.Length) + lengthCheck;
                }
                binaryResult += lengthCheck;
            }

            char[] binaryArray = binaryResult.ToArray();

            string unaryResponse = string.Empty;
            char lastChar = '\0';
            for (int i = 0; i < binaryArray.Length; i++)
            {
                char currentchar = binaryArray[i];
                if (lastChar != '1' && currentchar == '1')
                {
                    unaryResponse += " 0 0";
                    lastChar = '1';
                }
                else if (lastChar == '1' && currentchar == '1')
                {
                    unaryResponse += "0";
                }
                else if (lastChar != '0' && currentchar == '0')
                {
                    unaryResponse += " 00 0";
                    lastChar = '0';
                }
                else if (lastChar == '0' && currentchar == '0')
                {
                    unaryResponse += "0";
                }
                else
                {
                    unaryResponse += "error";
                }

            }
            return unaryResponse;

        }
    }
}
