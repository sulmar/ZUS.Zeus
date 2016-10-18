using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZUS.Zeus.Models;

namespace ZUS.Zeus.Common
{
    public interface IStationsService
    {
        IList<Station> GetStations();

        Station GetStation(int stationId);

        void AddStation(Station station);

        void UpdateStation(Station station);

        void DeleteStation(int stationId);

        IList<Bike> GetBikes(int stationId);
    }
}
