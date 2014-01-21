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
    public class ProductsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: /Products/
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Client);
            return View(products.ToList());
        }

        // GET: /Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Products/Create
        public ActionResult Create(int? clientId)
        {
            Client client = db.Clients.Find(clientId);
            if (client == null)
            {
                return HttpNotFound();
            }

            var model = new NewProductForClientViewModel()
            {
                ClientId = client.Id,
                ClientName = client.Name,
                ProductName = ""
            };

            return View(model);
        }

        // POST: /Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewProductForClientViewModel product)
        {
            if (ModelState.IsValid)
            {
                var client = db.Clients.Single(c => c.Id == product.ClientId);
                client.Products.Add(new Product()
                {
                    ClientId = product.ClientId,
                    Name = product.ProductName
                });
                db.SaveChanges();
                return RedirectToAction("Details", "Clients", new { id = product.ClientId });
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", product.ClientId);
            return View(product);
        }

        // GET: /Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", product.ClientId);
            return View(product);
        }

        // POST: /Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,PictureUrl,ClientId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", product.ClientId);
            return View(product);
        }

        // GET: /Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
