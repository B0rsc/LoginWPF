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

namespace LoginPanelBase.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        private DatabaseContext databaseContext;

        public string message;
        private string _password;
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
                        if (ValidationNullable.NullVal(_login, _password) == 0)
                        {

                            message = "Nie podano loginu";
                            Error = message;


                        } else if (ValidationNullable.NullVal(_login, _password) == 1)
                        {

                            message = "Nie podano hasła";
                            Error = message;


                        }
                        else
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

