using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Services;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Featured
        public ActionResult Featured()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name = "Avengers"
            };
            var customers = new List<Customer>()
            {
                new Customer(){Name="Customer1"},
                new Customer(){Name="Customer2"}

            };
            var viewModel = new FeaturedMovieViewModel();
            viewModel.Customers = customers;
            viewModel.Movie = movie;
            // ViewData["Movie"] = movie;
            // ViewBag.Movie = movie;
            //var viewResutl = new ViewResult();
            //viewResutl.ViewData.Model
            return View(movie);

            //return Json(MoviesDb.GetAll(), JsonRequestBehavior.AllowGet);
           // return View(viewModel);

            

            // return Content("Hello world!");
            // return Json(movie, JsonRequestBehavior.AllowGet);
            // return HttpNotFound();
            // return RedirectToAction("Index", "Home", new { id=4 });
            // return new EmptyResult();
        }


        // Movies/Edit/1
        // Movies/Edit?id=1
        //public ActionResult Edit(int id)
        //{
        //    return Content($"id={id}");
        //}
        // movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if(!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if(String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        //}

        public ActionResult Index()
        {
            var movies =  MoviesDb.GetAll();
            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int Id)
        {
            var movieInDb = MoviesDb.GetById(Id);
            return View(movieInDb);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Movies");
            }
            if (movie.Id == 0)
            {
                MoviesDb.Add(movie);
            }
            else
            {
                var movieInDb = MoviesDb.GetById(movie.Id);
                // update properties
                movieInDb.Name = movie.Name;

                MoviesDb.Update(movieInDb);


            }
            return RedirectToAction("Index", "Movies");

        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"year={year}, month={month}");
        }

        //constraints min, max, minlength,int, float,guid
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
          public ActionResult ByReleaseYear(int year, int month)
        {
            return Content($"year={year}, month={month}");
        }

    }
}