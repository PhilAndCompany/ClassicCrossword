using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.Model
{
    public class Player : User
    {
        public Player(string login, string pass, string status) : base(login, pass, status) { }
    }
}
