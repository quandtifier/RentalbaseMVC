namespace Rentalbase.Migrations
{
    using Rentalbase.DAL;
    using Rentalbase.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rentalbase.DAL.RBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rentalbase.DAL.RBaseContext context)
        {
            var landlords = new List<Landlord>
            {
                new Landlord {Name="Joshua Lansang", Street="332 Lake Forest Drive", City="Seattle", State="WA", Zip=98190, Phone="2061234567", Email="jlansang@rbase.com"},
                new Landlord {Name="Michael Quandt", Street="74 Lookout Ave.", City="Silverlake", State="WA", Zip=98465, Phone="2531234567", Email="mquandt@rbase.com"},
                new Landlord {Name="Alex Reid", Street="834 Ashley St.", City="Malone", State="WA", Zip=98559, Phone="4251234567", Email="areid@rbase.com"},
                new Landlord {Name="C S Lewis", Street="1946 Harper St.", City="Narnia", State="WA", Zip=00000, Phone="1234567890", Email="cslewis@rbase.com"},
                new Landlord {Name="Jacob Bain", Street="54 Military St.", City="Spanaway", State="WA", Zip=98387, Phone="2537777777", Email="baintrain@rbase.com"},
                new Landlord {Name="Sally Newman", Street="979 LakeView Rd", City="Lakeview", State="WA", Zip=98851, Phone="2533334444", Email="bettercallsal@rbase.com"},
                new Landlord {Name="Biggs Darklighter", Street="3 Red St", City="Yavin", State="WA", Zip=77777, Phone="2531134444", Email="biggs@rbase.com"},
                new Landlord {Name="Wedge Antilles", Street="2 Red St", City="Yavin", State="WA", Zip=77777, Phone="2531134444", Email="wedge@rbase.com"},
                new Landlord {Name="Guy McGee", Street="12 Oatmeal St.", City="Vermillion", State="WA", Zip=99992, Phone="9786754635", Email="geemcgee@rbase.com"},
                new Landlord {Name="Isaac Clarke", Street="2009 Kellion St.", City="Aegis", State="WA", Zip=66666, Phone="0707070707", Email="iclarke@rbase.com"},
            };
            landlords.ForEach(s => context.Landlords.AddOrUpdate(p => p.Email, s));
            context.SaveChanges();

            var propTypes = new List<PropertyType>
            {
                new PropertyType{Type="APT STUDIO", Description="An apartment with only one room and a bath"},
                new PropertyType{Type="APT 1BD/1BA", Description="A 1 bed and 1 bath apartment"},
                new PropertyType{Type="APT 2BD/1BA", Description="A 2 bed and 2 bath apartment"},
                new PropertyType{Type="APT 2BD/2BA", Description="A 2 bed and 2 bath apartment"},
                new PropertyType{Type="APT 3BD/1BA", Description="A 3 bed and 1 bath apartment"},
                new PropertyType{Type="APT 3BD/2BA", Description="A 3 bed and 2 bath apartment"},

                new PropertyType{Type="SFH LARGE", Description="A Single Family Home larger than most"},
                new PropertyType{Type="SFH 1BD/2BA", Description="A 1 bed and 2 bath Single Family Home"},
                new PropertyType{Type="SFH 2BD/1BA", Description="A 2 bed and 1 bath Single Family Home"},
                new PropertyType{Type="SFH 2BD/2BA", Description="A 2 bed and 2 bath Single Family Home"},
                new PropertyType{Type="SFH 3BD/1BA", Description="A 3 bed and 1 bath Single Family Home"},
                new PropertyType{Type="SFH 3BD/2BA", Description="A 3 bed and 2 bath Single Family Home"},
                new PropertyType{Type="SFH 4BD/2BA", Description="A 4 bed and 2 bath Single Family Home"},
                new PropertyType{Type="SFH 4BD/3BA", Description="A 4 bed and 3 bath Single Family Home"},

                new PropertyType{Type="IND WRHS", Description="Warehouse space"},
                new PropertyType{Type="IND OFFICE", Description="Office Space"},

            };
            propTypes.ForEach(s => context.PropertyTypes.AddOrUpdate(p => p.Type, s));
            context.SaveChanges();

            var properties = new List<Property>
            {
                new Property { LandlordID=1, Street="38 Galvin Road", City="Seattle", State="WA", Zip=98181, Value=5000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "SFH 1BD/1BA")},
                new Property { LandlordID=1, Street="61 North Mulberry St.", City="Seattle", State="WA", Zip=98183, Value=20000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT STUDIO")},
                new Property { LandlordID=1, Street="87 Angel Ave", City="Seattle", State="WA", Zip=98184, Value=40000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "SFH 1BD/1BA")},
                new Property { LandlordID=1, Street="50 Old Dr.", City="Seattle", State="WA", Zip=98174, Value=20000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "SFH 1BD/1BA")},

                new Property { LandlordID=2, Street="9860 Cactus Lane Apt A", City="Tacoma", State="WA", Zip=98321, Value=99000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT 2BD/1BA")},
                new Property { LandlordID=2, Street="9860 Cactus Lane Apt B", City="Tacoma", State="WA", Zip=98322, Value=100000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT 2BD/1BA")},
                new Property { LandlordID=2, Street="9860 Cactus Lane Apt C", City="Tacoma", State="WA", Zip=98323, Value=101000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT 2BD/1BA")},
                new Property { LandlordID=2, Street="9860 Cactus Lane Apt D", City="Tacoma", State="WA", Zip=98324, Value=102000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT 2BD/1BA")},

                new Property { LandlordID=3, Street="7689 W. College St. Suite 1", City="Kent", State="WA", Zip=98410, Value=300000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT STUDIO")},
                new Property { LandlordID=3, Street="7689 W. College St. Suite 2", City="Kent", State="WA", Zip=98411, Value=310000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT STUDIO")},
                new Property { LandlordID=3, Street="7689 W. College St. Suite 3", City="Kent", State="WA", Zip=98412, Value=320000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT STUDIO")},
                new Property { LandlordID=3, Street="7689 W. College St. Suite 4", City="Kent", State="WA", Zip=98413, Value=330000, Description="Property notes here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT STUDIO")},

                new Property { LandlordID=4, Street="1950 Harper St.", City="Narnia", State="WA", Zip=00000, Value=1000000, Description="Wordrobe not Included", PropertyType = propTypes.SingleOrDefault(t => t.Type == "APT STUDIO")},

            };

            properties.ForEach(s => context.Properties.AddOrUpdate(p => p.Street, s));
            context.SaveChanges();

            var tenants = new List<Tenant>
            {
                new Tenant { PropertyID=1, Name="Thomas M Anders", Phone="2063651375", Email="tanders@gmail.com", RegistrationDate=DateTime.Parse("2010-01-01")},
                new Tenant { PropertyID=1, Name="Jen D Anders", Phone="2063651375", Email="janders@gmail.com", RegistrationDate=DateTime.Parse("2010-02-02")},
                new Tenant { PropertyID=2, Name="Dorothy G Wilkinson", Phone="2065501377", Email="dwilkinson@gmail.com", RegistrationDate=DateTime.Parse("2017-02-02")},
                new Tenant { PropertyID=2, Name="James F Wilkinson", Phone="2065501377", Email="jwilkinson@gmail.com", RegistrationDate=DateTime.Parse("2017-02-02")},

                new Tenant { PropertyID=3, Name="George A Whyte", Phone="2830937463", Email="gwhite@gmail.com", RegistrationDate=DateTime.Parse("2012-03-03")},
                new Tenant { PropertyID=3, Name="Franky Fish", Phone="2063653789", Email="ffish@gmail.com", RegistrationDate=DateTime.Parse("2012-03-03")},
                new Tenant { PropertyID=4, Name="Keneth M Cloud", Phone="2063247693", Email="kc@gmail.com", RegistrationDate=DateTime.Parse("2012-04-04")},
                new Tenant { PropertyID=5, Name="Terresa H Corbeil", Phone="2064957464", Email="tc@gmail.com", RegistrationDate=DateTime.Parse("2012-05-05")},

                new Tenant { PropertyID=6, Name="Helena C Diaz", Phone="2068719078", Email="hdiaz@gmail.com", RegistrationDate=DateTime.Parse("2012-06-06")},
                new Tenant { PropertyID=7, Name="Lowell C Duque", Phone="3609844684", Email="lduque@gmail.com", RegistrationDate=DateTime.Parse("2012-07-07")},
                new Tenant { PropertyID=8, Name="Juan C Burris", Phone="2068496274", Email="jburris@gmail.com", RegistrationDate=DateTime.Parse("2012-08-08")},
                new Tenant { PropertyID=8, Name="Janine W Taylor", Phone="2068496274", Email="jtaylor@gmail.com", RegistrationDate=DateTime.Parse("2012-09-09")},

                new Tenant { PropertyID=8, Name="Anna W Beebe", Phone="3606611025", Email="abeebe@gmail.com", RegistrationDate=DateTime.Parse("2017-10-10")},
                new Tenant { PropertyID=8, Name="Ray J Crutchfield", Phone="5093104460", Email="rcructchfield@gmail.com", RegistrationDate=DateTime.Parse("2017-11-11")},
                new Tenant { PropertyID=8, Name="Julia A Mahoney", Phone="3604414963", Email="jmahoney@gmail.com", RegistrationDate=DateTime.Parse("2017-12-12")},

                new Tenant { Name="NotTenantGuy", Phone="3601234567", Email="nt@gmail.com", RegistrationDate=DateTime.Parse("2012-07-07")},
            };
            tenants.ForEach(s => context.Tenants.AddOrUpdate(t => t.Email, s));
            context.SaveChanges();


            var leases = new List<Lease>
            {
                //1
                new Lease { StartDate=DateTime.Parse("2010-01-01"), DurationMonths=12, RateMonthly=2000,
                    PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID,
                    Tenants = new List<Tenant>()},
                //2
                new Lease { StartDate=DateTime.Parse("2012-02-01"), DurationMonths=12, RateMonthly=2100,
                    PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID,
                    Tenants = new List<Tenant>()},
                //3
                new Lease { StartDate=DateTime.Parse("2010-10-01"), DurationMonths=12, RateMonthly=2200,
                    PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID,
                    Tenants = new List<Tenant>()},
                //4
                new Lease { StartDate=DateTime.Parse("2012-05-05"), DurationMonths=12, RateMonthly=1500,
                    PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt A").ID,
                    Tenants = new List<Tenant>()},
                //5
                new Lease { StartDate=DateTime.Parse("2013-05-05"), DurationMonths=12, RateMonthly=1500,
                    PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt A").ID,
                    Tenants = new List<Tenant>()},
                //6
                new Lease { StartDate=DateTime.Parse("2014-05-05"), DurationMonths=12, RateMonthly=1600,
                    PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt A").ID,
                    Tenants = new List<Tenant>()},
                //7
                new Lease { StartDate=DateTime.Parse("2015-05-05"), DurationMonths=12, RateMonthly=1700,
                    PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt A").ID,
                    Tenants = new List<Tenant>()},
                //8
                new Lease { StartDate=DateTime.Parse("2016-05-05"), DurationMonths=12, RateMonthly=1800,
                    PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt A").ID,
                    Tenants = new List<Tenant>()},
                //9
                new Lease { StartDate=DateTime.Parse("2017-09-09"), DurationMonths=6, RateMonthly=1000,
                    PropertyID = properties.Single(p => p.Street == "7689 W. College St. Suite 1").ID,
                    Tenants = new List<Tenant>()},
                //10
                new Lease { StartDate=DateTime.Parse("2017-10-10"), DurationMonths=6, RateMonthly=1100,
                    PropertyID = properties.Single(p => p.Street == "7689 W. College St. Suite 2").ID,
                    Tenants = new List<Tenant>()},
                //11
                new Lease { StartDate=DateTime.Parse("2017-11-11"), DurationMonths=6, RateMonthly=1200,
                    PropertyID = properties.Single(p => p.Street == "7689 W. College St. Suite 3").ID,
                    Tenants = new List<Tenant>()},
                //12
                new Lease { StartDate=DateTime.Parse("2012-12-12"), DurationMonths=12, RateMonthly=1300,
                    PropertyID = properties.Single(p => p.Street == "7689 W. College St. Suite 4").ID,
                    Tenants = new List<Tenant>()},
                //13
                new Lease { StartDate=DateTime.Parse("2013-12-12"), DurationMonths=12, RateMonthly=1400,
                    PropertyID = properties.Single(p => p.Street == "7689 W. College St. Suite 4").ID,
                    Tenants = new List<Tenant>()},
                //14
                new Lease { StartDate=DateTime.Parse("2014-12-12"), DurationMonths=12, RateMonthly=1500,
                    PropertyID = properties.Single(p => p.Street == "7689 W. College St. Suite 4").ID,
                    Tenants = new List<Tenant>()},
                //15
                new Lease { StartDate=DateTime.Parse("2015-12-12"), DurationMonths=12, RateMonthly=1600,
                    PropertyID = properties.Single(p => p.Street == "7689 W. College St. Suite 4").ID,
                    Tenants = new List<Tenant>()},
                //16
                new Lease { StartDate=DateTime.Parse("2016-12-12"), DurationMonths=12, RateMonthly=1600,
                    PropertyID = properties.Single(p => p.Street == "7689 W. College St. Suite 4").ID,
                    Tenants = new List<Tenant>()},
                //17
                new Lease { StartDate=DateTime.Parse("2017-12-12"), DurationMonths=12, RateMonthly=1600,
                    PropertyID = properties.Single(p => p.Street == "7689 W. College St. Suite 4").ID,
                    Tenants = new List<Tenant>()},
            };

            leases.ForEach(s => context.Leases.AddOrUpdate(p => p.LeaseID, s));
            context.SaveChanges();

            var invTypes = new List<InvoiceType>
            {
                new InvoiceType {Type="MAINTENANCE"},
                new InvoiceType {Type="RENT"},
                new InvoiceType {Type="DAMAGE"},
                new InvoiceType {Type="DEPOSIT"},
            };
            invTypes.ForEach(s => context.InvoiceTypes.AddOrUpdate(p => p.Type, s));
            context.SaveChanges();

            var invoices = new List<Invoice>
            {
                // property 1 invoices
                new Invoice { PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID, DateIssued=DateTime.Parse("2010-01-23"), DatePaid=DateTime.Parse("2010-02-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID, DateIssued=DateTime.Parse("2010-02-23"), DatePaid=DateTime.Parse("2010-03-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID, DateIssued=DateTime.Parse("2010-03-23"), DatePaid=DateTime.Parse("2010-04-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID, DateIssued=DateTime.Parse("2010-04-23"), DatePaid=DateTime.Parse("2010-05-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                //property 5 invoices
                new Invoice { PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt A").ID, DateIssued=DateTime.Parse("2012-02-23"), DatePaid=DateTime.Parse("2012-03-02"), Description="Rent Payment", Cost=1500.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt A").ID, DateIssued=DateTime.Parse("2012-03-23"), DatePaid=DateTime.Parse("2012-04-02"), Description="Rent Payment", Cost=1500.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt A").ID, DateIssued=DateTime.Parse("2012-04-23"), DatePaid=DateTime.Parse("2012-05-02"), Description="Rent Payment", Cost=1500.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt A").ID, DateIssued=DateTime.Parse("2012-05-23"), DatePaid=DateTime.Parse("2012-06-02"), Description="Rent Payment", Cost=1500.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },

                new Invoice { PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID, DateIssued=DateTime.Parse("2017-06-08"), DatePaid=DateTime.Parse("2017-06-18"), Description="Sink Leak", Cost=500.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "MAINTENANCE") },
                new Invoice { PropertyID = properties.Single(p => p.Street == "9860 Cactus Lane Apt B").ID, DateIssued=DateTime.Parse("2017-05-05"), DatePaid=DateTime.Parse("2017-05-10"), Description="Shower head broke", Cost=800.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "MAINTENANCE") },
            };

            invoices.ForEach(s => context.Invoices.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            AddOrUpdateTenant(context, 1, "tanders@gmail.com");
            AddOrUpdateTenant(context, 1, "janders@gmail.com");
            AddOrUpdateTenant(context, 2, "tanders@gmail.com");
            AddOrUpdateTenant(context, 2, "janders@gmail.com");
            AddOrUpdateTenant(context, 3, "janders@gmail.com");

            AddOrUpdateTenant(context, 4, "tc@gmail.com");
            AddOrUpdateTenant(context, 5, "tc@gmail.com");
            AddOrUpdateTenant(context, 6, "tc@gmail.com");
            AddOrUpdateTenant(context, 7, "tc@gmail.com");
            AddOrUpdateTenant(context, 8, "tc@gmail.com");

            AddOrUpdateTenant(context, 9, "hdiaz@gmail.com");
            AddOrUpdateTenant(context, 10, "lduque@gmail.com");
            AddOrUpdateTenant(context, 11, "jburris@gmail.com");

            AddOrUpdateTenant(context, 12, "jtaylor@gmail.com");
            AddOrUpdateTenant(context, 13, "jtaylor@gmail.com");
            AddOrUpdateTenant(context, 14, "jtaylor@gmail.com");
            AddOrUpdateTenant(context, 15, "jtaylor@gmail.com");
            AddOrUpdateTenant(context, 16, "jtaylor@gmail.com");
            AddOrUpdateTenant(context, 17, "jtaylor@gmail.com");



        }

        void AddOrUpdateTenant(RBaseContext context, int leaseID, string tenantEmail)
        {
            var ls = context.Leases.SingleOrDefault(l => l.LeaseID == leaseID);
            var ten = ls.Tenants.SingleOrDefault(t => t.Email == tenantEmail);
            if (ten == null)
                ls.Tenants.Add(context.Tenants.Single(t => t.Email == tenantEmail));
        }
    }
}