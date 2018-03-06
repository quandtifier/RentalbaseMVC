using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Rentalbase.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public int PropertyID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Issue Date")]
        public DateTime DateIssued { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Date")]
        public DateTime DatePaid { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount")]
        public decimal Cost { get; set; }

        public virtual InvoiceType InvoiceType { get; set; }
    }
}