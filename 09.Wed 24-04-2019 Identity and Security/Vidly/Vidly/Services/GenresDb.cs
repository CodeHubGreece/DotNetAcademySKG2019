using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Services
{
	/// <summary>
	/// Helper class that used to manage Genres
	/// </summary>
	public class GenresDb
	{
		public static IEnumerable<Genre> GetAll()
		{
			using (var context = new VidlyContext())
			{
				return context.Genres.ToList();
			}
		}
		public static Genre GetById(int id)
		{
			using (var context = new VidlyContext())
			{
				return context.Genres.Find(id);
			}
		}

		public static void Add(Genre genre)
		{
			using (var context = new VidlyContext())
			{
				context.Genres.Add(genre);
				context.SaveChanges();
			}
		}

		public static void Update(Genre genre)
		{
			using (var context = new VidlyContext())
			{
				Genre genreToUpdate = context.Genres.Find(genre.Id);
				genreToUpdate.Name = genre.Name;
				context.SaveChanges();
			}
		}

		public static void Delete(int id)
		{
			using (var context = new VidlyContext())
			{
				Genre genre = context.Genres.Find(id);
				context.Genres.Remove(genre);
				context.SaveChanges();
			}
		}
	}
}