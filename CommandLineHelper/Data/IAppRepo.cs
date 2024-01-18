namespace CommandLineHelper.Data
{
	using System.Collections.Generic;
	using Models;

	public interface IAppRepo
	{
		IEnumerable<Command> GetCommands();
		Command GetCommand(int ID);
	}
}