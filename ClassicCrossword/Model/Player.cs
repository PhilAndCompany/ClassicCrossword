using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.Model
{
    public class Player : User
    {
        public Player(int id, string login, string pass) : base(id, login, pass) { }
        public Player(string login, string pass) : base(login, pass) { }
    }
}
