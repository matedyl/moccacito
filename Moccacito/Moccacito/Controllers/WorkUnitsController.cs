using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Moccacito.Models;

namespace Moccacito.Controllers
{
    public class WorkUnitsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: /WorkUnits/
        public ActionResult Index()
        {
            var workunits = db.WorkUnits.Include(w => w.Location).Include(w => w.Project).Include(w => w.Worker);
            return View(workunits.ToList());
        }

        // GET: /WorkUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkUnit workunit = db.WorkUnits.Find(id);
            if (workunit == null)
            {
                return HttpNotFound();
            }
            return View(workunit);
        }

        // GET: /WorkUnits/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "Firstname");
            return View();
        }

        // POST: /WorkUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StartTime,EndTime,HourRate,IsPaid,PaymentDate,ProjectId,LocationId,WorkerId")] WorkUnit workunit)
        {
            if (ModelState.IsValid)
            {
                workunit.IsPaid = false;
                db.WorkUnits.Add(workunit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", workunit.LocationId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", workunit.ProjectId);
            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "Firstname", workunit.WorkerId);
            return View(workunit);
        }

        // GET: /WorkUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkUnit workunit = db.WorkUnits.Find(id);
            if (workunit == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", workunit.LocationId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", workunit.ProjectId);
            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "Firstname", workunit.WorkerId);
            return View(workunit);
        }

        // POST: /WorkUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StartTime,EndTime,HourRate,IsPaid,PaymentDate,ProjectId,LocationId,WorkerId")] WorkUnit workunit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workunit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", workunit.LocationId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", workunit.ProjectId);
            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "Firstname", workunit.WorkerId);
            return View(workunit);
        }

        // GET: /WorkUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkUnit workunit = db.WorkUnits.Find(id);
            if (workunit == null)
            {
                return HttpNotFound();
            }
            return View(workunit);
        }

        // POST: /WorkUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkUnit workunit = db.WorkUnits.Find(id);
            db.WorkUnits.Remove(workunit);
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
