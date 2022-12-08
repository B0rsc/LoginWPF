using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanelBase.Model
{
    public class DatabaseAdding
    {

        public static bool AddingToDatabadse (string login, string password)
        {

            using (DatabaseContext myContext = new DatabaseContext())
            {

                myContext.Users.Add(

                   new User()
                   {

                       Login = login,
                       Password = password,


                   }


                    );


                myContext.SaveChanges();
                return true;

            } 

            



        }



    }
}
