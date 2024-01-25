namespace CommandLineHelper.Data
{
	using System.Collections.Generic;
	using Models;

	public interface IRepo
	{
		IEnumerable<Command> GetCommands();
		
		Command GetCommand(int ID);
		
		void CreateCommand(Command command);
		
		void UpdateCommand(Command command);
		
		void DeleteCommand(Command command);
		
		bool SaveChanges();
	}
}