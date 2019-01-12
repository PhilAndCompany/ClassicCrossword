using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        protected User(int id, string login, string pass)
        {
            Id = id;
            Login = login;
            Pass = pass;
        }

        protected User(string login, string pass)
        {
            Login = login;
            Pass = pass;
        }
    }
}
