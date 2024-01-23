namespace CommandLineHelper.Data
{
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class Ctx : DbContext
	{
		// Explanation of DbSet:
		// Represent our Command objects (model) down to database as DBSet called Commands.
		// DbSet is a collection of entities of a given type.
		// DbSet is a property of DbContext.
		// DbSet is used to perform CRUD operations on entities.
		// Each model in the app must have a DbSet representation to be included in the database.
		public DbSet<Command> Commands { get; set; }
		
		public Ctx(DbContextOptions<Ctx> options) : base(options)
		{
		}
	}
}