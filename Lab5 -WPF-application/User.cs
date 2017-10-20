using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5__WPF_application
{
    class User
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }



      public User(string userName, string emailAddress)
        {
            this.UserName = userName;
            this.EmailAddress = emailAddress;
        }


       
}
}
