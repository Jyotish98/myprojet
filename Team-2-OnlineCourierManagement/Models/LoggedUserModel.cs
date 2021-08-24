using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Models
{
    //Logged User Model containing token for Authorization
    public class LoggedUserModel
    {
        public string EmailID { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
     
    }
}
