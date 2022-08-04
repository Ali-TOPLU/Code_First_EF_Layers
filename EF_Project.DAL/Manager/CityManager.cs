using EF_Project.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.DAL.Manager
{
    public class CityManager
    {
        public List<City> FillCity()
        {
            using (Context context = new Context())
            {
                return context.Cities.ToList();

            }

        }
    }
}
