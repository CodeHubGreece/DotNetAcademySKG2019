using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	/// <summary>
	/// Used to access and persist data to the database
	/// </summary>
	public class VidlyContext : IdentityDbContext<ApplicationUser>
	{
		// We need to replace this value with the appropriate value that points to the local database
		const string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB16;Initial Catalog=Vidly;Integrated Security=True";

		public VidlyContext() : base(connectionString){ }

		/// <summary>
		/// Collection managing movies
		/// </summary>
		public DbSet<Movie> Movies { get; set; }

		/// <summary>
		/// Collection managing genres
		/// </summary>
		public DbSet<Genre> Genres { get; set; }
	}
}