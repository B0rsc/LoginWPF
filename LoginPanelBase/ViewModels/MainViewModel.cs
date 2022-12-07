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

        List<string> ErrorMessages = new List<string>()
        {
            {"Empty Login"}, // 0
            {"Empty password"}, // 1
            {"Wrong characters in Login"}, // 2
            {"Password doesn't meet the requirements"}, // 3
            {"This user already exists - try to log in"} // 4







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
                        if (ValidationNullable.NullVal(_login, _password) == 1)
                        {

                            message = ErrorMessages[0];
                            Error = message;

                        }
                        else if (ValidationNullable.NullVal(_login, _password) == 2)
                        {

                            message = ErrorMessages[1];
                            Error = message;


                        }
                        else if (!ValidationIsFullyString.IsStringLogin(_login))
                        {

                            message = ErrorMessages[2];
                            Error = message;

                        }
                        else if (!ValidationPassword.IsPasswordCorrect(_password))
                        {

                            message = ErrorMessages[3];
                            Error = message;



                        }
                        else
                        {
                            if (!ValidationAlreadyRegistered.AlreadyRegistered(_login))
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




                                message = "Register Completed!";
                                Error = message;


                            }




                            else
                            {

                                message = ErrorMessages[4];
                                Error = message;



                            }
                        }
                        #region addingToDatabase             
                        /* else
                        {




                            databaseContext = new();

                            databaseContext.Users.Add(

                                new User()
                                {

                                    Login = _login,
                                    Password = _password


                                }



                                );

                            databaseContext.SaveChanges();



                        }

                        */

                        #endregion
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

