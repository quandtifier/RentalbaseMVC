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
    [Authorize(Roles = "Admin,Manager")]
    public class TenantController : Controller
    {
        private RBaseContext db = new RBaseContext();

        // GET: Tenant
        public ActionResult Index(int? id)
        {
            // 
            var viewModel = new TenantIndexData();
            viewModel.Tenants = db.Tenants
                .Include(t => t.Property)
                .Include(t => t.Leases.Select(l => l.Property))
                .OrderBy(t => t.Name);

            if (id != null)
            {
                // Save tenantID in for view
                ViewBag.TenantID = id.Value;
                // Select all the leases associated with this Tenant
                viewModel.Leases = viewModel.Tenants.Where(
                    t => t.ID == id.Value).Single().Leases;

                // Select property address for this tenant
                ViewBag.PropertyStreet =
                    (from prop in db.Properties
                    where prop.ID == (from ten in viewModel.Tenants
                                      where id.Value == ten.ID
                                      select ten.PropertyID).FirstOrDefault()
                    select prop.Street).FirstOrDefault();

                // Select the landlord for this tenant double nested query
                ViewBag.LandlordName =
                    (from lord in db.Landlords
                     where lord.ID == (from prop in db.Properties
                                       where prop.ID == (from ten in viewModel.Tenants
                                                         where id.Value == ten.ID
                                                         select ten.PropertyID).FirstOrDefault()
                                       select prop.LandlordID).FirstOrDefault()
                     select lord.Name).FirstOrDefault();

            }


            return View(viewModel);
        }

        // GET: Tenant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // GET: Tenant/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "Street");
            return View();
        }

        // POST: Tenant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PropertyID,Name,Phone,Email,RegistrationDate")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                tenant.Phone = SetPhoneNumberWithDashes(tenant.Phone);
                db.Tenants.Add(tenant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "Street", tenant.PropertyID);
            return View(tenant);
        }

        // GET: Tenant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "Street", tenant.PropertyID);
            return View(tenant);
        }

        // POST: Tenant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PropertyID,Name,Phone,Email,RegistrationDate")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                tenant.Phone = SetPhoneNumberWithDashes(tenant.Phone);
                db.Entry(tenant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "Street", tenant.PropertyID);
            return View(tenant);
        }

        // GET: Tenant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // POST: Tenant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            db.Tenants.Remove(tenant);
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