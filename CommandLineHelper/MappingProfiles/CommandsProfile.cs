namespace CommandLineHelper.MappingProfiles
{
	using AutoMapper;
	using Dtos;
	using Models;

	public class CommandsProfile : Profile
	{
		public CommandsProfile()
		{
			// Source -> Target
			CreateMap<Command, CommandReadDto>();
			CreateMap<CommandCreateDto, Command>();
			CreateMap<CommandUpdateDto, Command>();
			CreateMap<Command, CommandUpdateDto>();
		}
	}
}