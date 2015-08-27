using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vetallis.Business
{
    public class Users
    {
        public string id;
        public string name;
        public string password;
        public string status;
        public string dateCreated;
        public string dateLastLogin;
        public string locationLastLogin;
        public int loginTimes;
    }
}