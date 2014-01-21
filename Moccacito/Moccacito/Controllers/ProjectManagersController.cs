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
    public class ProjectManagersController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: /ProjectManager/
        public ActionResult Index()
        {
            return View(db.ProjectManagers.ToList());
        }

        // GET: /ProjectManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectmanager = db.ProjectManagers.Find(id);
            
            var model = new ProjectManagerDetailsViewModel()
            {
                Firstname = projectmanager.Firstname,
                Lastname = projectmanager.Lastname,
                PictureUrl = projectmanager.PictureUrl,
                Email = projectmanager.Email,
                Telephone = projectmanager.Telephone
            };
            if (projectmanager == null)
            {
                return HttpNotFound();
            }
            return View(projectmanager);
        }

        // GET: /ProjectManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ProjectManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,PictureUrl,Firstname,Lastname,Email,Telephone")] ProjectManager projectmanager)
        {
            if (ModelState.IsValid)
            {
                db.ProjectManagers.Add(projectmanager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectmanager);
        }

        // GET: /ProjectManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectmanager = db.ProjectManagers.Find(id);
            if (projectmanager == null)
            {
                return HttpNotFound();
            }
            return View(projectmanager);
        }

        // POST: /ProjectManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,PictureUrl,Firstname,Lastname,Email,Telephone")] ProjectManager projectmanager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectmanager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectmanager);
        }

        // GET: /ProjectManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectmanager = db.ProjectManagers.Find(id);
            if (projectmanager == null)
            {
                return HttpNotFound();
            }
            return View(projectmanager);
        }

        // POST: /ProjectManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectManager projectmanager = db.ProjectManagers.Find(id);
            db.ProjectManagers.Remove(projectmanager);
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
