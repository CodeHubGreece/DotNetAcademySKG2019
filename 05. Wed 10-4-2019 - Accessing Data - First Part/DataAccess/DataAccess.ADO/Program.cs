using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ADO
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please enter the first genre to store:");
			var genreName = Console.ReadLine();
			DataAccessHelper.SaveGenre(genreName);
			Console.WriteLine("Please enter the second genre to store:");
			genreName = Console.ReadLine();
			DataAccessHelper.SaveGenre(genreName);

			var genres = DataAccessHelper.GetAllGenres();
			Console.WriteLine($"There are {genres.Count()} strored genres in the data base.");
			foreach (var genre in genres)
			{
				Console.WriteLine($"Genre details: \tId: {genre.Id}, \tName: {genre.Name}");
			}

			Console.WriteLine("Please give the term to search:");
			var searchTerm = Console.ReadLine();
			var filteredGenres = DataAccessHelper.GetAllGenres(searchTerm);
			Console.WriteLine($"There are {filteredGenres.Count()} strored genres satisfying the search term: {searchTerm}");
			foreach (var genre in filteredGenres)
			{
				Console.WriteLine($"Genre details: \tId: {genre.Id}, \tName: {genre.Name}");
			}

			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}
	}
}
