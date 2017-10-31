using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthServer.Data.Entities
{
	[Table("Clients")]
	public class Client
	{
		[Key]
		public string Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		[Required]
		[MaxLength(44)]
		public string SecretHash { get; set; }
	}
}
