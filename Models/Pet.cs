using System.ComponentModel.DataAnnotations;

namespace finalproj.Models
{
	public class Pet
	{
		public int Id { get; set; }

		[Required]
		public string RecordType { get; set; }

		[Required]
		public string Location { get; set; }

		[Required]
		public string Name { get; set; }

		public string Type { get; set; }

		public int Age { get; set; }

		public string Color { get; set; }

		public DateTime Date { get; set; }

		public string Dtype { get; set; }
	}
	}
