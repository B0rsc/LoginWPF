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

        public static bool IsStringLogin(string login)
        {

            try
            {

                Regex.Replace(login, @"\s+", "");
            }
            catch
            {

                return false;

            }

            bool isStringLogin = login.All(Char.IsLetter);




            if (login.Length < 3)
            {

                return false;


            }
            else if (isStringLogin)
            {

            
                return true;


            }





        }





    }
}
