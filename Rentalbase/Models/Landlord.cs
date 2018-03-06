using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Landlord
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Street { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string State { get; set; }
        [Required]
        [Range(10000,99999)]
        public int Zip { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}