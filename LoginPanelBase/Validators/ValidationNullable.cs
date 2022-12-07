using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPanelBase.ViewModels;

namespace LoginPanelBase
{
    public class ValidationNullable
    {
     
        public static int NullVal(string login, string password)
        {
            
            if (login == null || login.Length == 0)
            {

                return 0;


            } else if (password == null || password.Length == 0)
            {
                return 1;
                

            } else 

            return 2;




        }
    }
}
