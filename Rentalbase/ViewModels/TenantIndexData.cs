using System.Collections.Generic;
using Rentalbase.Models;

namespace Rentalbase.ViewModels
{
    public class TenantIndexData
    {
        public int LeaseCount { get; set; } = 0;

        public IEnumerable<Tenant> Tenants { get; set; }
        public Property Property { get; set; }
        public string PropertyStreet { get; set; }
        public IEnumerable<Lease> Leases { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}