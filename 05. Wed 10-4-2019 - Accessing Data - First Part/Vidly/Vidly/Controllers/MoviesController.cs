using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Services;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		// GET: Movies
		public ActionResult Index()
		{
			var movies = MoviesDb.GetAll();
			return View(movies.ToList());
		}

		// GET: Movies/Details/5
		public ActionResult Details(int id)
		{
			Movie movie = MoviesDb.GetById(id);
			if (movie == null)
			{
				return HttpNotFound();
			}
			return View(movie);
		}

		// GET: Movies/Create
		public ActionResult Create()
		{
			ViewBag.GenreId = new SelectList(GenresDb.GetAll(), "Id", "Name");
			return View();
		}

		// POST: Movies/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Movie movie)
		{
			if (ModelState.IsValid)
			{
				movie.DateAdded = DateTime.UtcNow;
				MoviesDb.Add(movie);
				return RedirectToAction("Index");
			}

			ViewBag.GenreId = new SelectList(GenresDb.GetAll(), "Id", "Name", movie.GenreId);
			return View(movie);
		}

		// GET: Movies/Edit/5
		public ActionResult Edit(int id)
		{
			Movie movie = MoviesDb.GetById(id);
			if (movie == null)
			{
				return HttpNotFound();
			}
			ViewBag.GenreId = new SelectList(GenresDb.GetAll(), "Id", "Name", movie.GenreId);
			return View(movie);
		}

		// POST: Movies/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Movie movie)
		{
			if (ModelState.IsValid)
			{
				MoviesDb.Update(movie);
				return RedirectToAction("Index");
			}
			ViewBag.GenreId = new SelectList(GenresDb.GetAll(), "Id", "Name", movie.GenreId);
			return View(movie);
		}

		// GET: Movies/Delete/5
		public ActionResult Delete(int id)
		{
			Movie movie = MoviesDb.GetById(id);
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
			MoviesDb.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
