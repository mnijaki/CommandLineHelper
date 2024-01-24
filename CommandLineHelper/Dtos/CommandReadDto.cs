namespace CommandLineHelper.Dtos
{
	public class CommandReadDto
	{
		public int Id { get; set; }
		
		public string Description { get; set; }
		
		public string CommandLine { get; set; }
		
		public string Platform { get; set; }

		public bool IsDTO { get; set; } = true;
	}
}