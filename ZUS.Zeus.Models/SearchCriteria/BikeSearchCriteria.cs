using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUS.Zeus.Models.SearchCriteria
{
    public class BikeSearchCriteria : Base
    {
        public string Color { get; set; }

        public BikeType? BikeType { get; set; }

        public string Number { get; set; }

        public bool? IsActive { get; set; }
    }
}
