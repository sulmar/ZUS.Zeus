using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUS.Zeus.Models
{
    public class Station : Base
    {
        public int StationId { get; set; }

        public string Number { get; set; }

        public string Address { get; set; }

        public Location Location { get; set; }

        public byte Capacity { get; set; }

        public IList<Bike> Bikes { get; set; }
    }
}
