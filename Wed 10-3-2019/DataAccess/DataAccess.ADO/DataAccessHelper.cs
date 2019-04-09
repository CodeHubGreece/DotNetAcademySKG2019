using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ADO
{
	public class DataAccessHelper
	{
		// We need to replace this value with the appropriate value that points to the local database
		const string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB16;Initial Catalog=Vidly;Integrated Security=True";

		/// <summary>
		/// Helper method that stores a genre record to the database
		/// </summary>
		/// <param name="name">The name of genre to store</param>
		public static void SaveGenre(string name)
		{
			using (var connection = new SqlConnection(connectionString))
			using (var command = new SqlCommand())
			{
				command.Connection = connection;
				command.CommandText = "INSERT INTO Genres (Name) VALUES(@Name)";

				command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = name;

				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// Returns all the stored genres
		/// </summary>
		public static IEnumerable<Genre> GetAllGenres()
		{
			using (var connection = new SqlConnection(connectionString))
			using (var command = new SqlCommand())
			{
				command.Connection = connection;
				command.CommandText = "SELECT * FROM Genres";

				var genres = new List<Genre>();

				// Open the connection in a try/catch block.
				// Create and execute the DataReader, writing the result
				// set to the console window.
				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						var genre = new Genre();
						genre.Id = int.Parse(reader[0].ToString());
						genre.Name = reader[1].ToString();
						genres.Add(genre);
					}
					reader.Close();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}

				return genres;
			}
		}

		/// <summary>
		/// Return all the stored genres that satisfy the search term
		/// </summary>
		/// <param name="searchTerm">The term to search</param>
		public static IEnumerable<Genre> GetAllGenres(string searchTerm)
		{
			using (var connection = new SqlConnection(connectionString))
			using (var command = new SqlCommand())
			{
				command.Connection = connection;
				command.CommandText = "SELECT * FROM Genres WHERE Name = @Term";
				command.Parameters.Add("@Term", SqlDbType.VarChar).Value = searchTerm;

				var genres = new List<Genre>();

				// Open the connection in a try/catch block.
				// Create and execute the DataReader, writing the result
				// set to the console window.
				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						var genre = new Genre();
						genre.Id = int.Parse(reader[0].ToString());
						genre.Name = reader[1].ToString();
						genres.Add(genre);
					}
					reader.Close();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}

				return genres;
			}
		}
	}
}
