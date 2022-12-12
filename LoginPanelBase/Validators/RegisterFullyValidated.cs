using LoginPanelBase.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPanelBase.Model;
using LoginPanelBase.ViewModels;

namespace LoginPanelBase.Validators
{
    public class RegisterFullyValidated
    {


        public static byte isRegisterValid(string login, string password)
        {

            if (ValidationNullable.NullVal(login) == 1)
            {


                return 0;

            }
            else if (!ValidationIsFullyString.IsStringLogin(login))
            {


                return 2;

            }
            else if (ValidationAlreadyRegistered.AlreadyRegistered(login))
            {

                return 5;


            }
            else if (IsPasswordNull.PassNull(password) == 1)
            {


                return 1;

            }
            else if (!ValidationPassword.IsPasswordCorrect(password))
            {


                return 3;


            }
            else
            {


                return 4;

            }


        }

    }
}
