using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentalbase.ViewModels
{
    public class AboutData
    {
        public IEnumerable<RentCityGroup> rentCityGroup { get; set; }
        public IEnumerable<PropertyCityGroup> propertyCityGroup { get; set; }

    }
}