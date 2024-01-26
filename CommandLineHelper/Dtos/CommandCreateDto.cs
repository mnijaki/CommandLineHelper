namespace CommandLineHelper.Dtos
{
	using System.ComponentModel.DataAnnotations;

	// It should NOT have "ID" field.
	// It should have attributes with restrictions.
	public class CommandCreateDto
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