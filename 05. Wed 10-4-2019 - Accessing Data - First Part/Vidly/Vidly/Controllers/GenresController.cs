using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Services;

namespace Vidly.Controllers
{
	public class GenresController : Controller
	{
		// GET: Genres
		public ActionResult Index()
		{
			var genres = GenresDb.GetAll();
			return View(genres);
		}

		// GET: Genres/Details/5
		public ActionResult Details(int id)
		{
			Genre genre = GenresDb.GetById(id);
			if (genre == null)
			{
				return HttpNotFound();
			}
			return View(genre);
		}

		// GET: Genres/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Genres/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Genre genre)
		{
			if (ModelState.IsValid)
			{
				GenresDb.Add(genre);
				return RedirectToAction("Index");
			}

			return View(genre);
		}

		// GET: Genres/Edit/5
		public ActionResult Edit(int id)
		{
			Genre genre = GenresDb.GetById(id);
			if (genre == null)
			{
				return HttpNotFound();
			}
			return View(genre);
		}

		// POST: Genres/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( Genre genre)
		{
			if (ModelState.IsValid)
			{
				GenresDb.Update(genre);
				return RedirectToAction("Index");
			}
			return View(genre);
		}

		// GET: Genres/Delete/5
		public ActionResult Delete(int id)
		{
			Genre genre = GenresDb.GetById(id);
			if (genre == null)
			{
				return HttpNotFound();
			}
			return View(genre);
		}

		// POST: Genres/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			GenresDb.Delete(id);
			return RedirectToAction("Index");
		}

	}
}
