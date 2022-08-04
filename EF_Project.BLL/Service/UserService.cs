using EF_Project.DAL;
using EF_Project.DAL.Manager;
using EF_Project.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.BLL.Service
{
    public class UserService
    {
        Context connection;
        
        public void AddUser(User user)
        {
            int age;
            UserManager appUserManager = new UserManager();
            user.CreateDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            user.UserOfDetail.CreateDate = DateTime.Now;
            user.UserOfDetail.ModifiedDate = DateTime.Now;
            appUserManager.AddUser(user);
        }

        public int FindUser(string userName, string password)
        {
            connection = new Context();

            if (connection.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password) != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

    }
}
