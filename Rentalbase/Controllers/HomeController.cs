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

            //IEnumerable<RentCityGroup> data = db.Database.SqlQuery<RentCityGroup>(query);
            viewModel.rentCityGroup = db.Database.SqlQuery<RentCityGroup>(query);
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