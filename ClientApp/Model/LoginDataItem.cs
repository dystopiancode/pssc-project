using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientApp.Model
{
    public class LoginDataItem
    {
        public LoginDataItem(bool loginSuccessful)
        {
            LoginSuccessul = loginSuccessful;
        }

        public bool LoginSuccessul { get; set; }
    }
}
