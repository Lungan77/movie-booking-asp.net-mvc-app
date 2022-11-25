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
    [Authorize]
    public class DatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        // GET: Dates
        public ActionResult Index()
        {
            var dates = db.Dates.Include(d => d.Movie);
            return View(dates.ToList());
        }

        [Authorize(Roles = "Client")]
        public ActionResult Booking(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dates = db.Dates.Include(d => d.Movie);

            dates = from d in dates
                    where d.MovieId == id
                    select d;



            return View(dates.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: Dates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dates dates = db.Dates.Find(id);
            if (dates == null)
            {
                return HttpNotFound();
            }
            return View(dates);
        }

        [Authorize(Roles = "Admin")]
        // GET: Dates/Create
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name");
            return View();
        }

        // POST: Dates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Time,Seats,MovieId")] Dates dates)
        {
            if (ModelState.IsValid)
            {
                db.Dates.Add(dates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", dates.MovieId);
            return View(dates);
        }

        [Authorize(Roles = "Admin")]
        // GET: Dates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dates dates = db.Dates.Find(id);
            if (dates == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", dates.MovieId);
            return View(dates);
        }

        // POST: Dates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Time,Seats,MovieId")] Dates dates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Name", dates.MovieId);
            return View(dates);
        }


        // GET: Dates/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dates dates = db.Dates.Find(id);
            if (dates == null)
            {
                return HttpNotFound();
            }
            return View(dates);
        }

        // POST: Dates/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dates dates = db.Dates.Find(id);
            db.Dates.Remove(dates);
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
