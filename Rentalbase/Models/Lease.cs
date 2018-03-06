using System;
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
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Range(1,24)]
        [Display(Name = "Duration of Lease")]
        public int DurationMonths { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Monthly Rate")]
        public decimal RateMonthly { get; set; }

        public virtual Property Property { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}