using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZUS.Zeus.Common;
using ZUS.Zeus.Models;
using ZUS.Zeus.Models.SearchCriteria;

namespace ZUS.Zeus.Services
{
    public class MockBikesService : IBikesService
    {
        private static IList<Bike> Bikes = new List<Bike>
        {
            new Bike
            {
                BikeId = 1,
                BikeType = BikeType.City,
                Color = "Red",
                Number = "R001",
                IsActive = true,
            },

            new Bike
            {
                BikeId = 2,
                BikeType = BikeType.Kids,
                Color = "Pink",
                Number = "R002",
                IsActive = true,
            },

            new Bike
            {
                BikeId = 3,
                BikeType = BikeType.Tandem,
                Color = "Black",
                Number = "R003",
                IsActive = true,
            },
        };

        public void AddBike(Zeus.Models.Bike bike)
        {
            bike.BikeId = Bikes.Max(b => b.BikeId) + 1;

            Bikes.Add(bike);



        }

        public void DeleteBike(int bikeId)
        {
            var bike = GetBike(bikeId);

            Bikes.Remove(bike);
        }

        public Bike GetBike(string number)
        {
            return Bikes.SingleOrDefault(b => b.Number == number);
        }

        public Bike GetBike(int bikeId)
        {
            return Bikes.Where(b => b.BikeId == bikeId).SingleOrDefault();
        }

        public IList<Bike> GetBikes()
        {
            return Bikes;
        }

        public IList<Bike> GetBikes(BikeSearchCriteria criteria)
        {
            IEnumerable<Bike> bikes = Bikes;

            if (criteria == null)
                return Bikes;

            if (!string.IsNullOrEmpty(criteria.Color))
                bikes = bikes.Where(b => b.Color == criteria.Color);

            if (!string.IsNullOrEmpty((criteria.Number)))
                bikes = bikes.Where(b => b.Number.StartsWith(criteria.Number));

            if (criteria.BikeType.HasValue)
                bikes = bikes.Where(b => b.BikeType == criteria.BikeType);

            if (criteria.IsActive.HasValue)
                bikes = bikes.Where(b => b.IsActive == criteria.IsActive);

            return bikes.ToList();
        }

        public void UpdateBike(Bike bike)
        {
            var oldBike = GetBike(bike.BikeId);

            oldBike = bike;
        }
    }
}
