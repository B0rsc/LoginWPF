using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginPanelBase.MessageBoxHelper
{
    public class MessageBoxClass
    {



        public static void MessageBoxFun(string message)
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            string caption = "";
            string messageBoxText = message;


            MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);





        }








    }
}
