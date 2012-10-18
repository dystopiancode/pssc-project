using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using ClientApp.Model;
using System;

namespace ClientApp
{
    /// <summary>
    /// Description for LoginView.
    /// </summary>
    public partial class LoginView : Window
    {
        /// <summary>
        /// Initializes a new instance of the LoginView class.
        /// </summary>
        /// 
        public LoginView()
        {
            InitializeComponent();

            IDataService dataService = new DataService();
            this.DataContext = new ViewModel.LoginViewModel(dataService);


            Action<LoginDataItem> myAction = new Action<LoginDataItem>(LoginAttempt);
            Messenger.Default.Register<LoginDataItem>(this, myAction);
        }

        private void LoginAttempt(LoginDataItem data)
        {
            if (data.LoginSuccessul == true)
            {
                MessageBox.Show("User successfully authenticated.");
            }
            else
            {
                MessageBox.Show("User authentication faild.");
            }
        }
    }
}