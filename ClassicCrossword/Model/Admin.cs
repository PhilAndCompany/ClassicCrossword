using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.Model
{
    public class Admin : User
    {
        public Admin(string login, string pass, string status) : base(login, pass, status) { }
    }
}
