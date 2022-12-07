using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPanelBase.Model;
using System.Linq;
namespace LoginPanelBase.Validators
{
    class LoggingValidation
    {



        public static bool LoggingVal(string login, string password)
        {


            using (var MyContext = new DatabaseContext())
            {


                var loginQuery = MyContext.Users.Any(User => User.Login.Equals(login));

                var passwordQuery = MyContext.Users.Any(User => User.Password.Equals(password));


                if (loginQuery && passwordQuery)
                {

                    return true;


                }

                return false;
            }

        }

       


 }



    
}
