using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ZUS.Zeus.BikeService.Results;
using ZUS.Zeus.Common;
using ZUS.Zeus.Models;
using ZUS.Zeus.Services;

namespace ZUS.Zeus.BikeService.Controllers
{
    public class StationsController : ApiController
    {
        private IStationsService _StationsService = new MockStationsService();
        private IBikesService _BikesService = new MockBikesService();

        public IHttpActionResult Get()
        {
            var stations = _StationsService.GetStations();

            return Ok(stations);
        }

        public IHttpActionResult Get(int id)
        {
            var station = _StationsService.GetStation(id);

            if (station == null)
                return NotFound();

            return Ok(station);
        }


        [HttpGet]
        public IHttpActionResult Find(Location location)
        {
            var station = _StationsService.FindStation(location);

            if (station == null)
                return NotFound();

            return Ok(station);
        }

        [Route("api/stations/{stationId}/bikes/{bikeId}")]
        public IHttpActionResult GetBikeByStation(int stationId, int bikeId)
        {

            var station = _StationsService.GetStation(stationId);
            
            if (station == null)
            return this.NotFound("Station not found");
            
            // Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Błędna wartość");

            // HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound)
            //{
            //    StatusCode = HttpStatusCode.NotFound;
            //};



            var bikes = _StationsService.GetBikes(stationId);

            var bike = bikes.SingleOrDefault(b => b.BikeId == bikeId);

            if (bike == null)
                return NotFound();

            return Ok(bikes);
        }

    }
}
