using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientApp.Model
{
    public interface IDataService
    {
        void Authenticate(string userName, string password,
                          Action<LoginDataItem, Exception> callback);
    }
}
