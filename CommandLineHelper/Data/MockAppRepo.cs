namespace CommandLineHelper.Data
{
	using System.Collections.Generic;
	using Models;

	/// <summary>
	///   Mock repository for testing.
	/// </summary>
	public class MockAppRepo
	{
		/// <summary>
		///   Get a list of commands.
		/// </summary>
		/// <returns>List of commands</returns>
		public IEnumerable<Command> GetAppCommands()
		{
			List<Command> commands = new List<Command>
			{
				new Command { Id = 0, Description = "Change directory", CommandLine = "CD", Platform = "PC"},
				new Command { Id = 1, Description = "Change directory", CommandLine = "CD", Platform = "Mac"},
				new Command { Id = 2, Description = "List directory", CommandLine = "DIR", Platform = "PC"},
				new Command { Id = 3, Description = "List directory", CommandLine = "LS", Platform = "Mac"},
			};
			
			return commands;
		}
		
		/// <summary>
		///   Get a command by ID.
		/// </summary>
		/// <param name="id">Id of command</param>
		/// <returns>Command of given ID</returns>
		public Command GetAppCommand(int id)
		{
			return new Command { Id = 0, Description = "Change directory", CommandLine = "CD", Platform = "PC"};
		}
	}
}