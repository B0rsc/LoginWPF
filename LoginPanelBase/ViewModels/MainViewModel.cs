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
using System.Collections;

namespace LoginPanelBase.ViewModels
{
    public class MainViewModel : ObservableObject
    {



        string message;
       
        private string _password;
        
        public string LoginEmpty;
        
        public string PasswordEmpty;
        
        public string WrongChars;
        
        public string PassRequirements;
        
        public string RegSucc;




        public Dictionary<string, string> InfoDictionary = new Dictionary<string, string>();





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

                        InfoDictionary.Clear();
                        InfoDictionary.Add("LogSucc", "Login successful!");
                        InfoDictionary.Add("LogUnSucc", "Login unsuccessful :(");
                        InfoDictionary.Add("UserNotFound", "User not found - register now");


                        byte CheckLogin = LoggingValidation.LoggingVal(_login, _password);


                        switch (CheckLogin)
                        {
                            case 6:
                                message = InfoDictionary["LogSucc"];

                                MessageBoxClass.MessageBoxFun(message);

                                break;
                            case 7:
                                message = InfoDictionary["LogUnSucc"];

                                MessageBoxClass.MessageBoxFun(message);

                                break;
                            case 8:
                                message = InfoDictionary["UserNotFound"];

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
                        InfoDictionary.Clear();
                        InfoDictionary.Add("LoginEmpty", "Empty login");
                        InfoDictionary.Add("PasswordEmpty", "Empty password");
                        InfoDictionary.Add("WrongChars", "Wrong characters in Login");
                        InfoDictionary.Add("PassRequirements", "Password doesn't meet the requirements");
                        InfoDictionary.Add("RegSucc", "Register successful");
                        InfoDictionary.Add("UserExists", "This user already exists - try to log in");



                        byte a = RegisterFullyValidated.isRegisterValid(_login, _password);

                        switch (a)
                        {
                            case 0:
                                message = InfoDictionary["LoginEmpty"];
                                MessageBoxClass.MessageBoxFun(message);
                                break;
                            case 1:
                                message = InfoDictionary["PasswordEmpty"];
                                MessageBoxClass.MessageBoxFun(message);
                                break;
                            case 2:
                                message = InfoDictionary["WrongChars"];
                                MessageBoxClass.MessageBoxFun(message);
                                break;
                            case 3:
                                message = InfoDictionary["PassRequirements"];
                                MessageBoxClass.MessageBoxFun(message);
                                break;
                            case 4:
                                message = InfoDictionary["RegSucc"];
                                DatabaseAdding.AddingToDatabadse(_login, _password);
                                MessageBoxClass.MessageBoxFun(message);
                                break;
                            case 5:
                                message = InfoDictionary["UserExists"];
                                MessageBoxClass.MessageBoxFun(message);
                                break;



                        }



                    }); return _registerCommand;





            }
        }

      
    }
}

