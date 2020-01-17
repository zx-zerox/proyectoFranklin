using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Dominio
{
    public class UserModel
    {
        UserDao userDao = new UserDao();
        //metodo para validar el login
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

    }
}
