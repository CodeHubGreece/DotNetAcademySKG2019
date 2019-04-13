﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private VidlyContext db = new VidlyContext();

		// GET: Movies
		public ActionResult Index()
		{
			var movies = db.Movies.Include(m => m.Genre);
			var viewModel = new MoviesViewModel();
			viewModel.ActionMovies = movies.Where(m => m.Genre.Name == "Action").ToList();
			viewModel.ThrillerMovies = movies.Where(m => m.Genre.Name == "Thriller").ToList();
			return View(viewModel);
		}

		// GET: Movies/Details/5
		public ActionResult Details(int? id)
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

		// GET: Movies/Create
		public ActionResult Create()
		{
			ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
			return View();
		}

		// POST: Movies/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,GenreId,DateAdded,ReleaseDate")] Movie movie)
		{
			if (ModelState.IsValid)
			{
				db.Movies.Add(movie);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
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
			ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
			return View(movie);
		}

		// POST: Movies/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,GenreId,DateAdded,ReleaseDate")] Movie movie)
		{
			if (ModelState.IsValid)
			{
				db.Entry(movie).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
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
