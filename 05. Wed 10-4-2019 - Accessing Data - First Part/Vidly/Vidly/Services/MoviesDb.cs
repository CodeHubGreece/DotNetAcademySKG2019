using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;

namespace Vidly.Services
{
	/// <summary>
	/// Helper class that used to manage Movies
	/// </summary>
	public class MoviesDb
	{
		public static IEnumerable<Movie> GetAll()
		{
			using (var context = new VidlyContext())
			{
				return context.Movies.Include("Genre").ToList();
			}
		}
		public static Movie GetById(int Id)
		{
			using (var context = new VidlyContext())
			{
				return context.Movies.Include("Genre").SingleOrDefault(m => m.Id == Id);
			}
		}

		public static void Add(Movie movie)
		{
			using (var context = new VidlyContext())
			{
				context.Movies.Add(movie);
				context.SaveChanges();
			}
		}

		public static void Update(Movie movie)
		{
			using (var context = new VidlyContext())
			{
				Movie movieToUpdate = context.Movies.Find(movie.Id);
				movieToUpdate.GenreId = movie.GenreId;
				movieToUpdate.Name = movie.Name;
				movieToUpdate.ReleaseDate = movie.ReleaseDate;
				context.SaveChanges();
			}
		}

		public static void Delete(int id)
		{
			using (var context = new VidlyContext())
			{
				Movie movie = context.Movies.Find(id);
				context.Movies.Remove(movie);
				context.SaveChanges();
			}
		}

	}
}