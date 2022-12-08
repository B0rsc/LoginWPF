using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsConverterApp.Commands;
using LoginPanelBase.Model;
using System.Diagnostics;
using LoginPanelBase.Validators;
using System.IO;
using System.Windows;
using System.Net.Mail;
using System.Reflection;
using System.Windows.Markup;
using LoginPanelBase.MessageBoxHelper;

namespace LoginPanelBase.ViewModels
{
    public class MainViewModel : ObservableObject
    {

       

        string message;
        private string _password;
        

        public static List<string> InfoMessages = new List<string>()
        {
            {"Empty login"}, // 0
            {"Empty password"}, // 1
            {"Wrong characters in Login"}, // 2
            {"Password doesn't meet the requirements"}, // 3
            {"Register successful!" }, // 4
            {"This user already exists - try to log in"}, //5
            {"Login successful!"}, // 6
            {"Login unsucessful :("}, // 7
            {"User not found - register" } // 8







        };




        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));


            }
        }

        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }



        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null) _loginCommand = new RelayCommand(
                    (object o) =>
                    {


                        byte CheckLogin = LoggingValidation.LoggingVal(_login, _password);


                        switch (CheckLogin)
                        {
                            case 6:
                                message = InfoMessages[6];
                                
                                MessageBoxClass.MessageBoxFun(message);

                                break;
                            case 7:
                                message = InfoMessages[7];
                               
                                MessageBoxClass.MessageBoxFun(message);

                                break;
                            case 8:
                                message = InfoMessages[8];
                               
                                MessageBoxClass.MessageBoxFun(message);

                                break;




                        }








                    });
                return _loginCommand;
            }
        }

        private ICommand _registerCommand;
        public ICommand RegisterCommand
        {


            get
            {
                if (_registerCommand == null) _registerCommand = new RelayCommand(
                    (object o) =>
                    {

                        byte a = RegisterFullyValidated.isRegisterValid(_login, _password);

                        switch (a)
                        {
                            case 0:
                                message = InfoMessages[0];
                                
                                MessageBoxClass.MessageBoxFun(message);

                                break;
                            case 1:
                                message = InfoMessages[1];
                               
                                MessageBoxClass.MessageBoxFun(message);

                                break;
                            case 2:
                                message = InfoMessages[2];
                               
                                MessageBoxClass.MessageBoxFun(message);

                                break;
                            case 3:
                                message = InfoMessages[3];
                                
                                MessageBoxClass.MessageBoxFun(message);

                                break;
                            case 4:
                                message = InfoMessages[4];
                               
                                DatabaseAdding.AddingToDatabadse(_login, _password);
                                MessageBoxClass.MessageBoxFun(message);
                                break;




                        }












                    });

                return _registerCommand;




            }
        }

      /*  private string _error;
        public string Error
        {

            get
            {

                return _error;

            }

            set
            {

                _error = message;
                OnPropertyChanged(nameof(Error));
            }

        }
      */
    }
}

