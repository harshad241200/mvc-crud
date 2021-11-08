using MVCWebApplication.Dao;
using MVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Service
{
    public class UserService
    {

        UserDao dao = new UserDao();

        public int Insertuser(Users user)
        {
            return dao.insertUser(user);
        }

        public List<Users> getAllUsers()
        {
         return    dao.getAllUsers();
        }

        public List<Users> getAllUsersByid(string id)
        {
            return dao.getAllUsersByid(id);
        }

        public int UpdateUser(Users user)
        {
            return dao.UpdateUser(user);
        }

        public int DeleteUser(string id)
        {
            return dao.DeleteUser(id);
        }
    }
}