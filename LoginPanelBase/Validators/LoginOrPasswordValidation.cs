using LoginPanelBase.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LoginPanelBase.ViewModels;

namespace LoginPanelBase.Validators
{
    class LoginOrPasswordValidation
    {


        public static string FinalVal(string username, string password, string message)
        {




            if (ValidationNullable.NullVal(username) == 1)
            {

                message = MainViewModel.InfoMessages[0];
                
                return message;

            }
            else if (!ValidationIsFullyString.IsStringLogin(username))
            {

                message = MainViewModel.InfoMessages[2];
                
                return message;

            }
            else if (IsPasswordNull.PassNull(username) == 1)
            {

                message = MainViewModel.InfoMessages[1];
                
                return message;

            }
            else if (!ValidationPassword.IsPasswordCorrect(username))
            {

                message = MainViewModel.InfoMessages[3];
                
                return message;


            }

            return null;



        }
    }
}
