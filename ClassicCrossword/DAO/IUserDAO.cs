using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.DAO
{
    interface IUserDAO
    {
        bool Insert(Player player); //вставка

        bool Update(Player player);

        void DeleteById(int id);

        User GetUserByAuthorization(string login, string password);
    }
}
