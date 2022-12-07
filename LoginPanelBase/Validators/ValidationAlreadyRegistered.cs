using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPanelBase.Model;

namespace LoginPanelBase.Validators
{
    class ValidationAlreadyRegistered
    {


        public static bool AlreadyRegistered(string login)
        {



            using (var myContext = new DatabaseContext())
            {

                var query = myContext.Users.Any(User => User.Login.Equals(login));

                if (query)
                {

                    return true;

                } else

                { 
                    
                    return false;
                
                
                }



            }


            





    }









    }
}
