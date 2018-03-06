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
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal AVGRentAmount { get; set; }
    }
}