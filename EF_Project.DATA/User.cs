using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.DATA
{
    public class User:BaseUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


        public virtual UserDetail UserOfDetail { get; set; }

       
    }
}
