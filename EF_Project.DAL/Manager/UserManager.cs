using EF_Project.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.DAL.Manager
{
    public class UserManager
    {
        public void AddUser(User user)
        {
            using (Context ctx = new Context())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();

            }
        }
    }
}
