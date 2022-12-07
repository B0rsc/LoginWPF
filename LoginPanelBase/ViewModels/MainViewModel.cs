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

namespace LoginPanelBase.ViewModels
{
    public class MainViewModel : ObservableObject
    {



        public string message;
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
            {"Login unsucessful :("} // 7







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




                        if (ValidationNullable.NullVal(_login) == 1)
                        {

                            message = InfoMessages[0];
                            Error = message;
                           

                        }
                        else if (!ValidationIsFullyString.IsStringLogin(_login))
                        {

                            message = InfoMessages[2];
                            Error = message;


                        }
                        else if (IsPasswordNull.PassNull(_password) == 1)
                        {

                            message = InfoMessages[1];
                            Error = message;


                        }
                        else if (!ValidationPassword.IsPasswordCorrect(_password))
                        {

                            message =  InfoMessages[3];
                            Error = message;



                        } else if (!LoggingValidation.LoggingVal(_login, _password))
                        {

                            message = InfoMessages[7];
                            Error = message;



                        } else
                        {

                            message = InfoMessages[6];
                            Error = message;


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
                      





                                using (DatabaseContext myContext = new DatabaseContext())
                                {

                                    myContext.Users.Add(

                                       new User()
                                       {

                                           Login = _login,
                                           Password = _password,


                                       }


                                        );


                                    myContext.SaveChanges();

                                }




                               
                    });

                return _registerCommand;




            }
        }

        private string _error;
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

    }
}

