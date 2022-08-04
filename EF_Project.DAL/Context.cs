using EF_Project.DAL.Mapping;
using EF_Project.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.DAL
{
   public class Context: DbContext
    {

        public Context() : base("Server=.;Database=CalorieDB;Trusted_Connection=True;")
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new UserDetailsMapping());



            base.OnModelCreating(modelBuilder);
        }
    }
}
