using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.DATA
{
   public class UserDetail:BaseUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int CityID { get; set; }
        
        public string PhoneNumber { get; set; }


        public virtual User DetailofUser { get; set; }
    }
}
