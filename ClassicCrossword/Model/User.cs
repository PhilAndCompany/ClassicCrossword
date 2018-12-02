using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.Model
{
    public class User
    {
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Status { get; set; }

        public User(string login, string pass, string status)
        {
            Login = login;
            Pass = pass;
            Status = status;
        }
    }
}
