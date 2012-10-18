using System;
using ClientApp.Model;

namespace ClientApp.Design
{
    public class DesignDataService : IDataService
    {
        #region IDataService Members

        public void Authenticate(string userName, string password, Action<LoginDataItem, Exception> callback)
        {
            callback(new LoginDataItem(true), null);
        }

        #endregion
    }
}