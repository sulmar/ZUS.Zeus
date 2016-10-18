using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using ZUS.Zeus.Models;

namespace ZUS.Zeus.Models.Converters
{
    public class LocationTypeConverter : TypeConverter
    {

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var values = ((string)value).Split(',');

                if (values.Length == 2)
                {
                    double latitude;
                    double longitude;

                    if (Double.TryParse(values[0], NumberStyles.Any, CultureInfo.InvariantCulture, out latitude) 
                        && Double.TryParse(values[1], NumberStyles.Any, CultureInfo.InvariantCulture, out longitude)
                        )
                        return new Location { Longitude = longitude, Latitude = latitude };
                }
            }

            if (context != null)
                return base.ConvertFrom(context, culture, value);
            else
                return null;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var location = value as Location;

                return $"{location.Latitude}, {location.Longitude}";

            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

    }
}