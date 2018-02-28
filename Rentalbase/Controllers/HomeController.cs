using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentalbase.DAL;
using Rentalbase.ViewModels;

namespace Rentalbase.Controllers
{
    public class HomeController : Controller
    {
        private RBaseContext db = new RBaseContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var viewModel = new AboutData();
            //LINQ finds how many properties in each sity
            viewModel.propertyCityGroup =
                from property in db.Properties
                group property by property.City into propertyGroup
                select new PropertyCityGroup()
                {
                    City = propertyGroup.Key,
                    PropertyCount = propertyGroup.Count()
                };

            // Raw SQL query to find the avg rent amount paid
            // by all Tenants over all time, grouped by City
            string query =
                "SELECT City, AVG(RateMonthly) AS AVGRentAmount " +
                "FROM Property, Lease " +
                "WHERE ID=PropertyID " +
                "GROUP BY City " +
                "ORDER BY CITY";

            viewModel.rentCityGroup = db.Database.SqlQuery<RentCityGroup>(query);

            // RAW SQL query does full outer join on property and tenant 
            // result is a fat table with null values when property is not occupied
            // or tenant is not a current occupant
            query =
                "SELECT Name, Street, City, State, Zip, Email " +
                "FROM TENANT FULL JOIN PROPERTY " +
                "ON TENANT.PropertyID = PROPERTY.ID";

            viewModel.tenantPropertyGroup = db.Database.SqlQuery<TenantPropertyGroup>(query);

            return View(viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}