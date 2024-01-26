namespace CommandLineHelper.Data
{
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class Ctx : DbContext
	{
		// Explanation of DbSet:
		// Representation of Command objects(model) for Database in form of DBSets of given type (eg. Command).
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