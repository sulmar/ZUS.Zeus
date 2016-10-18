using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZUS.Zeus.Models.Converters;

namespace ZUS.Zeus.Models
{
    [TypeConverter(typeof(LocationTypeConverter))]
    public class Location : Base
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

    }
}
