using EF_Project.DAL.Manager;
using EF_Project.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.BLL.Service
{
    public class CityService
    {
        public List<City> GetCity()
        {
            CityManager cityManager = new CityManager();
            return cityManager.FillCity();
        }

    }
}
