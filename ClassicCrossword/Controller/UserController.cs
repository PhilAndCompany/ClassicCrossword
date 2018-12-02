using ClassicCrossword.DAO;
using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.Controller
{
    public class UserController
    {
        public void Insert(Player player)
        {
            new UserDAO().Insert(player);
        }

        public User GetUserByAuthorization(string login, string password)
        {
            return new UserDAO().GetUserByAuthorization(login, password);
        }

    }
}
