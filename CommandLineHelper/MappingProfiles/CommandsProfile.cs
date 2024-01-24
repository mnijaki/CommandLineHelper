namespace CommandLineHelper.MappingProfiles
{
	using AutoMapper;

	public class CommandsProfile : Profile
	{
		public CommandsProfile()
		{
			// Source -> Target
			CreateMap<Models.Command, Dtos.CommandReadDto>();
			//CreateMap<Dtos.CommandCreateDto, Models.Command>();
			//CreateMap<Dtos.CommandUpdateDto, Models.Command>();
			//CreateMap<Models.Command, Dtos.CommandUpdateDto>();
		}
	}
}