﻿using System;
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
    [Authorize(Roles ="Administrator, Ediotr")]
    public class ShowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
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

        public ActionResult Delete(int id)
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
			var genre = db.Genre.FirstOrDefault(m => m.id == model.genreId);
			var show = db.Show.FirstOrDefault(m => m.id == model.showId);
			show.genres.Add(genre);
			genre.shows.Add(show);
			db.SaveChanges();
			return RedirectToAction("Details/"+model.showId, "Shows", new { area = "" });
		}

		public ActionResult AddCastMember(int id)
		{
			ShowCast model = new ShowCast();
			model.showId = id;
			model.show = db.Show.Find(id);
			model.cast = db.Actors.ToList();
			return View(model);
		}

		[HttpPost]
		public ActionResult AddCastMember(ShowCast model)
		{
			var actor = db.Actors.FirstOrDefault(m => m.id == model.actorId);
			var show = db.Show.FirstOrDefault(m => m.id == model.showId);
			show.cast.Add(actor);
			actor.shows.Add(show);
			db.SaveChanges();
			return RedirectToAction("Details/" + model.showId, "Shows", new { area = "" });
		}

		public ActionResult AddDirector(int id)
		{
			ShowDirectors model = new ShowDirectors();
			model.showId = id;
			model.show = db.Show.Find(id);
			model.directors = db.Directors.ToList();
			return View(model);
		}

		[HttpPost]
		public ActionResult AddDirector(ShowDirectors model)
		{
			var director = db.Directors.FirstOrDefault(m => m.id == model.directorId);
			var show = db.Show.FirstOrDefault(m => m.id == model.showId);
			show.directors.Add(director);
			director.shows.Add(show);
			db.SaveChanges();
			return RedirectToAction("Details/" + model.showId, "Shows", new { area = "" });
		}

		 public ActionResult RemoveGenre(int id)
        {
            ShowGenre model = new ShowGenre();
            model.showId = id;
            model.show = db.Show.Find(id);
            model.genres = db.Genre.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult RemoveGenre(ShowGenre model)
        {
			var genre = db.Genre.FirstOrDefault(m => m.id == model.genreId);
			var show = db.Show.FirstOrDefault(m => m.id == model.showId);
			show.genres.Remove(genre);
			genre.shows.Remove(show);
			db.SaveChanges();
			return RedirectToAction("Details/"+model.showId, "Shows", new { area = "" });
		}
		
		public ActionResult RemoveCastMember(int id)
		{
			ShowCast model = new ShowCast();
			model.showId = id;
			model.show = db.Show.Find(id);
			model.cast = db.Actors.ToList();
			return View(model);
		}

		[HttpPost]
		public ActionResult RemoveCastMember(ShowCast model)
		{
			var actor = db.Actors.FirstOrDefault(m => m.id == model.actorId);
			var show = db.Show.FirstOrDefault(m => m.id == model.showId);
			show.cast.Remove(actor);
			actor.shows.Remove(show);
			db.SaveChanges();
			return RedirectToAction("Details/" + model.showId, "Shows", new { area = "" });
		}

		public ActionResult RemoveDirector(int id)
		{
			ShowDirectors model = new ShowDirectors();
			model.showId = id;
			model.show = db.Show.Find(id);
			model.directors = db.Directors.ToList();
			return View(model);
		}

		[HttpPost]
		public ActionResult RemoveDirector(ShowDirectors model)
		{
			var director = db.Directors.FirstOrDefault(m => m.id == model.directorId);
			var show = db.Show.FirstOrDefault(m => m.id == model.showId);
			show.directors.Remove(director);
			director.shows.Remove(show);
			db.SaveChanges();
			return RedirectToAction("Details/" + model.showId, "Shows", new { area = "" });
		}
	}
}
