using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentalbase.ViewModels
{
    public class RentCityGroup
    {
        public string City { get; set; }
        public double AVGRentAmount { get; set; }
    }
}