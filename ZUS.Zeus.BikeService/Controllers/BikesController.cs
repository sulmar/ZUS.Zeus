using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZUS.Zeus.Common;
using ZUS.Zeus.Models;
using ZUS.Zeus.Models.SearchCriteria;
using ZUS.Zeus.Services;

namespace ZUS.Zeus.BikeService.Controllers
{
    
    public class BikesController : ApiController
    {

        private IBikesService _BikesService = new MockBikesService();

        //public IList<Bike> Get()
        //{
        //    return _BikesService.GetBikes();
        //}


        [Route("api/bikes/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var bike = _BikesService.GetBike(id);

            if (bike == null)
                return NotFound();

            return Ok(bike);
        }

        [Route("api/bikes/{number}")]
        public Bike Get(string number)
        {
            return _BikesService.GetBike(number);
        }


      
        //public IList<Bike> Get([FromUri] BikeSearchCriteria criteria)
        //{
        //    return _BikesService.GetBikes(criteria);
        //}

        //[HttpPost]
        //public IList<Bike> Get([FromBody] BikeSearchCriteria criteria)
        //{
        //    return _BikesService.GetBikes(criteria);
        //}


        [HttpPost]
        public IHttpActionResult Add(Bike bike)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _BikesService.AddBike(bike);

            return CreatedAtRoute("DefaultApi", new { id = bike.BikeId }, bike);
        }

        [Route("api/bikes/{id}")]
        public IHttpActionResult Put(int id, Bike bike)
        {

            _BikesService.UpdateBike(bike);


            return StatusCode(HttpStatusCode.NoContent);
        }




        [HttpPatch]
        [Route("api/bikes/{id}")]
        public IHttpActionResult Patch(int id, [FromBody] Bike bike)
        {
            var existingbike = _BikesService.GetBike(id);

            existingbike.IsActive = bike.IsActive;

            return StatusCode(HttpStatusCode.Accepted);
        }


        [HttpHead]
        [Route("api/bikes/{id}")]
        public IHttpActionResult Head(int id)
        {
            var bike = _BikesService.GetBike(id);

            if (bike != null)
                return Ok();
            else
                return NotFound();
        }
    }
}
