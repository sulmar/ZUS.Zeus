using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZUS.Zeus.Common;
using ZUS.Zeus.Models;

namespace ZUS.Zeus.Services
{
    public class MockStationsService : IStationsService
    {

        private static IList<Station> _Stations = new List<Station>
        {
            new Station
            {
                StationId = 1, Number = "ST001", Capacity = 10,
                Bikes = new List<Bike>
                {
                    new Bike { BikeId = 1, Number = "R001" },
                    new Bike { BikeId = 2, Number = "R002" },
                }
            },
            new Station { StationId = 2, Number = "ST002", Capacity = 5,
                Bikes = new List<Bike>
                {
                    new Bike { BikeId = 4, Number = "R004" },
                    new Bike { BikeId = 5, Number = "R005" },
                    new Bike { BikeId = 6, Number = "R006" },
                }

            },
            new Station { StationId = 3, Number = "ST003", Capacity = 3 },
        };

        public void AddStation(Station station)
        {
            _Stations.Add(station);
        }

        public void DeleteStation(int stationId)
        {
            throw new NotImplementedException();
        }

        public Station FindStation(Location location)
        {
            var station = _Stations
                .Where(s => s.Location.Latitude == location.Latitude)
                .Where(s => s.Location.Longitude == location.Longitude)
                .FirstOrDefault();

            return station;
        }

        public IList<Bike> GetBikes(int stationId)
        {
            var bikes = _Stations
                .SingleOrDefault(s => s.StationId == stationId)?
                .Bikes;

            return bikes;
        }

        public Station GetStation(int stationId)
        {
            return _Stations.SingleOrDefault(s => s.StationId == stationId);
        }

        public IList<Station> GetStations()
        {
            return _Stations;
        }

        public void UpdateStation(Station station)
        {
            throw new NotImplementedException();
        }
    }
}
