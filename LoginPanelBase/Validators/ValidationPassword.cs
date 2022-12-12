using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginPanelBase.Validators
{
    public class ValidationPassword
    {

        public static bool IsPasswordCorrect(string password)
        {

            bool passwordPatternCheck = Regex.IsMatch(password, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");


            if (passwordPatternCheck)
            {

                return true;

            }
            else
            {
                return false;
            }


        }


    }
}
