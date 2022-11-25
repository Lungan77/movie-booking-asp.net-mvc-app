using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movie_Booking.Models;
using PagedList;

namespace Movie_Booking.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index(string Name, string sortOrder, int? page, string currentFilter, string Genre)
        {
            var movies = db.Movies.Include(m => m.TypesofMovies);
            ViewBag.CurrentSort = sortOrder;

            var types = new List<string>();


            var type = from c in movies
                       orderby c.TypesofMovies.Type
                       select c.TypesofMovies.Type;

            types.AddRange(type.Distinct());
            ViewBag.Genre = new SelectList(types);

            if (!String.IsNullOrEmpty(Name))
            {
                movies = movies.Where(s => s.Name.Contains(Name));

            }

            if (!string.IsNullOrEmpty(Genre))
            {
                movies = from c in movies
                         where c.TypesofMovies.Type == Genre
                         select c;
            }

            if (Name != null)
            {
                page = 1;
            }
            else
            {
                Name = currentFilter;
            }

            ViewBag.CurrentFilter = Name;
            movies = movies.OrderBy(s => s.Id);
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(movies.ToPagedList(pageNumber, pageSize));

        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var movies = db.Movies.Include(m => m.TypesofMovies);

            Movie movie = (from d in movies
                          where d.Id == id
                          select d).SingleOrDefault();

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.TypesofMoviesId = new SelectList(db.TypesofMovies, "Id", "Type");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,TypesofMoviesId,ImageURL,Director,Writer,Starring,Date,Trailer,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypesofMoviesId = new SelectList(db.TypesofMovies, "Id", "Type", movie.TypesofMoviesId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypesofMoviesId = new SelectList(db.TypesofMovies, "Id", "Type", movie.TypesofMoviesId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,TypesofMoviesId,ImageURL,Director,Writer,Starring,Date,Trailer,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypesofMoviesId = new SelectList(db.TypesofMovies, "Id", "Type", movie.TypesofMoviesId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
