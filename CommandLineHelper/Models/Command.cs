namespace CommandLineHelper.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Command
	{
		[Key]
		[Required]
		public int Id { get; set; }
		
		[Required]
		public string Description { get; set; }
		
		[Required]
		[MaxLength(250)]
		public string CommandLine { get; set; }
		
		[Required]
		public string Platform { get; set; }
	}
}