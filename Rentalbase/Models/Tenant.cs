using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Tenant
    {
        public int ID { get; set; }
        public int? PropertyID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(12)]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Registered")]
        public DateTime RegistrationDate { get; set; }

        public virtual Property Property { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
    }
}