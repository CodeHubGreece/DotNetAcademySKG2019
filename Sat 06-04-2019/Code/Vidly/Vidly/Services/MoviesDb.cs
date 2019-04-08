using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Services
{
    public class MoviesDb
    {

        private static IList<Movie> _db = new List<Movie>()
        {
            new Movie() { Id = 1, Name = "Avengers:Infinity War" },
            new Movie() { Id = 2, Name = "The Notebook" },
            new Movie() { Id = 3, Name = "Shine" },
            new Movie() { Id = 4, Name = "Gone with the wind" },

        };
        public static IList<Movie> GetAll()
        {
            return _db;
        }
        public static void Add(Movie customer)
        {
            var rnd = new Random();
            customer.Id = rnd.Next(1, 1000);
            _db.Add(customer);
        }

        public static void Update(Movie movie)
        {

        }

        public static void Delete(Movie movie)
        {
            _db.Remove(movie);
        }

        public static Movie GetById(int Id)
        {
            return _db.FirstOrDefault(c => c.Id == Id);
        }
    }
}