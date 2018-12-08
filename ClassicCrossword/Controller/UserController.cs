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
        public bool Insert(Player player)
        {
            if (new UserDAO().Insert(player)) return true;
            else return false;
        }

        public bool Update(Player player)
        {
            if (new UserDAO().Update(player)) return true;
            else return false;
        }

        public void DeleteById(int id)
        {
            new UserDAO().DeleteById(id);
        }

        public User GetUserByAuthorization(string login, string password)
        {
            return new UserDAO().GetUserByAuthorization(login, password);
        }

    }
}
