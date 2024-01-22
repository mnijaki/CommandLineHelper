namespace CommandLineHelper.Controllers
{
	using System.Collections.Generic;
	using Data;
	using Microsoft.AspNetCore.Mvc;
	using Models;

	[ApiController]
	[Route("api/[controller]")]
	public class CommandsController
	{
		// Use:
		// dotnet run --project CommandLineHelper
		// in terminal to run this project.
		
		private readonly IAppRepo _repo;

		public CommandsController(IAppRepo repo)
		{
			_repo = repo;
		}
		
		[HttpGet]
		public ActionResult<IEnumerable<Command>> GetAllCommands()
		{
			IEnumerable<Command> commands = _repo.GetCommands();
			return new OkObjectResult(commands);
		}
		
		[HttpGet("{id}")]
		public ActionResult<Command> GetCommand(int id)
		{
			Command command = _repo.GetCommand(id);
			return new OkObjectResult(command);
		}
	}
}