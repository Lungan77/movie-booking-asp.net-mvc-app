using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movie_Booking.Models;

namespace Movie_Booking.Controllers
{
    public class TypesofMoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypesofMovies
        public ActionResult Index()
        {
            return View(db.TypesofMovies.ToList());
        }

        // GET: TypesofMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypesofMovies typesofMovies = db.TypesofMovies.Find(id);
            if (typesofMovies == null)
            {
                return HttpNotFound();
            }
            return View(typesofMovies);
        }

        // GET: TypesofMovies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypesofMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] TypesofMovies typesofMovies)
        {
            if (ModelState.IsValid)
            {
                db.TypesofMovies.Add(typesofMovies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typesofMovies);
        }

        // GET: TypesofMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypesofMovies typesofMovies = db.TypesofMovies.Find(id);
            if (typesofMovies == null)
            {
                return HttpNotFound();
            }
            return View(typesofMovies);
        }

        // POST: TypesofMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] TypesofMovies typesofMovies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typesofMovies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typesofMovies);
        }

        // GET: TypesofMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypesofMovies typesofMovies = db.TypesofMovies.Find(id);
            if (typesofMovies == null)
            {
                return HttpNotFound();
            }
            return View(typesofMovies);
        }

        // POST: TypesofMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypesofMovies typesofMovies = db.TypesofMovies.Find(id);
            db.TypesofMovies.Remove(typesofMovies);
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
