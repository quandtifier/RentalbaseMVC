using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rentalbase.DAL;
using Rentalbase.Models;
using Rentalbase.ViewModels;

namespace Rentalbase.Controllers
{
    public class TenantController : Controller
    {
        private RBaseContext db = new RBaseContext();

        // GET: Tenant
        public ActionResult Index(int? id)
        {
            // eager loading of the property and Leases navigation properties 
            var viewModel = new TenantIndexData();
            viewModel.Tenants = db.Tenants
                .Include(t => t.Property)
                .Include(t => t.Leases.Select(l => l.Property))
                .OrderBy(t => t.Name);

            if (id != null)
            {
                // the selected tenant's ID
                ViewBag.TenantID = id.Value;
                // store all leases referenced by this tenant in the viewModel
                viewModel.Leases = viewModel.Tenants.Where(
                    t => t.ID == id.Value).Single().Leases;
                // nested linq query for finding the address for this tenant
                ViewBag.PropertyStreet =
                    (from prop in db.Properties
                    where prop.ID == (from ten in viewModel.Tenants
                                      where id.Value == ten.ID
                                      select ten.PropertyID).FirstOrDefault()
                    select prop.Street).FirstOrDefault();

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
    }
}