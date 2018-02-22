﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentalbase.Models
{
    public class Lease
    {
        public int LeaseID { get; set; }
        public int PropertyID { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationMonths { get; set; }
        public float RateMonthly { get; set; }

        public virtual Property Property { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}