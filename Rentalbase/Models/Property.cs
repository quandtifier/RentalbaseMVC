using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Property
    {
        public int ID { get; set; }
        [Required]
        public int LandlordID { get; set; } = 1;
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
        public int Value { get; set; }
        public string Description { get; set; }
        
        public virtual Landlord Landlord { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}