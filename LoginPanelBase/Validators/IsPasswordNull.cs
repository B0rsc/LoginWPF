using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPanelBase.Model;

namespace LoginPanelBase.Validators
{
    public class IsPasswordNull
    {

        public static byte PassNull(string password)
        {


            if (string.IsNullOrEmpty(password))
            {

               
               return 1;


            }
            return 0;

        }

    }
}
