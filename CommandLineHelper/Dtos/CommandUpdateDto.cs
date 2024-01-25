namespace CommandLineHelper.Dtos
{
	using System.ComponentModel.DataAnnotations;

	public class CommandUpdateDto
	{
		[Required]
		public string Description { get; set; }
		
		[Required]
		[MaxLength(250)]
		public string CommandLine { get; set; }
		
		[Required]
		public string Platform { get; set; }

		public bool IsDTO { get; set; } = true;
	}
}