using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Rentalbase.DAL;
using Rentalbase.Models;
using Rentalbase.ViewModels;

namespace Rentalbase.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LandlordController : Controller
    {
        private RBaseContext db = new RBaseContext();

        // GET: Landlord
        public ActionResult Index(int? id)
        {
            var viewModel = new LandlordIndexData();
            viewModel.Landlords = db.Landlords
                .Include(l => l.Properties)
                .OrderBy(l => l.Name);

            // Linq for finding the number of landlords who dont have properties
            viewModel.FreeLandlords =
                (from lord in db.Landlords
                where !(from prop in db.Properties
                        select prop.LandlordID).Contains(lord.ID)
                select db.Landlords.ToList()).Count();


            if (id != null)
            {
                // Save tenantID in for view
                ViewBag.LandlordID = id.Value;
                // Select all the properties associated with this Landlord
                viewModel.Properties = viewModel.Landlords.Where(
                    l => l.ID == id.Value).Single().Properties;
            }

            return View(viewModel);
        }

        // GET: Landlord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landlord landlord = db.Landlords.Find(id);
            if (landlord == null)
            {
                return HttpNotFound();
            }
            return View(landlord);
        }

        // GET: Landlord/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Landlord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Street,City,State,Zip,Phone,Email")] Landlord landlord)
        {
            if (ModelState.IsValid)
            {
                landlord.Phone = SetPhoneNumberWithDashes(landlord.Phone);
                db.Landlords.Add(landlord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(landlord);
        }

        // GET: Landlord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landlord landlord = db.Landlords.Find(id);
            if (landlord == null)
            {
                return HttpNotFound();
            }
            return View(landlord);
        }

        // POST: Landlord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Street,City,State,Zip,Phone,Email")] Landlord landlord)
        {

            if (ModelState.IsValid)
            {
                landlord.Phone = SetPhoneNumberWithDashes(landlord.Phone);
                db.Entry(landlord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(landlord);
        }

        // GET: Landlord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landlord landlord = db.Landlords.Find(id);
            if (landlord == null)
            {
                return HttpNotFound();
            }
            return View(landlord);
        }

        // POST: Landlord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Landlord landlord = db.Landlords.Find(id);
            db.Landlords.Remove(landlord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Formats phone numbers to have dashes
        public static string SetPhoneNumberWithDashes(string phoneNumberValue)
        {
            //Check if it is null or contains any non-digits
            if (string.IsNullOrWhiteSpace(phoneNumberValue) || !Regex.IsMatch(phoneNumberValue, @"^[\d\-]+$"))
            {
                //Return empty string
                return string.Empty;
            }

            //Check if it is in the format : ###-###-####
            if (Regex.IsMatch(phoneNumberValue, @"\d{3}\-\d{3}\-\d{4}"))
            {
                //Correct format - return it
                return phoneNumberValue;
            }

            if (phoneNumberValue.Length == 10)
            {
                //To use this method of formatting, you will need to pass in a numeric value, so convert
                //your string
                return string.Format("{0:###-###-####}", double.Parse(phoneNumberValue));
            }

            //Otherwise return the empty string
            return string.Empty;
        }
    }
}
