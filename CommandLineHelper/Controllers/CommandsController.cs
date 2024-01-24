namespace CommandLineHelper.Controllers
{
	using System.Collections.Generic;
	using AutoMapper;
	using Data;
	using Dtos;
	using Microsoft.AspNetCore.Mvc;
	using Models;

	[ApiController]
	[Route("api/[controller]")]
	public class CommandsController
	{
		// Use:
		// dotnet run --project CommandLineHelper
		// in terminal to run this project.
		
		private readonly IRepo _repo;
		private readonly IMapper _mapper;

		public CommandsController(IRepo repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}
		
		[HttpGet]
		public ActionResult<IEnumerable<CommandReadDto>> GetCommands()
		{
			IEnumerable<Command> commands = _repo.GetCommands();
			IEnumerable<CommandReadDto> commandsReadDtos = _mapper.Map<IEnumerable<CommandReadDto>>(commands);
			return new OkObjectResult(commandsReadDtos);
		}

		[HttpGet("{id}", Name = "GetCommand")]
		public ActionResult<CommandReadDto> GetCommand(int id)
		{
			Command command = _repo.GetCommand(id);
			if(command == null)
			{
				return new NotFoundResult();
			}
			
			CommandReadDto commandReadDto = _mapper.Map<CommandReadDto>(command);
			return new OkObjectResult(commandReadDto);
		}
		
		[HttpPost] 
		public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
		{
			Command command = _mapper.Map<Command>(commandCreateDto);
			_repo.CreateCommand(command);
			_repo.SaveChanges();
			
			CommandReadDto commandReadDto = _mapper.Map<CommandReadDto>(command);
			return new CreatedAtRouteResult(nameof(GetCommand), new {Id = commandReadDto.Id}, commandReadDto);
		}
		
		// [HttpPost]
		// public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
		// {
		// 	Command command = _repo.GetCommand(id);
		// 	if(command == null)
		// 	{
		// 		return new NotFoundResult();
		// 	}
		//
		// 	_mapper.Map(commandUpdateDto, command);
		// 	_repo.SaveChanges();
		// 	return new NoContentResult();
		// }
	}
}