using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using ClientApp.Model;

namespace ClientApp.ViewModel
{
    /// <summary>Class that implements view model for the login view.</summary>
    public class LoginViewModel : ViewModelBase
    {
        public const string UserNamePropertyName = "UserName";
        public const string PasswordPropertyName = "Password";

        private string _userName = "";
        private string _password = "";
        private RelayCommand _loginCommand;
        /// <summary> Reference to the service that can be used to access the model. </summary>
        private IDataService _dataService;

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { Set(UserNamePropertyName, ref _userName, value); }
        }

        /// <summary>
        /// Sets and gets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { Set(PasswordPropertyName, ref _password, value); }
        }

        private void LoginAction()
        {
            _dataService.Authenticate(UserName, Password,
                                      new Action<LoginDataItem, Exception>
                                                (AutentificationAction));
        }

        private void AutentificationAction(LoginDataItem dataItem, Exception ex)
        {
            MessengerInstance.Send(dataItem);
        }

        /// <summary>
        /// Gets the LoginCommand. This command is invoked when user clicks login.
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand != null)
                {
                    return _loginCommand;
                }
                else
                {
                    _loginCommand = new RelayCommand(new Action(LoginAction));
                    return _loginCommand;
                }
                /*
                return _loginCommand
                    ?? (_loginCommand = new RelayCommand(
                    () =>
                    {
                        _dataService.Authenticate(UserName, Password, (autResult, ex) =>
                        {
                            MessengerInstance.Send(autResult);
                        });
                    }));
                */
            }
        }

        /// <summary>Initializes a new instance of the LoginModel class.</summary>
        public LoginViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }
    }
}