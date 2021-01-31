using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kinoteka.Models;

namespace Kinoteka.Controllers
{
    public class ShowsController : Controller
    {
        private ShowContext db = new ShowContext();

        // GET: Shows
        public ActionResult Index()
        {
            return View(db.Show.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Show.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,description,image,released_date,rating,type,play_link")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Show.Add(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Show.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,description,image,released_date,rating,type,play_link")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Show.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.Show.Find(id);
            db.Show.Remove(show);
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

		public ActionResult AddGenre(int id)
		{
			ShowGenre model = new ShowGenre();
			model.showId = id;
			model.show = db.Show.Find(id);
			model.genres = db.Genre.ToList();
			return View(model);
		} 

		[HttpPost]
		public ActionResult AddGenre(ShowGenre model)
		{
			var genre = db.Genre.FirstOrDefault(m=>m.id==model.genreId);
			var show = db.Show.FirstOrDefault(m => m.id == model.showId);
			show.genres.Add(genre);
			db.SaveChanges();
			return View("Index", db.Show.ToList());
		}
	}
}
