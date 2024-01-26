namespace CommandLineHelper.Controllers
{
	using System.Collections.Generic;
	using AutoMapper;
	using Data;
	using Dtos;
	using Microsoft.AspNetCore.JsonPatch;
	using Microsoft.AspNetCore.Mvc;
	using Models;

	[ApiController]
	[Route("api/[controller]")]
	public class CommandsController : ControllerBase
	{
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
			// Create an object of type "IEnumerable<CommandReadDto>" from the "commands" object.
			IEnumerable<CommandReadDto> commandsReadDtos = _mapper.Map<IEnumerable<CommandReadDto>>(commands);
			return Ok(commandsReadDtos);
		}

		[HttpGet("{id}", Name = "GetCommand")]
		public ActionResult<CommandReadDto> GetCommand(int id)
		{
			Command command = _repo.GetCommand(id);
			if(command == null)
			{
				return NotFound();
			}
			
			// Create an object of type "CommandReadDto" from the "command" object.
			CommandReadDto commandReadDto = _mapper.Map<CommandReadDto>(command);
			return Ok(commandReadDto);
		}
		
		[HttpPost] 
		public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
		{
			// Create method in Controller should return 201 status instead of standard 200.
			// It will inform that record was created sucessfully and it will aslo return URI to resource.
			// Use existing action to return URI to created resource.
			// It is usually "Get...(ID)" method.
			// You need to add name to "Get...(ID)" method attribute, so you can reference it from "Create...()" method:
			// Eg: [HttpGet("{id}", Name = "GetCommand")]
			// Your CreateCommand method in Controller must return "CreatedAtRoute()" method to add URI to created resource.
			
			// Create an object of type "Command" from the "commandCreateDto" object.
			Command command = _mapper.Map<Command>(commandCreateDto);
			_repo.CreateCommand(command);
			_repo.SaveChanges();
			
			// Create an object of type "CommandReadDto" from the "command" object.
			CommandReadDto commandReadDto = _mapper.Map<CommandReadDto>(command);
			return CreatedAtRoute(nameof(GetCommand), new {Id = commandReadDto.Id}, commandReadDto);
		}
		
		[HttpPut("{id}")]
		public ActionResult FullUpdateCommand(int id, CommandUpdateDto commandUpdateDto)
		{
			// Update should return 204 (NoContent) status code.
			
			Command command = _repo.GetCommand(id);
			if(command == null)
			{
				return NotFound();
			}
		
			// Map the values from "commandUpdateDto" object to "command" object.
			// This will automatically update the "command" object with the values from "commandUpdateDto".
			// Context will track the changes and update the database when "SaveChanges()" is called.
			_mapper.Map(commandUpdateDto, command);
			// For SQL Server, this is not needed.
			// We invoke "UpdateCommand", so in case we would have other implementations of "IRepo" 
			// (that does not automatically track changes), we would still be able to update the command.
			_repo.UpdateCommand(command);
			_repo.SaveChanges();
			
			return NoContent();
		}
		
		[HttpPatch("{id}")]
		public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
		{
			// Update should return 204 (NoContent) status code.
			
			Command command = _repo.GetCommand(id);
			if(command == null)
			{
				return NotFound();
			}
			
			// Create an object of type "CommandReadDto" from the "command" object.
			CommandUpdateDto commandUpdateDto = _mapper.Map<CommandUpdateDto>(command);
			// Patch "commandUpdateDto" object with the values from "patchDocument".
			patchDocument.ApplyTo(commandUpdateDto, ModelState);
			// Validate the "commandUpdateDto" object (eg. if its not missing required attributes).
			if(!TryValidateModel(commandUpdateDto))
			{
				return ValidationProblem(ModelState);
			}
			
			// Map the values from "commandUpdateDto" object to "command" object.
			// This will automatically update the "command" object with the values from "commandUpdateDto".
			// Context will track the changes and update the database when "SaveChanges()" is called.
			_mapper.Map(commandUpdateDto, command);
			// For SQL Server, this is not needed.
			// We invoke "UpdateCommand", so in case we would have other implementations of "IRepo" 
			// (that does not automatically track changes), we would still be able to update the command.
			_repo.UpdateCommand(command);
			_repo.SaveChanges();
			
			return NoContent();
		}
		
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			// Delete should return 204 (NoContent) status code.
			
			Command command = _repo.GetCommand(id);
			if(command == null)
			{
				return NotFound();
			}
			
			_repo.DeleteCommand(command);
			_repo.SaveChanges();
			
			return NoContent();
		}
	}
}