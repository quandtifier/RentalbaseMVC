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
            //LINQ finds how many properties in each sity
            //IQueryable<PropertyCityGroup> data =
            //    from property in db.Properties
            //    group property by property.City into propertyGroup
            //    select new PropertyCityGroup()
            //    {
            //        City = propertyGroup.Key,
            //        PropertyCount = propertyGroup.Count()
            //    };


            string query =
                "SELECT City, AVG(RateMonthly) AS AVGRentAmount " +
                "FROM Property, Lease " +
                "WHERE ID=PropertyID " +
                "GROUP BY City";

            IEnumerable<RentCityGroup> data = db.Database.SqlQuery<RentCityGroup>(query);
            return View(data.ToList());
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