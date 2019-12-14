using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOC.Models
{
    public class UserEmailInformation
    {
        public string emailAddress { get; set; }
        public string name { get; set; }
        
        public UserEmailInformation(string emailAddress, string name)
        {
            this.emailAddress = emailAddress;
            this.name = name;
        }
    }
}
