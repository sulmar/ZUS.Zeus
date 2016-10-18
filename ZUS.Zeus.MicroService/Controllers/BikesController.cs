using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ZUS.Zeus.Models;

namespace ZUS.Zeus.MicroService.Controllers
{
    public class BikesController : ApiController
    {
        public string Get()
        {
            return "Hello WebApi";
        }

        public IHttpActionResult Get(int id)
        {
            var bike = new Bike { BikeId = 1, Number = "R001" };

            return Ok(bike);
        }
    }
}
