using EF_Project.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.DAL.Mapping
{
   public class UserDetailsMapping : EntityTypeConfiguration<User>
    {
        public UserDetailsMapping()
        {

            HasRequired(x => x.UserOfDetail).WithRequiredPrincipal(x => x.DetailofUser);

        }
    }
}
