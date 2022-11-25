using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Movie_Booking.Models;

namespace Movie_Booking.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Client).Include(b => b.Dates);
            return View(bookings.ToList());
        }

        [Authorize(Roles = "Client")]
        public ActionResult My_Bookings()
        {
            var user = User.Identity.GetUserId();
            var bookings = db.Bookings.Include(b => b.Client).Include(b => b.Dates);
            bookings = from d in bookings
                       where d.Client.UserId == user
                       select d;

            return View(bookings);
        }

        [Authorize(Roles = "Admin")]
        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        [Authorize(Roles = "Client")]
        public ActionResult Payment(int? id)
        {
            var price = (from c in db.Dates
                         where c.Id == id
                         select c.Movie.Price).SingleOrDefault();


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dates dates = db.Dates.Find(id);
            if (dates == null)
            {
                return HttpNotFound();
            }

            ViewBag.Price = price;

            return View();
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(int? id, [Bind(Include = "Id,DatesId,ClientId")] Booking booking)
        {
            if (ModelState.IsValid)
            {

                var date = (from d in db.Dates
                            where d.Id == id
                            select d.Date).SingleOrDefault();

                var time = (from d in db.Dates
                            where d.Id == id
                            select d.Time).SingleOrDefault();

                var seats = (from d in db.Dates
                            where d.Id == id
                            select d.Seats).SingleOrDefault();

                var movie = (from d in db.Dates
                             where d.Id == id
                             select d.MovieId).SingleOrDefault();

                if (seats == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                seats--;

                Dates dates = new Dates
                {
                    Id = (int)id,
                    Date = date,
                    Time = time,
                    Seats = seats,
                    MovieId = movie
                };

                db.Entry(dates).State = EntityState.Modified;

                var user = User.Identity.GetUserId();
                var Client_Id = (from c in db.Clients
                                 where c.UserId == user
                                 select c.Id).SingleOrDefault();

                booking.ClientId = Client_Id;
                booking.DatesId = (int)id;
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var price = (from c in db.Dates
                         where c.Id == id
                         select c.Movie.Price).SingleOrDefault();

            ViewBag.Price = price;

            return View(booking);
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
