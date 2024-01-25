namespace CommandLineHelper.Data
{
	using System.Collections.Generic;
	using System.Linq;
	using Models;

	public class SqlRepo : IRepo
	{
		private readonly Ctx _ctx;

		public SqlRepo(Ctx ctx)
		{
			_ctx = ctx;
		}
		
		public IEnumerable<Command> GetCommands()
		{
			return _ctx.Commands.ToList();
		}

		public Command GetCommand(int ID)
		{
			return _ctx.Commands.FirstOrDefault(c => c.Id == ID);
		}

		public void CreateCommand(Command command)
		{
			if(command == null)
			{
				throw new System.ArgumentNullException(nameof(command));
			}

			_ctx.Commands.Add(command);
		}

		public void UpdateCommand(Command command)
		{
			// This method is empty because the Context class is tracking the changes on the model for Sql.
		}

		public bool SaveChanges()
		{
			return (_ctx.SaveChanges() >= 0);
		}
	}
}