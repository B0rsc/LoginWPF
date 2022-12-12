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
     
        public static byte NullVal(string login)
        {

            if (string.IsNullOrWhiteSpace(login))
            {

                return 1;


            }
            return 0;

        }
    }
}
