using System;

namespace ClientApp.Model
{

    public class DataService : IDataService
    {
        public void Authenticate(string userName, string password,
                                 Action<LoginDataItem, Exception> callback)
        {
            if (userName.ToLower().Equals("admin"))// && password.Equals("admin"))
            {
                callback(new LoginDataItem(true), null);
            }
            else
            {
                callback(new LoginDataItem(false), null);
            }
        }
    }

}