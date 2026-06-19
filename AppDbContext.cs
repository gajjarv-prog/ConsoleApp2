using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			try
			{
				// Connection string breakdown:
				// Server=.\SQLEXPRESS        -> connect to local SQL Server Express instance
				// Database=EFCoreDemo        -> name of the database to use
				// Trusted_Connection=True     -> use Windows Authentication (no username/password needed)
				// TrustServerCertificate=True -> skip SSL certificate validation (common for local dev)
				optionsBuilder.UseSqlServer(
					@"Server=.\SQLEXPRESS;Database=EFCoreDemo;Trusted_Connection=True;TrustServerCertificate=True;"
				);
			}
			catch (Exception d)
			{
				// If something goes wrong setting up the connection,
				// print the error instead of crashing silently.
				Console.WriteLine($"Didn't work: {d}");
			}
		}
	}
}