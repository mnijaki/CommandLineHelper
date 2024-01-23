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
	}
}