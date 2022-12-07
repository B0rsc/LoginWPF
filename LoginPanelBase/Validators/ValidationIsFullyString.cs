using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginPanelBase.Validators
{
    public class ValidationIsFullyString
    {

        public static bool IsStringLogin (string login)
        {

            Regex.Replace(login, @"\s+", "");

            bool containsNumbersLogin = login.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
            bool isStringLogin = login.All(Char.IsLetter);

            

            if (containsNumbersLogin == false && isStringLogin)
            {

                return false;


            }

            return true;



        }





    }
}
