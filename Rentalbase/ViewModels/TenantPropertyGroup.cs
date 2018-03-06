using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentalbase.ViewModels
{
    public class TenantPropertyGroup
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public int? Zip { get; set; }
        
        
    }
}