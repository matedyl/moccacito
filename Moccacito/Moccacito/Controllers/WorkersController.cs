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
    public class WorkersController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: /Workers/
        public ActionResult Index()
        {
            return View(db.Workers.ToList());
        }

        // GET: /Workers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: /Workers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Firstname,Lastname,Gender,PictureUrl,Telephone,Email,PlaceWhereFound,Street,City,Zipcode")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(worker);
        }

        // GET: /Workers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: /Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Firstname,Lastname,Gender,PictureUrl,Telephone,Email,PlaceWhereFound,Street,City,Zipcode")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        // GET: /Workers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: /Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = db.Workers.Find(id);
            db.Workers.Remove(worker);
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

        // GET: /Workers/Employed
        public ActionResult Employed()
        {
            DateTime now = new DateTime(2014, 1, 10, 15, 1, 0);
            return View(db.Workers
                .Where(w => w.WorkUnits
                    .Any(wu => wu.EndTime > now))
                    .ToList());
        }

        // GET: /Workers/ToBePaid
        public ActionResult ToBePaid()
        {
            var listOfWorkers = db.Workers.AsEnumerable()
                .Where(w => w.WorkUnits
                    .Where(wu => wu.IsPaid == false)
                    .Sum(wu => wu.Value) > 0)
                    .ToList().Select(w => new WorkerWithWorkUnitsViewModel()
                    {
                        workerId = w.Id,
                        isPaid = false,
                        WorkerInfoViewModel = new WorkerViewModel()
                        {
                            Email = w.Email,
                            Firstname = w.Firstname,
                            Lastname = w.Lastname,
                            PictureUrl = w.PictureUrl,
                            Telephone = w.Telephone
                        },
                        WorkUnitsWithPayments = w.WorkUnits.Select(wu => new WorkUnitWithPayment()
                        {
                            EndTime = wu.EndTime,
                            LocationName = wu.Location.Name,
                            StartTime = wu.StartTime,
                            Value = wu.Value
                        }).ToList()
                    }).ToList();
            var model = new ToBePaidViewModel()
            {
                Workers = listOfWorkers
            };
            return View(model);
        }

        public ActionResult MarkAsPaid(int id)
        {
            Worker w = db.Workers.Find(id);
            foreach (var workUnit in w.WorkUnits)
            {
                workUnit.IsPaid = true;
            }
            db.SaveChanges();

            return RedirectToAction("ToBePaid");
        }
    }
}
