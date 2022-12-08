using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPanelBase.Model;
using System.Linq;
using System.Configuration;

namespace LoginPanelBase.Validators
{
    class LoggingValidation
    {



        public static byte LoggingVal(string login, string password)
        {


            using (var MyContext = new DatabaseContext())
            {


                var loginQuery = MyContext.Users.Any(User => User.Login.Equals(login));

                var passwordQuery = MyContext.Users.Any(User => User.Password.Equals(password));



                /*
                               foreach (var item in MyContext.Users)
                                {

                                    MyContext.Users.Remove(item);



                                }
                                MyContext.SaveChanges();

                */


                if (loginQuery == false)
                {

                    return 8;



                }
                else if (loginQuery && passwordQuery)
                {

                    return 6;


                }

                return 7;
            }

        }




    }




}
