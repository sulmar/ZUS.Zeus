using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZUS.Zeus.Models;
using ZUS.Zeus.Models.SearchCriteria;

namespace ZUS.Zeus.Common
{
    public interface IBikesService
    {
        IList<Bike> GetBikes();

        IList<Bike> GetBikes(BikeSearchCriteria criteria);

        Bike GetBike(int bikeId);

        Bike GetBike(string number);

      

        void AddBike(Bike bike);

        void UpdateBike(Bike bike);

        void DeleteBike(int bikeId);
    }
}
