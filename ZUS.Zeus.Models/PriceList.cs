using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUS.Zeus.Models
{
    public class PriceList : Base
    {
        public int PriceListId { get; set; }

        public int Time { get; set; }

        public BikeType BikeType { get; set; }

        public decimal Price { get; set; }
    }
}
